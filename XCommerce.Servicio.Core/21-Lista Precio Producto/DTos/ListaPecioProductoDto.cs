using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core._21_Lista_Precio_Producto.DTos
{
    public class ListaPecioProductoDto : BaseDto
    {
        public long ListaPrecioId { get; set; }

        public long  ArticuliId { get; set; }

        public string  ArticuloStr { get; set; }

        public decimal PrecioCosto { get; set; }

        public decimal PrecioPublico { get; set; }


        public System.DateTime FechaActualizacion { get; set; }

        public bool ActivarHoraVenta { get; set; }

        public System.DateTime HoraVenta { get; set; }

        /*=======================================================*/

        public string Lista { get; set; }
        public string Producto { get; set; }

        /*=======================================================*/


    }
}
