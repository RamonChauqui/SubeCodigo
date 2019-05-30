using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core.Bancos
{
    public interface IBancosServicios
    {
        long Insertar(BancosDtos dtos);

        void Eliminar(long bancoID);

        void Modificar(BancosDtos dtos);


        /*================================P*/

        IEnumerable<BancosDtos> obtener(string CadenaBuscar);

        BancosDtos obtenerPorID(long entidadId);




    }
}
