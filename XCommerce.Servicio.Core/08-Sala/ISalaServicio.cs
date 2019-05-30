using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Mesas;

namespace XCommerce.Servicio.Core.Sala
{
    public interface ISalaServicio
    {


        IEnumerable<SalaDto> Obtener(long salonId);
        IEnumerable<SalaDto> ObtenerCAdena(string cadenaBuscar);
        IEnumerable<SalaDto> ObtenerCMB(string cadenaBuscar);

        IEnumerable<MesaDtos> ObtenerMesasParaSalon();


        SalaDto ObtenerSalaPorMesa(long mesaId);
        SalaDto ObtenerPorID(long endtidadID);


        long insertar(SalaDto dto);
        void Eliminar(long salonID);
        void Modificar(SalaDto dto);


    }
}
