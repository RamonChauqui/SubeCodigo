using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core._22_ComprobanteSalon.Dtos
{
    public class ComporobanteSAlonDetalleDto 
    {
        public long Id { get; set; }
        public long ComprobanteSalonId { get; set; }

        public decimal Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public string Codigo { get; set; }
        public string CodigoBarra { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal ProductoId { get; set; }


    }
}
