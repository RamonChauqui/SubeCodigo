using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Mesa_Comprobante.DTO;

namespace XCommerce.Servicio.Core.Mesa_Comprobante
{
    public class ComprobanteMesaServicio : IComprobanteMesaServicio
    {
        public void AbrirMesa(long usuauriId, long mesaid, int comensales, long? mozoid = null)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                //001- Cambiar el esatdo de la mesa 
                var mesaSeleccionana = contex.Mesas
                    .FirstOrDefault(x => x.Id == mesaid);

                if (mesaSeleccionana == null)
                    throw new Exception("Ocurró un error al obtener la mesa ");

                mesaSeleccionana.EstadoMesa = EstadoMesa.Abierta;

                /*
                 [PREGUNTAR SI YA ESTA EL COMPROBANTE CREADO O NO`PARA ESA MESA ]                
                 */
                if (contex.Comprobantes.OfType<AccesoDatos.ComprobanteSalon>()
                   .Any(x => x.MesaId == mesaid && x.EstadoComprobanteSalon == EstadoComprobanteSalon.EnProceso))
                {
                    contex.SaveChanges();
                    return;
                }
                    

                /*===================================================================*/
                //CREAMOS EL NUEVO COMPROBANTE 
                //0001- OBTENEMOS EL CLIENTE POR DEFECTO 

                var clienteConsumidorFinal = contex.Personas
                    .OfType<AccesoDatos.Cliente>()
                    .Include(x => x.Usuarios)
                    .FirstOrDefault(x => x.Dni == "123456789" );// ==> Consumidor final (99999999)

                if (clienteConsumidorFinal == null)
                    throw new Exception("Ocurró un error al obtener el consumidor final ");

                var nuevoComprobante = new ComprobanteSalon/*NECESITAMOS LOS COMENSALES, MESAid, MOSiD QUE LO OBTENEMOS
                    DE  EMPLEADO  */
                {

                    
                    ClienteId = clienteConsumidorFinal.Id,
                    Comensal = comensales,
                    MesaId = mesaid,            
                    SubTotal = 0m,
                    MozoId = 2,
                    Total = 0m,
                    Fecha = DateTime.Now,
                    TipoComprobante = TipoComprobante.X,
                    EstadoComprobanteSalon = EstadoComprobanteSalon.EnProceso,
                    UsuarioId = usuauriId, /*usuario Id para saber quien está realizando las cosas (Copiar logica para realizar el inicio de caja )*/
                    Numero = 0,/*CALCULAR EL NUMERO = 0 PORQ EL NUEMO SE PONE CUANDO VAMOS A REALIZAR LAS FACTURAS */
                    DetalleComprobantes = new List<DetalleComprobante>()

                };
                if (nuevoComprobante.DetalleComprobantes == null)
                {
                    nuevoComprobante.DetalleComprobantes = new List<DetalleComprobante>();
                }
                contex.Comprobantes.Add(nuevoComprobante);
                contex.SaveChanges();                
            }
        }
        public void ReservarMesa(long usuarioId, long mesaId, int comensales)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var mesaSeleccionana = context.Mesas
                    .FirstOrDefault(x => x.Id == mesaId);

                if (mesaSeleccionana == null)
                    throw new Exception("Ocurró un error al obtener la mesa ");

                mesaSeleccionana.EstadoMesa = EstadoMesa.Reservada;
            }
        }


        public ComprobanteMesaDto ObtenerComprobanteMesa(long mesaId)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                return contex.Comprobantes.OfType<AccesoDatos.ComprobanteSalon>()
                   .Include(x => x.DetalleComprobantes)
                   .Where(x => x.MesaId == mesaId && x.EstadoComprobanteSalon == EstadoComprobanteSalon.EnProceso)
                    .Select(x => new ComprobanteMesaDto
                    {
                        Descueto = x.Descuento,
                        Items = x.DetalleComprobantes
                        .Select(d => new DetalleComprobanteMesaDto
                        {
                            CodigoProcto = d.Codigo,
                            Descripcion = d.Descripcion,
                            Cantidad = d.Cantidad,
                            PrecioUnitario = d.PrecioUnitario

                        }).ToList()

                    }).FirstOrDefault();
            }

        }
        public void AgregarItem(long mesaID, long productiID, string codigo, string descripcion, decimal cantidad, decimal precio)
        {

            using (var contex = new ModeloXCommerceContainer())
            {
                var comprobante = contex.Comprobantes.OfType<ComprobanteSalon>()
                    .Include(x => x.DetalleComprobantes)
                    .First(x => x.MesaId == mesaID && x.EstadoComprobanteSalon == EstadoComprobanteSalon.EnProceso);

                if (comprobante == null)
                    throw new Exception("Ocurrió un error al obtener el comprobante ");

                var detalle = comprobante.DetalleComprobantes.FirstOrDefault(x => x.Codigo == codigo);
                if (detalle == null)
                {
                    //Agregar
                    comprobante.DetalleComprobantes.Add(new DetalleComprobante
                    {
                        ArticuloId = productiID,
                        Cantidad = cantidad,
                        Codigo = codigo,
                        Descripcion = descripcion,
                        PrecioUnitario = precio,
                        SubTotal = cantidad * precio,
                        

                    });

                }
                else
                {
                    

                    //Sumar la cantidad y actualizar
                    detalle.Cantidad += cantidad;
                    
                    detalle.SubTotal = detalle.Cantidad * detalle.PrecioUnitario;
                    

                }

                contex.SaveChanges();

            }

         
        }
    }
}
