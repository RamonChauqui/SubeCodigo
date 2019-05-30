using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core._23_ComporbanteKiosco
{
   public class ComprobanteKioscoDto : BaseDto
    {
        public ComprobanteKioscoDto()
        {
            ComprobanteKioscoDetalleDtos = new List<_23_ComporbanteKiosco.ComprobanteKisocoDetallesDtos>();
        }

        public decimal TotalVentas { get; set; }
  

        public long EmpleadoId { get; set; }
        public string Empleado { get; set; }


        public long ClienteId { get; set; }

        public List<ComprobanteKisocoDetallesDtos> ComprobanteKioscoDetalleDtos { get; set; }
    }
}
