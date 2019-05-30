using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core._17_Caja
{
    public class CajaSalon : ICajaSalon
    {
        public long Insertar(DtoCajaSAlon dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevocj = new AccesoDatos.Caja
                {
                    MontoApertura = dto.MontoApertura,
                    MontoCierre = dto.MontoCierre,
                    FechaApertura = dto.FechaApertura,
                    FechaCierre = dto.FechaCierre,
                    UsuarioAperturaId = dto.UsuarioAperturaId,
                    UsuarioCierreId = dto.UsuarioCierreId,
                    EstadoCaja = EstadoCaja.Abierto

                };


                context.Cajas.Add(nuevocj);

                context.SaveChanges();

                return nuevocj.Id;
            }
        }
        public void AgregarMonto(decimal total, long cajaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {

                var monto = context.Cajas
                    .Include("DetalleCajas")
                    .FirstOrDefault(x => x.EstadoCaja == EstadoCaja.Abierto);

                if (monto != null)
                {
                    var item = monto.DetalleCajas
                            .FirstOrDefault(x => x.CajaId == cajaId);
                    // error????

                    if (item != null)
                    {
                        item.Monto += total;
                        item.TipoPago = TipoPago.Efectivo;
                        item.CajaId = cajaId;
                        monto.MontoCierre = monto.MontoApertura + item.Monto;

                    }
                    else
                    {
                        CargarNuevoItem(total, cajaId, monto);
                        monto.MontoCierre = monto.MontoApertura + total;

                    }
                    context.SaveChanges();

                }
            }

        }

        private void CargarNuevoItem(decimal total, long cajaId, Caja caja)
        {
            caja.DetalleCajas.Add(new DetalleCaja
            {
                Monto = total,
                CajaId = cajaId,
                TipoPago = TipoPago.Efectivo

            });
        }

        public DtoCajaSAlon ObtenerComprobantePorEstado(EstadoCaja estado)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var comprobante = context.Cajas
                    .Include(x => x.DetalleCajas)
                    .FirstOrDefault(x => x.EstadoCaja == estado);
                if (comprobante == null)
                {
                    return null;
                }
                // if(comprobante == null) throw new ArgumentNullException("Error Grave");

                var cajaDto = new DtoCajaSAlon
                {
                    Id = comprobante.Id,
                    MontoApertura = comprobante.MontoApertura,
                    MontoCierre = comprobante.MontoCierre,
                    FechaApertura = comprobante.FechaApertura,
                    FechaCierre = comprobante.FechaCierre,
                    EstadoCaja= comprobante.EstadoCaja,
                    UsuarioAperturaId= comprobante.UsuarioAperturaId,
                    UsuarioCierreId = comprobante.UsuarioCierreId

                };

                if (comprobante.DetalleCajas != null
                    && comprobante.DetalleCajas.Any())
                {
                    foreach (var detalle in comprobante.DetalleCajas)
                    {
                        cajaDto.DetalleCajaDtos.Add(new DetalleCaja
                        {
                            Id = detalle.Id,
                            CajaId= detalle.Id,
                            Monto= detalle.Monto,
                            TipoPago= detalle.TipoPago
                        });
                    }
                }

                return cajaDto;
            }
        }
        public void CerrarCaja(long cajaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var quitarComprobante = context.Cajas
                    .Include("DetalleCajas")
                    .FirstOrDefault(x => x.Id == cajaId
                    && x.EstadoCaja == EstadoCaja.Abierto);

                quitarComprobante.EstadoCaja = EstadoCaja.Cerrado;

                context.SaveChanges();

            }
        }
    }
}
