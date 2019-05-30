using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core.Rubro
{

    public class RubroServicio : IRubroServicio
    {
        public void Elimiar(long rubro)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var rubroEliminar = context.Rubros
                    .FirstOrDefault(x => x.Id == rubro);

                if (rubroEliminar == null)
                    throw new Exception("Ocurrio un error al Obtener la Provincia");

                rubroEliminar.EstaEliminado = true;

                context.SaveChanges();
            }
        }

        public long insertar(RubroDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevorubro = new AccesoDatos.Rubro
                {
                    Descripcion = dto.Descripcion
                };

                context.Rubros.Add(nuevorubro);

                context.SaveChanges();

                return nuevorubro.Id;
            }
        }

        public void Modificar(RubroDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var rubroModificar = context.Rubros
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (rubroModificar == null)
                    throw new Exception("Ocurrio un error al Obtener la Provincia");

                rubroModificar.Descripcion = dto.Descripcion;

                context.SaveChanges();
            }
        }

        public RubroDto ObtenerPorId(long entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Rubros
                    .AsNoTracking()
                    .Select(x => new RubroDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado
                    }).FirstOrDefault(x => x.Id == entidadId);


            }


        }

        public IEnumerable<RubroDto> obtner(string cadenaBuscar)
        {
            using (var contex = new ModeloXCommerceContainer())
            {

                return contex.Rubros
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenaBuscar))
                    .Select
                    (
                    x => new RubroDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado,

                    }

                    ).ToList();

            }
        }
    }
}
