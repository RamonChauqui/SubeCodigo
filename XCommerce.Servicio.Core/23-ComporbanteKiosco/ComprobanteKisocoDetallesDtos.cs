using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core._23_ComporbanteKiosco
{
   public  class ComprobanteKisocoDetallesDtos : BaseDto
    {
        public long ComporbanteKiokoId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Cantidad  { get; set; }
        public decimal SubTotoal  { get; set; }
        public decimal ArticuloId { get; set; }


    }
}
