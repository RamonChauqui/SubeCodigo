using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core.Mesa_Comprobante.DTO
{
    public class ComprobanteMesaDto
    {
        public ComprobanteMesaDto()
        {

            Items = new List<DetalleComprobanteMesaDto>();
        }

        public decimal SubTotoal => Items.Sum(x => x.SubTotoal);

        public decimal Descueto { get; set; }

        public decimal Total => SubTotoal * Descuento.Calcular(Descueto, SubTotoal);

        public List<DetalleComprobanteMesaDto> Items { get; set; }

    }
}
