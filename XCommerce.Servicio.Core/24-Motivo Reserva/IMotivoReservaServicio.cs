using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core._24_Motivo_Reserva
{
    using System.Collections.Generic;
    using DTOs;

    public interface IMotivoReservaServicio
    {
        long Insertar(MotivoReservaDto dto);

        void Modificar(MotivoReservaDto dto);

        void Eliminar(long motivoReservaId);

        MotivoReservaDto ObtenerPorId(long entidadId);

        IEnumerable<MotivoReservaDto> Obtener(string cadenaBuscar);
    }
}
