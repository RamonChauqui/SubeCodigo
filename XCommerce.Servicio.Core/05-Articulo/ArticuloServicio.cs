using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core._00_Base;

namespace XCommerce.Servicio.Core.Articulo
{

    public class ArticuloServicio : IArticuloServicio
    {        
        public void Eliminar(long entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var empleadoEliminar = context.Articulos
                    .FirstOrDefault(x => x.Id == entidadId);

                if (empleadoEliminar == null)
                    throw new Exception("No se encontro el Articulo");
                empleadoEliminar.EstaEliminado = true;

                context.SaveChanges();
            }
        }

        public long Insertar(ArtiuculoDto dto)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                var nuevoArticulo = new AccesoDatos.Articulo
                {                 
                    Codigo = dto.Codigo,
                    CodigoBarra = dto.CodigoBarra,
                    Abreviatura = dto.Abreviatura,
                    Descripcion = dto.Descripcion,
                    Detalle = dto.Detalle,
                    Foto = dto.Foto,
                    ActivarLimiteVenta = dto.ActivarLimiteDeVenta,
                    LimiteVenta = dto.LimiteDeVenta,
                    PermiteStockNegativo = dto.PermitirStokNegativo,
                    EstaDiscontinuado = dto.EstaDiscontinuado,
                    DescuentaStock = dto.DescuentaStock,
                    EstaEliminado = dto.EstaEliminado,
                    
                    MarcaId = dto.MarcaId,
                    
                    RubroId = dto.RubroId,
                    
                    StockMaximo = dto.StockMaximo,
                    StockMinimo = dto.StockMinimo,
                    Stock = dto.Stock

                };

                contex.Articulos.Add(nuevoArticulo);
                contex.SaveChanges();
                return nuevoArticulo.Id;
            }
        }

        public void Modificar(ArtiuculoDto dto)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                var ArticuloModific = contex.Articulos
                    .FirstOrDefault(x => x.Id == dto.Id );

                if (ArticuloModific == null)
                    throw new Exception("No se encontro el Articulo");

                  ArticuloModific.Codigo = dto.Codigo;
                  ArticuloModific.CodigoBarra = dto.CodigoBarra;
                  ArticuloModific.Abreviatura = dto.Abreviatura;
                  ArticuloModific.Descripcion = dto.Descripcion;
                  ArticuloModific.Detalle = dto.Detalle;
                  ArticuloModific.Foto = dto.Foto;
                  ArticuloModific.ActivarLimiteVenta = dto.ActivarLimiteDeVenta;
                  ArticuloModific.LimiteVenta = dto.LimiteDeVenta;
                  ArticuloModific.PermiteStockNegativo = dto.PermitirStokNegativo;
                  ArticuloModific.EstaDiscontinuado = dto.EstaDiscontinuado;
                  ArticuloModific.DescuentaStock = dto.DescuentaStock;
                  ArticuloModific.EstaEliminado = dto.EstaEliminado;
                ArticuloModific.MarcaId = dto.MarcaId;
                ArticuloModific.RubroId = dto.RubroId;             
                ArticuloModific.StockMaximo = dto.StockMaximo;
                ArticuloModific.StockMinimo = dto.StockMinimo;
                ArticuloModific.Stock = dto.Stock;        
                contex.SaveChanges();
                
            }
        }

        public ArtiuculoDto ObtenerPorDescripcion(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var codigo = 1;
                int.TryParse(cadenaBuscar, out codigo);
                var producto = context.Articulos
                    .Include("Precios")
                    .FirstOrDefault(x => x.CodigoBarra == cadenaBuscar
                    || x.Codigo == codigo.ToString());

                if (producto == null)
                {
                    Mensaje.Mostrar("El producto no existe", Mensaje.Tipo.Informacion);
                }
                else
                {
                    /*Ver*/
                    return new ArtiuculoDto()
                    {
                        Id = producto.Id,

                        CodigoBarra = producto.CodigoBarra,
                        Codigo = producto.Codigo,
                        Stock = producto.Stock,
                        Descripcion = producto.Descripcion,
                        PrecioPublico = producto.Precios.FirstOrDefault(x=> x.ArticuloId == producto.Id).PrecioPublico,
                        EstaEliminado= false
                        
                    };
                }
                return null;
            }
        }
        public ArtiuculoDto ObtenerPorDescripcionLista(string cadenaBuscar,long listaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var codigo = 1;
                int.TryParse(cadenaBuscar, out codigo);
                var producto = context.Articulos
                    .Include("Precios")
                    .FirstOrDefault(x => x.CodigoBarra == cadenaBuscar
                    ||x.Descripcion == cadenaBuscar
                    || x.Codigo == codigo.ToString());

                if (producto == null)
                {
                    Mensaje.Mostrar("El producto no existe", Mensaje.Tipo.Informacion);
                }
                else
                {
                    /*Ver*/
                    return new ArtiuculoDto()
                    {
                        Id = producto.Id,

                        CodigoBarra = producto.CodigoBarra,
                        Codigo = producto.Codigo,
                        Stock = producto.Stock,
                        Descripcion = producto.Descripcion,
                        PrecioPublico = producto.Precios.FirstOrDefault(x => x.ArticuloId == producto.Id && x.ListaPrecioId == listaId).PrecioPublico,
                        EstaEliminado = false

                    };
                }
                return null;
            }
        }
        public IEnumerable<ArtiuculoDto> ObtenerPorFiltro(string cadenaBuscar)
        {
            throw new NotImplementedException();
        }

        public ArtiuculoDto ObtenerPorId(long entidadID)
        {
            using (var context = new ModeloXCommerceContainer())
            {

                return context.Articulos
                    .AsNoTracking()
                    .Select
                    (
                    x => new ArtiuculoDto
                    {
                        Id = x.Id,
                        Codigo = x.Codigo,
                        CodigoBarra = x.CodigoBarra,
                        Abreviatura = x.Abreviatura,
                        Descripcion = x.Descripcion,
                        Detalle = x.Detalle,
                        Foto = x.Foto,
                        ActivarLimiteDeVenta = x.ActivarLimiteVenta,
                        LimiteDeVenta = x.LimiteVenta,
                        PermitirStokNegativo = x.PermiteStockNegativo,
                        EstaDiscontinuado = x.EstaDiscontinuado,
                        DescuentaStock = x.DescuentaStock,
                        EstaEliminado = x.EstaEliminado,
                        MarcaId = x.MarcaId,
                        RubroId = x.RubroId,
                        StockMaximo = x.StockMaximo,
                        StockMinimo = x.StockMinimo,
                        Stock = x.Stock
                    }

                    ).FirstOrDefault(x => x.Id == entidadID);
            }
        }

        public IEnumerable<ArtiuculoDto> ObtenerPorListaPrecio(long listaPrecioId, string cadenBuscar)
        {
            var context = new ModeloXCommerceContainer();

            var codigo = 1;
            int.TryParse(cadenBuscar, out codigo);
            return context.Articulos
                .Include("ListasPreciosProductos")
                .Where(x => (x.Descripcion.Contains(cadenBuscar)
                             || x.Codigo == codigo.ToString()
                             || x.CodigoBarra == cadenBuscar)
                            && x.Precios.Any(l => l.ListaPrecioId == listaPrecioId))
                .Select(x => new ArtiuculoDto
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    CodigoBarra = x.CodigoBarra,
                    Descripcion = x.Descripcion,
                    Stock = x.Stock,
                    PrecioPublico = x.Precios
                        .FirstOrDefault(l => l.ListaPrecioId == listaPrecioId
                                             &&
                                             l.FechaActualizacion ==
                                             context.Precios.Where(p => p.ListaPrecioId == listaPrecioId
                                                                                     && p.ArticuloId == x.Id)
                                                 .Max(f => f.FechaActualizacion)).PrecioPublico

                });


        }     

        public IEnumerable<ArtiuculoDto> Obtenert(string cadenaBuscar)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                return contex.Articulos
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenaBuscar)
                    || x.Detalle.Contains(cadenaBuscar)
                    )
                    .Select(x => new ArtiuculoDto
                    {
                        Id = x.Id,
                        Codigo = x.Codigo,
                        CodigoBarra = x.CodigoBarra,
                        Abreviatura = x.Abreviatura,
                        Descripcion = x.Descripcion,
                        Detalle = x.Detalle,
                        Foto = x.Foto,
                        ActivarLimiteDeVenta = x.ActivarLimiteVenta,
                        LimiteDeVenta = x.LimiteVenta,
                        PermitirStokNegativo = x.PermiteStockNegativo,
                        EstaDiscontinuado = x.EstaDiscontinuado,
                        StockMaximo = x.StockMaximo,
                        StockMinimo = x.StockMinimo,
                        DescuentaStock = x.DescuentaStock,
                        EstaEliminado = x.EstaEliminado,
                        MarcaId = x.MarcaId,
                        RubroId = x.RubroId,
                        Stock = x.Stock,
                        Marca = x.Marca.Descripcion,
                        Rubro = x.Rubro.Descripcion
                    }).ToList();
            }
        }
        public void DisminuirStock(ArtiuculoDto dto)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                var productoModificar = contex.Articulos
                    .Single(x => x.Id == dto.Id);

                productoModificar.Stock -= 1;


                contex.SaveChanges();
            }
        }
        public IEnumerable<ArtiuculoDto> ObtenerTodo()
        {

            using (var contex = new ModeloXCommerceContainer())
            {
                var articulos = contex.Articulos.AsNoTracking()
                    .ToList();
                return articulos.Select(x => new ArtiuculoDto()
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    CodigoBarra = x.CodigoBarra,
                    Abreviatura = x.Abreviatura,
                    Descripcion = x.Descripcion,
                    Detalle = x.Detalle,
                    Foto = x.Foto,
                    ActivarLimiteDeVenta = x.ActivarLimiteVenta,
                    LimiteDeVenta = x.LimiteVenta,
                    PermitirStokNegativo = x.PermiteStockNegativo,
                    EstaDiscontinuado = x.EstaDiscontinuado,
                    StockMaximo = x.StockMaximo,
                    StockMinimo = x.StockMinimo,
                    DescuentaStock = x.DescuentaStock,
                    EstaEliminado = x.EstaEliminado,
                    MarcaId = x.MarcaId,
                    RubroId = x.RubroId,
                    Stock = x.Stock,
                    Marca = x.Marca.Descripcion,
                    Rubro = x.Rubro.Descripcion


                }).ToList();

            }
        }

        public bool VerificarSiExiste(long? ProductoId, int legajo)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Articulos.OfType<AccesoDatos.Articulo>()
                    .Any(x => x.Id != ProductoId && x.Codigo == legajo.ToString());
            }
        }
    }
}
