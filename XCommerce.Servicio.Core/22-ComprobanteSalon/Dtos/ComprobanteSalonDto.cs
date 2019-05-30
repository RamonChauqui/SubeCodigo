using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core._22_ComprobanteSalon.Dtos
{
   public  class ComprobanteSalonDto
    {
        public ComprobanteSalonDto()
        {
            ComprobanteSalonDetalleDtos = new List<ComporobanteSAlonDetalleDto>();
        }

        public long Id { get; set; }
        public long MesaId { get; set; }
        public long? MozoId { get; set; }

        public string Mozo { get; set; }

        public decimal Total { get; set; }

        public long? ClienteId { get; set; }


        public List<ComporobanteSAlonDetalleDto> ComprobanteSalonDetalleDtos { get; set; }

    }
}
