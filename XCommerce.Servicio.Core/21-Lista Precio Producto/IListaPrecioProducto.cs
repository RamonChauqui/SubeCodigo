using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Articulo;

namespace XCommerce.Servicio.Core._21_Lista_Precio_Producto.DTos
{
    public interface IListaPrecioProducto
    {
        IEnumerable<ArtiuculoDto> ObtenerLista(string cadenabuscar, long listaid);

        ArtiuculoDto ObtnerProducto(string cadenabuscar, long listaid);

        IEnumerable<ListaPecioProductoDto> Obtener(string cadenaBuscar);//**
        ListaPecioProductoDto ObtenerPorId(long Id);//**

        void Eliminar(ListaPecioProductoDto dto);//**

        void CrearListaPrecioProducto(ListaPecioProductoDto lista);

        void Modificar(ListaPecioProductoDto dto);
        ListaPecioProductoDto ObtenerListaPorProductoId(long Id);

        IEnumerable<ArtiuculoDto> ObtenerTodo();

    }
}
