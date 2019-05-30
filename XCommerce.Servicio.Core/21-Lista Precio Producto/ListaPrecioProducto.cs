using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core._00_Base;
using XCommerce.Servicio.Core.Articulo;

namespace XCommerce.Servicio.Core._21_Lista_Precio_Producto.DTos
{
    public class ListaPrecioProducto : IListaPrecioProducto
    {
        public void CrearListaPrecioProducto(ListaPecioProductoDto lista)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                var listaAgregar = new AccesoDatos.Precio()
                {
                    FechaActualizacion = lista.FechaActualizacion,
                    PrecioCosto = lista.PrecioCosto,
                    PrecioPublico = lista.PrecioPublico,
                    ArticuloId = lista.ArticuliId,
                    ListaPrecioId = lista.ListaPrecioId,
                    HoraVenta = lista.HoraVenta,
                    ActivarHoraVenta = lista.ActivarHoraVenta,
                };
                contex.Precios.Add(listaAgregar);
                contex.SaveChanges();

            }

        }
        public void Eliminar(ListaPecioProductoDto dto)
        {


            using (var context = new ModeloXCommerceContainer())
            {
                var empleado = context.Precios.
                    FirstOrDefault(x => x.Id == dto.Id);

                if (empleado != null) context.Precios.Remove(empleado);/*EstaEliminado = true;
*/
                context.SaveChanges();
            }
        }



        public void Modificar(ListaPecioProductoDto dto)
        {

            using (var context = new ModeloXCommerceContainer())
            {
                var precios = context.Precios                 
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (precios == null)
                    throw new Exception("No se encontro el Empleado");
                precios.Id = dto.Id;
                precios.PrecioPublico = dto.PrecioPublico;
                precios.PrecioCosto = dto.PrecioCosto;
                precios.FechaActualizacion = dto.FechaActualizacion;
                precios.ListaPrecioId = dto.ListaPrecioId;
                precios.ArticuloId = dto.ArticuliId;
                precios.ActivarHoraVenta = dto.ActivarHoraVenta;
                precios.HoraVenta = dto.HoraVenta;
                //precios.ListaPrecio.Descripcion = dto.Lista;
                //precios.Articulo.Descripcion = dto.Producto;
                precios.EstaEliminado = dto.EstaEliminado;

                context.SaveChanges();
            }

        }

        public IEnumerable<ArtiuculoDto> ObtenerLista(string cadenabuscar, long listaid)
        {
            var codigo = 0;
            int.TryParse(cadenabuscar, out codigo);

            var context = new ModeloXCommerceContainer();
            return context.Articulos
                .Include("Precios")
                .Where(x => (x.Descripcion.Contains(cadenabuscar)
                || x.CodigoBarra == cadenabuscar
                )&& x.Precios.Any(l => l.ListaPrecioId == listaid))
                .Select(x => new ArtiuculoDto()
                { Id = x.Id,
                Codigo = x.Codigo,
                Descripcion = x.Descripcion,
                CodigoBarra = x.CodigoBarra,
                Abreviatura = x.Abreviatura,
                Detalle = x.Detalle,

                    FechaActualizacion = x.Precios.FirstOrDefault(h => h.ListaPrecioId == listaid
                         && h.FechaActualizacion == context.Precios.Where(p => p.ListaPrecioId == listaid
                         && p.ArticuloId == x.Id).Max(f => f.FechaActualizacion)).FechaActualizacion,
                    Stock = x.Stock,

                    PrecioPublico = x.Precios.FirstOrDefault(h => h.ListaPrecioId == listaid
                      && h.FechaActualizacion == context.Precios.Where(p => p.ListaPrecioId == listaid
                      && p.ArticuloId == x.Id).Max(f => f.FechaActualizacion)).PrecioPublico

                });

        }

        public ListaPecioProductoDto ObtenerListaPorProductoId(long Id)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                var lista = contex.Precios.FirstOrDefault(x => x.ArticuloId == Id);

                if (lista == null)
                {
                    Mensaje.Mostrar("Asigne un precio al producto", Mensaje.Tipo.Informacion);
                }
                else
                {
                    return new ListaPecioProductoDto
                    {
                        Id = lista.Id,
                        ArticuliId = Id,
                        PrecioPublico = lista.PrecioPublico,
                        EstaEliminado = lista.EstaEliminado
                    };
                }
                return null;
            }
        }

        public ListaPecioProductoDto ObtenerPorId(long Id)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                return contex.Precios
                    .AsNoTracking()
                    .Select(x => new ListaPecioProductoDto
                    {
                        Id = x.Id,
                        PrecioPublico = x.PrecioPublico,
                        PrecioCosto = x.PrecioCosto,
                        FechaActualizacion = x.FechaActualizacion,
                        ListaPrecioId = x.ListaPrecioId,
                        ArticuliId = x.ArticuloId,
                        ActivarHoraVenta = x.ActivarHoraVenta,
                        HoraVenta = x.HoraVenta,
                        Lista = x.ListaPrecio.Descripcion,
                        Producto = x.Articulo.Descripcion,
                    }).FirstOrDefault(x => x.Id == Id);
            }


        }

        public IEnumerable<ListaPecioProductoDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Precios
                    .AsNoTracking()
                    //.Where( x => x.PrecioPublico.ToString().Contains(cadenaBuscar)
                    //|| x.ListaPrecio.ToString().Contains(cadenaBuscar))
                    //    .Where(x => x.PrecioPublico == Convert.ToInt64(cadenaBuscar) )
                    .Select(x => new ListaPecioProductoDto
                    {
                        Id = x.Id,
                        PrecioPublico = x.PrecioPublico,
                        PrecioCosto = x.PrecioCosto,
                        FechaActualizacion = x.FechaActualizacion,
                        ListaPrecioId = x.ListaPrecioId,
                        ArticuliId = x.ArticuloId,
                        ActivarHoraVenta = x.ActivarHoraVenta,
                        HoraVenta = x.HoraVenta,
                        Lista = x.ListaPrecio.Descripcion,
                        Producto = x.Articulo.Descripcion,
                        EstaEliminado = x.EstaEliminado,

                    }).ToList();
            }
        }

        public ArtiuculoDto ObtnerProducto(string cadenabuscar, long listaid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArtiuculoDto> ObtenerTodo()
        {
            using (var context = new ModeloXCommerceContainer())
            {


                var subrubros = context.Articulos.AsNoTracking()
                    .ToList();

                return subrubros.Select(x => new ArtiuculoDto()
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    Descripcion = x.Descripcion,
                    MarcaId = x.MarcaId,             
                    Stock = x.Stock,

                }).ToList();
            }

        }
    } 
                
    
}
