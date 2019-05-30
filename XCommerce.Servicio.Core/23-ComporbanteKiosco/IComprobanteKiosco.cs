using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Articulo;

namespace XCommerce.Servicio.Core._23_ComporbanteKiosco
{
    public interface IComprobanteKiosco
    {
        void Crear(long clienteID, ComprobanteKioscoDto dto);

        ComprobanteKioscoDto ObtenerComprobantePorCliente(long clienteId);

        IEnumerable<ComprobanteKioscoDto> ObtenerComprobantesPorCliente(long? clienteId);


        ComprobanteKioscoDto ObtenerComprobantePorId(long comprobanteId);


        /*======================================================*/

        void AgregarItem(long comprobanteId, int cantidad, ArtiuculoDto producto, long listaId);

        void EliminarItem(long comprobanteId, int cantidad, ArtiuculoDto producto, long listaId);

        void QuitarComprobante(long clienteId);

        void ComprobanteCtaCte(long clienteId);
        /*==============================================================*/

        ComprobanteKioscoDto ObtenerComprobantePorkiosco(long mesaId);

    }
}
