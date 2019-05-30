using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core._17_Caja
{
    public class DtoCajaSAlon : BaseDto
    {
        public DtoCajaSAlon()
        {
            DetalleCajaDtos = new List<DetalleCaja>();
        }

        public decimal MontoApertura { get; set; }

        public decimal  MontoCierre { get; set; }

        public DateTime FechaApertura { get; set; }

        public DateTime FechaCierre { get; set; }

        public long UsuarioAperturaId { get; set; }

        public long UsuarioCierreId { get; set; }

        public EstadoCaja EstadoCaja { get; set; }

        public List<DetalleCaja> DetalleCajaDtos { get; set; }

    }
}
