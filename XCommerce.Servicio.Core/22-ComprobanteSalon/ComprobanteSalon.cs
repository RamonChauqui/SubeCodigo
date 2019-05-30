using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core._00_Base;
using XCommerce.Servicio.Core._19_ProductoXMesa;
using XCommerce.Servicio.Core._22_ComprobanteSalon.Dtos;
using XCommerce.Servicio.Core.Articulo;
using XCommerce.Servicio.Core.Empleado.DTOs;
using XCommerce.Servicio.Core.ServicioKiosco;

namespace XCommerce.Servicio.Core._22_ComprobanteSalon
{
    public class ComprobanteSalon : IComprobanteSalon
    {
       
        private void Cargarnuevoitem(ArtiuculoDto producto, int cantidad, AccesoDatos.ComprobanteSalon comprobante)
        {

            comprobante.DetalleComprobantes.Add(new DetalleComprobante()
            {
                Cantidad = cantidad,
                Codigo = producto.Codigo.ToString(),
                ArticuloId = producto.Id,
                SubTotal = producto.PrecioPublico * cantidad,
                Descripcion = producto.Descripcion,
                PrecioUnitario = producto.PrecioPublico,


            });
           
        }

        public void CerrarMesa(long comprobanteId, ComprobanteSalonDto comprobante)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                var comprobanteGuardar =
                    contex.Comprobantes.OfType<AccesoDatos.DetalleComprobante>()
                    .FirstOrDefault(x => x.Id == comprobanteId);
                comprobanteGuardar.SubTotal = comprobante.Total;
                contex.SaveChanges();

            }
        }

      

        public ComprobanteSalonDto ObtenerComprobantePorMesa(long mesaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var comprobante = context.Comprobantes.OfType<AccesoDatos.ComprobanteSalon>()
                    .Include(x =>  x.DetalleComprobantes)
                    .Include(x => x.Mozo)
                    .FirstOrDefault(x => x.MesaId == mesaId
                                         && x.EstadoComprobanteSalon == EstadoComprobanteSalon.EnProceso                                        
                                         && x.EstadoComprobanteSalon != EstadoComprobanteSalon.Facturado);
                if (comprobante == null)
                {
                    return null;
                }
                // if(comprobante == null) throw new ArgumentNullException("Error Grave");

                var comprobanteDto = new ComprobanteSalonDto
                {
                    Id = comprobante.Id,
                    Total = comprobante.Total,
                    MesaId = comprobante.MesaId,
                    MozoId = comprobante.MozoId,
                    Mozo = comprobante.MozoId.HasValue ? $"{comprobante.Mozo.Apellido} {comprobante.Mozo.Nombre}" : "No Asignado",
                     ClienteId= comprobante.ClienteId

                };

                if (comprobante.DetalleComprobantes != null
                    && comprobante.DetalleComprobantes.Any())
                {
                    foreach (var detalle in comprobante.DetalleComprobantes)
                    {
                        comprobanteDto.ComprobanteSalonDetalleDtos.Add(new ComporobanteSAlonDetalleDto
                        {
                            Id = detalle.Id,
                            Descripcion = detalle.Descripcion,
                            Codigo = detalle.Codigo,
                            Cantidad = detalle.Cantidad,
                            SubTotal = detalle.SubTotal,
                                                    
                            //CodigoBarra = detalle.CodigoBarra,
                            //ComprobanteSalonId = detalle.SalonId,
                            Precio = detalle.PrecioUnitario,
                            ProductoId = detalle.ArticuloId,
                           
                        });
                    }

                }
                
                
                return comprobanteDto;
            }



        }

        public void SeleccionarMozo(long comprobanteId, EmpleadoDto empleado)
        {
            throw new NotImplementedException();
        }

        public void AgregarCliente(long mesaId, long clienteId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var quitarComprobante = context.Comprobantes.OfType<AccesoDatos.ComprobanteSalon>()
                    .Include(x => x.DetalleComprobantes)
                    .Include(x => x.Mozo)
                    .FirstOrDefault(x => x.MesaId == mesaId
                    && x.EstadoComprobanteSalon == EstadoComprobanteSalon.EnProceso);

                quitarComprobante.ClienteId = clienteId;

                context.SaveChanges();

            }

        }

        public void QuitarComprobante(long mesaId)
        {

            using (var context = new ModeloXCommerceContainer())
            {
                var quitarComprobante = context.Comprobantes.OfType<AccesoDatos.ComprobanteSalon>()
                 .Include(x => x.DetalleComprobantes)
                    .Include(x => x.Mozo)
                    .FirstOrDefault(x => x.MesaId == mesaId
                    && x.EstadoComprobanteSalon == EstadoComprobanteSalon.EnProceso);

                quitarComprobante.EstadoComprobanteSalon = EstadoComprobanteSalon.Facturado;
                quitarComprobante.TipoComprobante = TipoComprobante.X;

                context.SaveChanges();

            }
        }

        public void AgregarItem(long comprobanteId, int cantidad, ArtiuculoDto producto, long listaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var comprobante = context.Comprobantes
                    .Include(x => x.DetalleComprobantes)
                    .FirstOrDefault(z => z.Id == comprobanteId);

                var precio = context.Precios
                    .FirstOrDefault(x => x.ListaPrecioId == listaId && x.ArticuloId == producto.Id);

                if (precio == null)
                {
                    Mensaje.Mostrar("El precio del producto se encuentra eliminado, Vuelva a ingresar precio", Mensaje.Tipo.Informacion);
                    return;
                }

                producto.PrecioPublico = precio.PrecioPublico;
                

                if (comprobante == null) throw new Exception("Error");
                if (producto != null)
                {
                    var item = comprobante.DetalleComprobantes
                            .FirstOrDefault(x => x.ArticuloId == producto.Id
                            && x.Articulo.Precios.Any(z => z.ListaPrecioId == listaId));
                    // error????
                    if (item != null)
                    {
                        //El caso de que si exista el producto en el Detalle
                        if (item.PrecioUnitario == producto.PrecioPublico) // Por lista de Precios Distintas
                        {
                            item.Cantidad += cantidad;
                            item.SubTotal = item.Cantidad * producto.PrecioPublico;
                            producto.Stock -= 1;
                         
                        }
                        else
                        {
                            CargarNuevoItem(cantidad, producto, comprobante);
                           // comprobante.Total = producto.PrecioPublico * cantidad;

                        }


                    }
                    else
                    {
                        CargarNuevoItem(cantidad, producto, comprobante);
                        //comprobante.Total = producto.PrecioPublico * cantidad;

                    }
                    comprobante.Total = comprobante.DetalleComprobantes.Sum(x => x.SubTotal);
                    context.SaveChanges();
                }
            }

        }


        private void CargarNuevoItem(int cantidad, ArtiuculoDto producto, Comprobante comprobante)
        {
            comprobante.DetalleComprobantes.Add(new DetalleComprobante
            {
                Cantidad = cantidad,
                Codigo = producto.Codigo.ToString(),
                Descripcion = producto.Descripcion,
                PrecioUnitario = producto.PrecioPublico,
                ArticuloId = producto.Id,
                SubTotal = producto.PrecioPublico * cantidad

            });
        }

        public void Descuento(long coprobanteID, int descuento)
        {


            using (var context = new ModeloXCommerceContainer())
            {
                var quitarComprobante = context.Comprobantes.OfType<AccesoDatos.ComprobanteSalon>()
                 .Include(x => x.DetalleComprobantes)
                    .FirstOrDefault(x => x.Id == coprobanteID
                    && x.EstadoComprobanteSalon == EstadoComprobanteSalon.EnProceso);

                var resultado = ( descuento*quitarComprobante.DetalleComprobantes.Sum(x=> x.SubTotal)) /100;

                quitarComprobante.Total = quitarComprobante.DetalleComprobantes.Sum(x => x.SubTotal) - resultado;

                context.SaveChanges();

            }

        }

        public void CrearComprobante(Factura factura, long clienteId)
        {

            using (var contex = new ModeloXCommerceContainer())

            {
                if (clienteId == null)
                {


                    var nuevoComprobante = new ComprobanteFactura
                    {
                        Numero = factura.Numero,
                        Descuento = factura.Descuento,
                        Fecha = DateTime.Now,
                        SubTotal = factura.SubTotal,
                        Total = factura.Total,
                        UsuarioId = 1,
                        TipoComprobante = TipoComprobante.X,
                        ClienteId = clienteId 

                    };
                    foreach (var detalle in factura.Items)
                    {
                        nuevoComprobante.DetalleComprobantes.Add(new DetalleComprobante
                        {
                            Codigo = detalle.Codigo,
                            Cantidad = detalle.Cantidad,
                            Descripcion = detalle.Descripcion,
                            PrecioUnitario = detalle.Precio,
                            ArticuloId = detalle.Producto.Id,
                            SubTotal = detalle.SubTotal
                        });

                        contex.Comprobantes.Add(nuevoComprobante);
                    }
                }
                else
                {
                    var nuevoComprobante = new ComprobanteFactura
                    {
                        Numero = factura.Numero,
                        Descuento = factura.Descuento,
                        Fecha = DateTime.Now,
                        SubTotal = factura.SubTotal,
                        Total = factura.Total,
                        UsuarioId = 1,
                        TipoComprobante = TipoComprobante.X,
                        ClienteId = 2

                    };
                    foreach (var detalle in factura.Items)
                    {
                        nuevoComprobante.DetalleComprobantes.Add(new DetalleComprobante
                        {
                            Codigo = detalle.Codigo,
                            Cantidad = detalle.Cantidad,
                            Descripcion = detalle.Descripcion,
                            PrecioUnitario = detalle.Precio,
                            ArticuloId = detalle.Producto.Id,
                            SubTotal = detalle.SubTotal
                        });

                        contex.Comprobantes.Add(nuevoComprobante);
                    }
                }
                contex.SaveChanges();
            }


        }
    }
}
