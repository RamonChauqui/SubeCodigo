using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core.Rubro
{
    public interface IRubroServicio
    {
        long insertar(RubroDto dto);

        void Modificar(RubroDto dto);

        void Elimiar(long marcaID);

        IEnumerable<RubroDto> obtner(string cadenaBuscar);


        RubroDto ObtenerPorId(long entidadId);



    }
}
