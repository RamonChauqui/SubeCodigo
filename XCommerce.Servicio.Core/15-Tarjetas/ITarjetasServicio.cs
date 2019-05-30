using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core._15_Tarjetas
{
    public interface ITarjetasServicio
    {
        long Insertar(TarjetasServicioDtos dtos);

        void Eliminar(long bancoID);

        void Modificar(TarjetasServicioDtos dtos);


        /*================================P*/

        IEnumerable<TarjetasServicioDtos> obtener(string CadenaBuscar);

        TarjetasServicioDtos obtenerPorID(long entidadId);


    }
}
