using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core.Marca
{
   public class MarcaServicio : IMarcaServicio
    {
        public void Elimiar(long marcaID)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var marcaEliminar = context.Marcas
                    .FirstOrDefault(x => x.Id == marcaID);

                if (marcaEliminar == null)
                    throw new Exception("Ocurrio un error al Obtener la Provincia");

                marcaEliminar.EstaEliminado = true;

                context.SaveChanges();
            }
        }

        public long Insertar(MarcaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var marcanueva = new AccesoDatos.Marca
                {
                    Descripcion = dto.Descripcion
                };

                context.Marcas.Add(marcanueva);

                context.SaveChanges();

                return marcanueva.Id;
            }
        }

        public void Modificar(MarcaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var provinciaModificar = context.Marcas
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (provinciaModificar == null)
                    throw new Exception("Ocurrio un error al Obtener la Provincia");

                provinciaModificar.Descripcion = dto.Descripcion;

                context.SaveChanges();
            }
        }

        public MarcaDto ObtenerPorId(long entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Marcas
                    .AsNoTracking()
                    .Select(x => new MarcaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado
                    }).FirstOrDefault(x => x.Id == entidadId);
            }
        }

        public IEnumerable<MarcaDto> obtner(string cadenaBuscar)
        {
            using (var contex = new ModeloXCommerceContainer())
            {

                return contex.Marcas
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenaBuscar))
                    .Select
                    (
                    x => new MarcaDto
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
