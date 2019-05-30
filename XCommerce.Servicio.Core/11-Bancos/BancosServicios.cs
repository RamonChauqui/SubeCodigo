using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core.Bancos
{
    public class BancosServicios : IBancosServicios
    {
        public void Eliminar(long bancoID)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                var bancoEliminar = contex.Bancos
                    .FirstOrDefault(x => x.Id == bancoID);

                    if(bancoEliminar == null)
                    throw new Exception("Ocurrio un error al obtener el banco ");

                bancoEliminar.EstaEliminado = true;

                contex.SaveChanges();
            }
        }

        public long Insertar(BancosDtos dtos)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                var nuevoBanco = new AccesoDatos.Banco
                {
                    Descripcion = dtos.Descripcion
                };
                contex.Bancos.Add(nuevoBanco);
                contex.SaveChanges();
                return nuevoBanco.Id;

            }
        }

        public void Modificar(BancosDtos dtos)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                var bancoModific = contex.Bancos
                    .FirstOrDefault(x => x.Id == dtos.Id);

                if (bancoModific == null)
                    throw new Exception("Ocurrio un error al obtener el banco ");

                bancoModific.Descripcion = dtos.Descripcion;
                contex.SaveChanges();

            }
        }

        /*====================================================*/


        public IEnumerable<BancosDtos> obtener(string CadenaBuscar)
        {

            using (var contex = new ModeloXCommerceContainer())
            {
                return contex.Bancos
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(CadenaBuscar))
                    .Select
                    (x => new BancosDtos
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                       EstaEliminado = x.EstaEliminado

                    }                                      
                    ).ToList(); 
            }

        }

        public BancosDtos obtenerPorID(long entidadId)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                return contex.Bancos
                    .AsNoTracking()
                    .Select(x => new BancosDtos
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado

                    }

                    ).FirstOrDefault(x => x.Id == entidadId);

            }


        }
    }
}
