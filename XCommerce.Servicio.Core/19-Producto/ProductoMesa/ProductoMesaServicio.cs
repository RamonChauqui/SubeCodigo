using System.Data.Entity;
using System.Linq;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core._19_ProductoXMesa;

namespace XCommerce.Servicio.Core._19_Producto.ProductoMesa
{
    public class ProductoMesaServicio/* : IProductoMesa*/
    {
        //// LA FUNCION ME VA A DEVOLVER UN PRODUCTO, DONDE MESAID ME TARE LOS PRECIOS I EL CODIGO PAA EL PRODUCTO EN SÍ
        //public ProductoMesaDto ObtenerPorCodigoDeLaMesa(long? mesaId, string codigo)
        //{
        //    using (var contex = new ModeloXCommerceContainer())
        //    {
        //        //NO PASSA /////////////////////////////////////

        //        return contex.Articulos
        //            .AsNoTracking()
        //            .Include(x => x.Precios)
        //            .Include("Precios.ListaPrecio")
        //            .Include("Precios.ListaPrecio.Salones")
        //            .Include("Precios.ListaPrecio.Salones.Mesas")
        //            .AsNoTracking()
        //            .Select(x => new ProductoMesaDto
        //            {
        //                Id = x.Id,
        //                Descripcion = x.Descripcion,
        //                EstaEliminado = x.EstaEliminado,
        //                Codigo = x.Codigo,
        //                CodigoBarra = x.CodigoBarra,
        //                DescurntaStock = x.DescuentaStock,//
        //                Precio = contex.Precios
        //            .FirstOrDefault(l => l.ListaPrecio.Salones.Any
        //            (s => s.Mesas.Any(m => m.Id == mesaId))
        //            && l.ArticuloId == x.Id
        //            && l.FechaActualizacion == contex.Precios
        //            .Where(l2 => l2.ListaPrecio.Salones.Any(
        //                s2 => s2.Mesas.Any(m2 => m2.Id == mesaId))
        //            && l2.ArticuloId == x.Id)
        //            .Max(max => max.FechaActualizacion)).PrecioPublico

        //            }).FirstOrDefault(x => x.Codigo == codigo
        //            || x.CodigoBarra == codigo);





            
        
    }
}
