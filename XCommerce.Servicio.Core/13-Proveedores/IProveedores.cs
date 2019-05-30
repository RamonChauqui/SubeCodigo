using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core._13_Proveedores
{
    public interface IProveedores
    {
        long Insertar(ProveedoresDtos dtos);

        void Eliminar(long provID);

        void Modificar(ProveedoresDtos dto);

        /*================================================*/
        IEnumerable<ProveedoresDtos> Obtener( string cadenaBuscar);

        IEnumerable<ProveedoresDtos> ObtenerCAdena(string cadenaBuscar);

        ProveedoresDtos obtenerPorID(long entidadId);
        

    }
}
