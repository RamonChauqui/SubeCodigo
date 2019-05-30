using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core._25_Reserva
{
    using System.Collections.Generic;
    using DTOs;

    public interface IReservaServicio
    {
        long Insertar(ReservaDto dto);
        void Modificar(ReservaDto dto);
        void Eliminar(long reservaId);
        IEnumerable<ReservaDto> Obtener(string cadenaBuscar);
        ReservaDto ObtenerPorId(long entidadId);
        void CambiarEstado(long id, AccesoDatos.EstadoReserva estado);
        void ReservarMesa(long clienteId, long mesaId, int comensales);
        IEnumerable<ReservaDto> ObtenerMesasParaReserva();
    }
}
