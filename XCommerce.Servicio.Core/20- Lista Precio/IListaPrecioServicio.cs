using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core._20__Lista_Precio
{
    public interface IListaPrecioServicio
    {
       

        IEnumerable<ListaPrecioDto> obtner(string cadenaBuscar);
        
        void Crear(ListaPrecioDto dto);

        void Modificar(ListaPrecioDto dto);

        void Elimiar(long marcaID);

        ListaPrecioDto ObtenerPorId(long Id);

  
    }
}
