using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core._12_CondicionIVA
{
    public interface ICondicionIVASServicvios
    {
        long Insertar(CondicionIIVADTOs dtos);

        void Elimianar(long CondicID);

        void Modifocar(CondicionIIVADTOs dtos);





        /*=============================*/

        IEnumerable<CondicionIIVADTOs> obtener(string cadenaBuscar);

        CondicionIIVADTOs obtenerPorID(long entidadID);





    }
}
