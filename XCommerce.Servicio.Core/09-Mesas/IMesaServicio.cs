using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core.Mesas
{
    public interface IMesaServicio
    {
        long insertar(MesaDtos dto);

        void Modificar(MesaDtos dtos);

        void Eliminar(long mesaId);

        void CambiarEstado(long id, AccesoDatos.EstadoMesa estado);

        ///*====================================*/

        IEnumerable<MesaDtos> Obtener(string cadenaBuscar);

        MesaDtos ObtenerPorID(long entidadId);

        IEnumerable<MesaDtos> obtenerPorSala(long SalaID);

        int ObtenerSiguientenumero();

        IEnumerable<MesaDtos> ObtenerPorEstado(string cadenaBuscar);

    }
}
