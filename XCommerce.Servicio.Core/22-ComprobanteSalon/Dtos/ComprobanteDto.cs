using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core._22_ComprobanteSalon.Dtos
{
    public class ComprobanteDto
    {
        public int Numero { get; set; }

        public DateTime fecha { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }

        public int Descuento { get; set; }

        public long UsuarioId { get; set; }
    }
}
