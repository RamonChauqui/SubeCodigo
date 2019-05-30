using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core._19_ProductoXMesa;
using XCommerce.Servicio.Core._22_ComprobanteSalon.Dtos;
using XCommerce.Servicio.Core.Articulo;
using XCommerce.Servicio.Core.Empleado.DTOs;
using XCommerce.Servicio.Core.ServicioKiosco;

namespace XCommerce.Servicio.Core._22_ComprobanteSalon
{
   public  interface IComprobanteSalon
    {   
      
        ComprobanteSalonDto ObtenerComprobantePorMesa(long mesaId);    
        
        void SeleccionarMozo(long comprobanteId, EmpleadoDto empleado);

        void CerrarMesa(long comprobanteId, ComprobanteSalonDto comprobante);
        void CrearComprobante(Factura factura, long clienteId);
        /*==========================================================*/

        void AgregarCliente(long mesaId, long clienteId);

        void QuitarComprobante(long mesaId);

        /*=====================V========================================*/

        void AgregarItem(long comprobanteId, int cantidad, ArtiuculoDto producto, long listaId);

        /*¿¿¿¿¿¿¿¿¿¿¿¿¿¿¿¿¿¡*/

        void Descuento(long coprobanteID, int descuento);

    }
}
