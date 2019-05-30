using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core._12_CondicionIVA
{
    public class CondicionIIVAServicios : ICondicionIVASServicvios
    {
        public void Elimianar(long CondicID)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                var elimiminar = contex.CondicionIvas
                    .FirstOrDefault(x => x.Id == CondicID);

                if (elimiminar == null)
                    throw new Exception("Ocurrio un error al obtener condicion iva");

                elimiminar.EstaElminado = true;

                contex.SaveChanges();

            }
        }

        public long Insertar(CondicionIIVADTOs dtos)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                var nuevocondIva = new AccesoDatos.CondicionIva
                {
                    Descripcion = dtos.Descripcion,
                };
                contex.CondicionIvas.Add(nuevocondIva);
                contex.SaveChanges();
                return nuevocondIva.Id;

            }
        }

        public void Modifocar(CondicionIIVADTOs dtos)
        {

            using (var contex = new ModeloXCommerceContainer())
            {
                var condModific = contex.CondicionIvas
                    .FirstOrDefault(x => x.Id == dtos.Id);

                if (condModific == null)
                    throw new Exception("Ocurrio un error al obtener la cond iva ");
                condModific.Descripcion = dtos.Descripcion;
                contex.SaveChanges();
            }
        }

        public IEnumerable<CondicionIIVADTOs> obtener(string cadenaBuscar)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                return contex.CondicionIvas
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenaBuscar))
                    .Select
                    (
                    x => new CondicionIIVADTOs
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaElminado,

                    }
                    ).ToList();

            }
        }

        public CondicionIIVADTOs obtenerPorID(long entidadID)
        {

            using (var contex =  new ModeloXCommerceContainer())
            {
                return contex.CondicionIvas
                    .AsNoTracking()
                    .Select
                    (
                    x => new CondicionIIVADTOs
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaElminado,

                    }

                    ).FirstOrDefault( x => x.Id == entidadID );
            }



        }
    }
}
