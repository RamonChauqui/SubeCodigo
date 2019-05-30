using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core._16_Planes_de_Yarjeta
{
    public class PlanesTajeta : IPlanesTajeta
    {
        public void Eliminar(long entidadID)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                var planElimiar = contex.PlanesTarjetas
                    .FirstOrDefault(x => x.Id == entidadID);

                if (planElimiar == null)
                    throw new Exception("No se encontró el Plan de tarjeta");

                planElimiar.EstaEliminado = true;
                contex.SaveChanges();
            }
           


      
            
        }

        public long Insertar(PlanesTajetaDTOs dtos)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                var tarjetinsetra = new AccesoDatos.PlanTarjeta
                {
                    Descripcion = dtos.Descripcion,
                    Alicuota = dtos.Alicuota,
                    TarjetaId = dtos.TarjetaID


                };
                contex.PlanesTarjetas.Add(tarjetinsetra);
                contex.SaveChanges();
                return tarjetinsetra.Id;              
            }
        }

        public void Modifocar(PlanesTajetaDTOs dtos)
        {

            using (var contex = new ModeloXCommerceContainer())
            {

                var planmodifc = contex.PlanesTarjetas
                    .FirstOrDefault(x => x.Id == dtos.Id);

                if (planmodifc == null)
                    throw new Exception("Ocurrio un error al Obtener plan ");

                planmodifc.Descripcion = dtos.Descripcion;
                planmodifc.Alicuota = dtos.Alicuota;
                planmodifc.TarjetaId = dtos.TarjetaID;

                contex.SaveChanges();

            }


        }

        /*===============================================*/

        public IEnumerable<PlanesTajetaDTOs> Obtener(string cadenaBuscar)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                return contex.PlanesTarjetas
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenaBuscar))
                    .Select
                    (
                    x => new PlanesTajetaDTOs
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        Alicuota = x.Alicuota,
                        TarjetaID = x.TarjetaId,
                        Tarjeta = x.Tarjeta.Descripcion,
                        EstaEliminado = x.EstaEliminado
                    }
                    ).ToList();
            }
        }

        public PlanesTajetaDTOs ObtenerPorId(long dto)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                return  contex.PlanesTarjetas
                    .Select
                    (
                    x => new PlanesTajetaDTOs
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        Alicuota = x.Alicuota,
                        EstaEliminado = x.EstaEliminado,
                        TarjetaID = x.TarjetaId,
                   

                    }
                    ).FirstOrDefault(x => x.Id == dto);

            }
        



        }
    }
}
