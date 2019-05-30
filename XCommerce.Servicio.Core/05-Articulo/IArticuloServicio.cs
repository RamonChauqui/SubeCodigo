using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core.Articulo
{
    public interface IArticuloServicio
    {
        long Insertar(ArtiuculoDto dto);

        void Modificar(ArtiuculoDto dto);

        void Eliminar(long entidadId);

        // ===================================================== //
        IEnumerable<ArtiuculoDto> Obtenert(string cadenaBuscar);

        ArtiuculoDto ObtenerPorId(long entidadID);
        ArtiuculoDto ObtenerPorDescripcionLista(string cadenaBuscar, long listaId);
        void DisminuirStock(ArtiuculoDto dto);

        /*=====================================================*/
        ArtiuculoDto ObtenerPorDescripcion(string cadenaBuscar);
        IEnumerable<ArtiuculoDto> ObtenerPorListaPrecio(long listaPrecioId, string cadenBuscar);
        IEnumerable<ArtiuculoDto> ObtenerPorFiltro(string cadenaBuscar);
        bool VerificarSiExiste(long? ProductoId, int legajo);
        IEnumerable<ArtiuculoDto> ObtenerTodo();

        /*=====================================================*/


    }
}
