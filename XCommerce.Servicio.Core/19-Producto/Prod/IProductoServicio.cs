using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core._19_Producto
{
    public interface IProductoServicio
    {
        ProductoDto ObtenerPorCodigo( long mesaId, string codigo);// 

        void DisminuirStock(ProductoDto dto);


    }
}
