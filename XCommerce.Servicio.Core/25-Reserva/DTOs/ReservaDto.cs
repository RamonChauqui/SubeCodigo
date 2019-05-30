using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core._25_Reserva.DTOs
{
    using System;
    using AccesoDatos;
    using Base;

    public class ReservaDto : BaseDto
    {
        public DateTime Fecha { get; set; }
        public decimal Senia { get; set; }
        public EstadoReserva EstadoReserva { get; set; }
        public long MesaId { get; set; }
        public long ClienteId { get; set; }
        public long UsuarioId { get; set; }
        public long MotivoReservaId { get; set; }
    }
}
