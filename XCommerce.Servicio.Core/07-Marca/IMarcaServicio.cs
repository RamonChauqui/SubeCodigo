using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core.Marca
{
    public interface IMarcaServicio
    {
        long Insertar(MarcaDto dto);

        void Modificar(MarcaDto dto);

        void Elimiar(long marcaID);


        IEnumerable<MarcaDto> obtner(string cadenaBuscar);


        MarcaDto ObtenerPorId(long entidadId);


    }
}
