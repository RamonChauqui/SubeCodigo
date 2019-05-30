using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Mesa_Comprobante.DTO;

namespace XCommerce.Servicio.Core.Mesa_Comprobante
{
    public interface IComprobanteMesaServicio
    {
        void ReservarMesa(long usuarioId, long mesaId, int comensales);


        void AbrirMesa(long usuauriId, long mesaid, int comensales, long? mozoid = null);/*NECEITO PASAR LA MESA id O EL CODIGO =ALGO QUE ME IDENTIFIQUE  LA MESA(EN ESTE CASO TENEMOS EL CODIGO Y EL id ) = */

        ComprobanteMesaDto ObtenerComprobanteMesa(long mesaId);

        void AgregarItem(long mesaID
            , long productiID
            , string codigo
            , string descripcion
            , decimal cantidad
            , decimal precio
            );  

    }
}
 