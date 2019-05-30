using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core._15_Tarjetas
{
    public class TarjetasServicio : ITarjetasServicio
    {
        public void Eliminar(long bancoID)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                var bancoEliminar = contex.TarjetaSet
                    .FirstOrDefault(x => x.Id == bancoID);

                if (bancoEliminar == null)
                    throw new Exception("Ocurrio un error al obtener el banco ");

                bancoEliminar.EstaEliminado = true;

                contex.SaveChanges();
            }
        }

        public long Insertar(TarjetasServicioDtos dtos)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                var nuevoBanco = new AccesoDatos.Tarjeta
                {
                    Descripcion = dtos.Descripcion
                };

                contex.TarjetaSet.Add(nuevoBanco);
                contex.SaveChanges();

                return nuevoBanco.Id;

            }
        }

        public void Modificar(TarjetasServicioDtos dtos)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                var bancoModific = contex.TarjetaSet
                    .FirstOrDefault(x => x.Id == dtos.Id);

                if (bancoModific == null)
                    throw new Exception("Ocurrio un error al obtener el banco ");

                bancoModific.Descripcion = dtos.Descripcion;
                contex.SaveChanges();

            }
        }

        public IEnumerable<TarjetasServicioDtos> obtener(string CadenaBuscar)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                return contex.TarjetaSet
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(CadenaBuscar))
                    .Select
                    (x => new TarjetasServicioDtos
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado

                    }
                    ).ToList();
            }

        }

        public TarjetasServicioDtos obtenerPorID(long entidadId)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                return contex.TarjetaSet
                    .AsNoTracking()
                    .Select(x => new TarjetasServicioDtos
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
