using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core._16_Planes_de_Yarjeta
{
   public interface IPlanesTajeta
    {
        long Insertar(PlanesTajetaDTOs dtos);

        void Eliminar(long entidadID);

        void Modifocar(PlanesTajetaDTOs dtos);


        /*============================================================*/
        IEnumerable<PlanesTajetaDTOs> Obtener(string cadenaBuscar);

        PlanesTajetaDTOs ObtenerPorId(long dto);

    }
}
