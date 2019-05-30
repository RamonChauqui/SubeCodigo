using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core._19_Producto
{
    public class ProductoServicio : IProductoServicio
    {
        public ProductoDto ObtenerPorCodigo(long mesaId/*SIRVE PARA SABER EL SALON Y A LA MISMA VEZ PRECIO*/, string codigo)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                return contex.Articulos
                    .Include("Precios")
                    .AsNoTracking()
                    .Select(X => new ProductoDto
                    {
                        Id = X.Id,
                        Codigo = X.Codigo,
                        CodigoBarra = X.CodigoBarra,
                        Descripcion = X.Descripcion,
                        Precio = 0m ,
                        EstaEliminado = X.EstaEliminado,
                        Stock = X.Stock

                    }).FirstOrDefault(X => X.Codigo == codigo || X.CodigoBarra == codigo);

            }
        }
        public void DisminuirStock(ProductoDto dto)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                var productoModificar = contex.Articulos
                    .Single(x => x.Id == dto.Id);

                productoModificar.Stock -= 1;


                contex.SaveChanges();
            }
        }
    }
}
