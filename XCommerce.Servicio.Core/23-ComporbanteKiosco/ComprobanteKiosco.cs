using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core._22_ComprobanteSalon.Dtos;
using XCommerce.Servicio.Core.Articulo;

namespace XCommerce.Servicio.Core._23_ComporbanteKiosco
{
    public class ComprobanteKiosco /*: IComprobanteKiosco*/
    {
        //public void AgregarItem(long comprobanteId, int cantidad, ArtiuculoDto producto, long listaId)
        //{
        //    using (var contex = new ModeloXCommerceContainer())
        //    {
        //        var comprobante = contex.Comprobantes
        //            .Include(x => x.DetalleComprobantes)
        //            .FirstOrDefault(x => x.Id == comprobanteId);

        //        if (comprobante == null)
        //            throw new Exception("Error al encontrar el comporbante ");

        //        if (producto != null)
        //        {
        //            var item = comprobante.DetalleComprobantes
        //                .FirstOrDefault(x => x.ArticuloId == producto.Id
        //                && x.PrecioUnitario == producto.PrecioPublico
        //                && x.Articulo.Precios.Any(l => l.ListaPrecioId == listaId));

                    

        //            if (item != null )
        //            {
        //                //true = existe producto en detalle 
        //                if (item.PrecioUnitario == producto.PrecioPublico)
        //                {
        //                    item.Cantidad += cantidad;
        //                    item.SubTotal = item.Cantidad * producto.PrecioPublico;
        //                    producto.Stock -= 1;
        //                    comprobante.Total = item.SubTotal;                           

        //                }
        //                else
        //                {
        //                    CargarNuevoItem(cantidad, producto, comprobante);
        //                }
        //            }
        //            else
        //            {
        //                CargarNuevoItem(cantidad, producto, comprobante);
        //            }

        //            contex.SaveChanges();
        //        }
        //    }                   
        //}

        //private void CargarNuevoItem(int cantidad, ArtiuculoDto producto, Comprobante comprobante)
        //{
        //    comprobante.DetalleComprobantes.Add(new DetalleComprobante
        //    {

        //        Cantidad = cantidad,
        //        Codigo = producto.Codigo.ToString(),
        //        Descripcion = producto.Descripcion,
        //        PrecioUnitario = producto.PrecioPublico,
        //        ArticuloId = producto.Id,
        //        SubTotal = producto.PrecioPublico * cantidad,
        //    });
        //    comprobante.Total = producto.PrecioPublico * cantidad;
        //}

        //public void Crear(long clienteID, ComprobanteKioscoDto dto)
        //{
        //    using (var contex = new ModeloXCommerceContainer())
        //    {                
        //        var nuevocomprobante = new kiosko
        //        {
                    
        //            Fecha = DateTime.Now,
        //            EstadoDeKiosco = EsatdoKiosco.EnProceso,
        //            TipoComprobante = TipoComprobante.X,
        //            ClienteId1 = clienteID,
        //            SubTotal = dto.TotalVentas,
        //            UsuarioId = 1,
        //            ClienteId = clienteID,

        //        };
        //        contex.Comprobantes.Add(nuevocomprobante);
        //        contex.SaveChanges();
        //    }
        //}

        //public ComprobanteKioscoDto ObtenerComprobantePorCliente(long clienteId)
        //{
        //    //using (var contex = new ModeloXCommerceContainer())
        //    //{

        //    //    var comprobante = contex.Comprobantes.OfType<AccesoDatos.kiosko>()
        //    //        .Include(x => x.DetalleKiosko)
        //    //        .Include(x => x.Cliente)
        //    //        .FirstOrDefault(x => x.ClienteId1 == clienteId
        //    //        && x.EstadoDeKiosco == EsatdoKiosco.EnProceso
        //    //        && x.EstadoDeKiosco != EsatdoKiosco.Cobrado);


        //    //    if (comprobante == null) throw new ArgumentNullException("Error Grave");

        //    //    var comprobantesDtos = new ComprobanteKioscoDto
        //    //    {
        //    //        Id = comprobante.Id,
        //    //        TotalVentas = comprobante.Total,
        //    //        ClienteId = comprobante.ClienteId1,

        //    //    };
        //    //    if (comprobante.DetalleKiosko != null
        //    //        && comprobante.DetalleKiosko.Any())
        //    //    {

        //    //        foreach (var detalle in comprobante.DetalleKiosko)
        //    //        {
        //    //            comprobantesDtos.ComprobanteKioscoDetalleDtos.Add(new ComprobanteKisocoDetallesDtos
        //    //            {
        //    //                Id = detalle.Id,
        //    //                Descripcion = detalle.Descripcion,
        //    //                Codigo = detalle.Codigo,
        //    //                Cantidad = detalle.Cantidad,
        //    //                SubTotoal = detalle.SubTotal,
        //    //                ComporbanteKiokoId = detalle.kioskoId,
        //    //                PrecioUnitario = detalle.PrecioUnitario,
        //    //                ArticuloId = detalle.ArticuloId
        //    //            });
        //    //        }
        //    //    }
        //    //    return comprobantesDtos;
        //    //}
        //    using (var contex = new ModeloXCommerceContainer())
        //    {
        //        return contex.Comprobantes.OfType<AccesoDatos.kiosko>()
        //           .Include(x => x.DetalleComprobantes)
        //           .Where(x => x.ClienteId == clienteId && x.EstadoDeKiosco == EsatdoKiosco.EnProceso)
        //            .Select(x => new ComprobanteKioscoDto
        //            {
        //                ClienteId = clienteId,
        //                EstaEliminado = false,
        //                TotalVentas = 0m,
        //                Id= x.Id,
        //                ComprobanteKioscoDetalleDtos = x.DetalleComprobantes
        //                .Select(d => new ComprobanteKisocoDetallesDtos
        //                {
        //                    Codigo = d.Codigo,
        //                    Descripcion = d.Descripcion,
        //                    Cantidad = d.Cantidad,
        //                    PrecioUnitario = d.PrecioUnitario,
        //                    ArticuloId = d.ArticuloId,
        //                    SubTotoal= d.SubTotal,
        //                    Id = d.Id
                            

        //                }).ToList()

        //            }).FirstOrDefault();
        //    }
        //}

        //public ComprobanteKioscoDto ObtenerComprobantePorId(long comprobanteId)
        //{
        //    using (var contex = new ModeloXCommerceContainer())
        //    {

        //        var comprobante = contex.Comprobantes.OfType<kiosko>()
        //            .Include(x => x.DetalleComprobantes)
        //            .FirstOrDefault(X => X.Id == comprobanteId
        //           && X.EstadoDeKiosco == EsatdoKiosco.Cobrado
        //           && X.EstadoDeKiosco != EsatdoKiosco.EnProceso
        //           && X.TipoComprobante == TipoComprobante.X);

        //        var comporbanteDto = new ComprobanteKioscoDto
        //        {
        //            Id = comprobante.Id,
        //            TotalVentas = comprobante.Total,
        //            EmpleadoId = comprobante.EmpleadoId,
        //            Empleado = "No asignado",
        //            ClienteId = comprobante.ClienteId1,
                
        //        };

        //        if (comprobante.DetalleKiosko != null
        //            && comprobante.DetalleKiosko.Any())
        //            foreach (var detalle in comprobante.DetalleKiosko)
        //            {
        //                comporbanteDto.ComprobanteKioscoDetalleDtos.Add(new ComprobanteKisocoDetallesDtos
        //                {
        //                    Id = detalle.Id,
        //                    Descripcion = detalle.Descripcion,
        //                    Codigo = detalle.Codigo,
        //                    Cantidad = detalle.Cantidad,
        //                    SubTotoal = detalle.SubTotal,
        //                    ComporbanteKiokoId = detalle.kioskoId,
        //                    PrecioUnitario = detalle.PrecioUnitario,
        //                    ArticuloId = detalle.ArticuloId
        //                });
        //            }
        //        return comporbanteDto;
        //    }
        //}

        //public IEnumerable<ComprobanteKioscoDto> ObtenerComprobantesPorCliente(long? clienteId)
        //{

        //    using (var contex = new ModeloXCommerceContainer())
        //    {
        //        var comprobante = contex.Comprobantes.OfType<kiosko>()
        //            .Include(x => x.DetalleComprobantes)
        //            .Where(x => (x.ClienteId1 == clienteId
        //                                 && (x.TipoComprobante == TipoComprobante.X)
        //                                 && (x.EstadoDeKiosco == EsatdoKiosco.Cobrado)))
        //                                 .Select(x => new ComprobanteKioscoDto
        //                                 {
        //                                     Id = x.Id,
        //                                     TotalVentas = x.Total,
        //                                     ClienteId = x.ClienteId,
        //                                     EmpleadoId = x.EmpleadoId,
        //                                     Empleado = "No Asignado"
        //                                 }).ToList();
        //        if (comprobante == null)
        //        {
        //            throw new ArgumentNullException("Error Grave");
        //        }
        //        return comprobante;

        //    }
        //}

        //public void EliminarItem(long comprobanteId, int cantidad, ArtiuculoDto producto, long listaId)
        //{
        //    using (var context = new ModeloXCommerceContainer())
        //    {
        //        var comprobante = context.Comprobantes.OfType<kiosko>()
        //            .Include(x => x.DetalleKiosko)
        //            .FirstOrDefault(x => x.Id == comprobanteId);

        //        if (comprobante == null) throw new Exception("Error");

        //        var item = comprobante.DetalleKiosko
        //            .FirstOrDefault(x => x.ArticuloId == producto.Id
        //            && x.Articulo.Precios.Any(l => l.ListaPrecioId == listaId));

        //        if (item != null)
        //        {
        //            if (item.Cantidad != 0)
        //            {
        //                item.Cantidad -= cantidad;
        //                item.SubTotal -= item.PrecioUnitario;
        //                producto.Stock += 1;
        //                comprobante.Total = item.SubTotal;
        //            }
        //            if (item.Cantidad == 0)
        //            {
        //                context.DetalleComprobantes.Remove(item);
        //            }
        //        }
        //        context.SaveChanges();
        //    }
        //}

        //public void QuitarComprobante(long clienteId)
        //{
        //    using (var context = new ModeloXCommerceContainer())
        //    {
        //        var quitarComprobante = context.Comprobantes.OfType<kiosko>()
        //            .Include(x => x.DetalleKiosko)
        //            .Include(x => x.DetalleKiosko)
        //            .FirstOrDefault(x => x.ClienteId1 == clienteId
        //            && x.EstadoDeKiosco == EsatdoKiosco.Cobrado);

        //        quitarComprobante.EstadoDeKiosco = EsatdoKiosco.Cobrado;
        //        quitarComprobante.TipoComprobante = TipoComprobante.X;
        //        context.SaveChanges();

        //    }
        //}

        //public void ComprobanteCtaCte(long clienteId)
        //{
        //    using (var context = new ModeloXCommerceContainer())
        //    {
        //        var quitarComprobante = context.Comprobantes.OfType<kiosko>()
        //            .Include(x => x.DetalleKiosko)
        //            .Include(x => x.Cliente)
        //            .FirstOrDefault(x => x.ClienteId == clienteId
        //            && x.EstadoDeKiosco == EsatdoKiosco.EnProceso);

        //        quitarComprobante.EstadoDeKiosco = EsatdoKiosco.Cobrado;
        //        quitarComprobante.TipoComprobante = TipoComprobante.X;
        //        context.SaveChanges();

        //    }
        //}

        //public void AgregarCliente(long mesaId, long clienteId)
        //{
        //    using (var context = new ModeloXCommerceContainer())
        //    {
        //        var quitarComprobante = context.Comprobantes.OfType<AccesoDatos.ComprobanteSalon>()
        //            .Include(x => x.DetalleComprobantes)
        //            .Include(x => x.Mozo)
        //            .FirstOrDefault(x => x.MesaId == mesaId
        //            && x.EstadoComprobanteSalon == EstadoComprobanteSalon.EnProceso);

        //        quitarComprobante.ClienteId = clienteId;

        //        context.SaveChanges();

        //    }
        //}

        //public ComprobanteKioscoDto ObtenerComprobantePorkiosco(long mesaId)
        //{
        //    using (var context = new ModeloXCommerceContainer())
        //    {
        //        var comprobante = context.Comprobantes.OfType<AccesoDatos.DetalleKiosko>()                  
        //            .FirstOrDefault(x => x.kioskoId == mesaId
        //                              /*   && x.EsatdoKiosco == EsatdoKiosco.EnProceso
        //                                 && x.EsatdoKiosco != EsatdoKiosco.Facturado*/);
        //        if (comprobante == null)
        //        {
        //            return null;
        //        }
        //        // if(comprobante == null) throw new ArgumentNullException("Error Grave");

        //        var comprobanteDto = new ComprobanteKioscoDto
        //        {
        //            Id = comprobante.Id,
        //            TotalVentas = comprobante.SubTotal,             
        //            ClienteId = comprobante.Id,
                    

        //        };

        //    //    if (comprobante.SubTotal != null
        //    //        && comprobante.DetalleComprobantes.Any())
        //    //    {
        //    //        foreach (var detalle in comprobante.DetalleComprobantes)
        //    //        {
        //    //            comprobanteDto.ComprobanteSalonDetalleDtos.Add(new ComporobanteSAlonDetalleDto
        //    //            {
        //    //                Id = detalle.Id,
        //    //                Descripcion = detalle.Descripcion,
        //    //                Codigo = detalle.Codigo,
        //    //                Cantidad = detalle.Cantidad,
        //    //                SubTotal = detalle.SubTotal,

        //    //                //CodigoBarra = detalle.CodigoBarra,
        //    //                //ComprobanteSalonId = detalle.SalonId,
        //    //                Precio = detalle.PrecioUnitario,
        //    //                ProductoId = detalle.ArticuloId,

        //    //            });
        //    //        }

        //    //    }


        //       return comprobanteDto;
        //    }



        //}
    }  
    
}
