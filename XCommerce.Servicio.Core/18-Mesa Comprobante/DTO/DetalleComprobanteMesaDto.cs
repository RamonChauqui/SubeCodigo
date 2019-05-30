using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core.Mesa_Comprobante.DTO
{
 public  class DetalleComprobanteMesaDto
    {
        public string CodigoProcto { get; set; }

        public string Descripcion { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Cantidad { get; set; }

        public decimal SubTotoal => PrecioUnitario * Cantidad;

    }
}
