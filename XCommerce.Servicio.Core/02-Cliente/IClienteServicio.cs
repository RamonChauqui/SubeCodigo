using System.Collections.Generic;
using XCommerce.Servicio.Core.Cliente.DTOs;

namespace XCommerce.Servicio.Core.Cliente
{
    public interface IClienteServicio
    {
        long Insertar(ClienteDto dto);

        void Modificar(ClienteDto dto);

        void Eliminar(long empleadoId);

        // ===================================================== //

        IEnumerable<ClienteDto> Obtener(string cadenaBuscar);

        ClienteDto ObtenerPorId(long entidadId);
    }
}
