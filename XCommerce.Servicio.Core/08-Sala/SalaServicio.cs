
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core._00_Base;
using XCommerce.Servicio.Core.Mesas;

namespace XCommerce.Servicio.Core.Sala
{
    public class SalaServicio : ISalaServicio
    {

        public IEnumerable<SalaDto> Obtener(long salonId)/*NO PASAMOS UNA CADENA BUSCAR PORUQ ENO ESTAMOS POR HACER UNA BUSQUEAD, LO QUE VAMOS A REALIZAR ES PLASMAR TODO*/
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                return contex.Salones
                    .AsNoTracking()
                    .Where(x => !x.EstaEliminado && x.Id != salonId)
                    .Select
                    (x =>
                   new SalaDto
                   {
                       Id = x.Id,
                       Descripcion = x.Descripcion,
                       ListaPrecioId = x.ListaPrecioID


                   }
                   )
                    .ToList();
            }

        }
        public static decimal ObtenerTotalVenta(long mesaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var comprobante = context.Comprobantes.OfType<AccesoDatos.ComprobanteSalon>()
                    .FirstOrDefault(x => x.MesaId == mesaId
                    && x.EstadoComprobanteSalon == EstadoComprobanteSalon.EnProceso);

                if (comprobante == null) return 0m;

                if (comprobante.DetalleComprobantes == null) return 0m;

                if (comprobante.DetalleComprobantes.Any())
                    return comprobante.DetalleComprobantes.Sum(x => x.SubTotal);

                return 0m;
            }
        }
        public IEnumerable<SalaDto> ObtenerCAdena(string cadenaBuscar)
        {

            using (var contex = new ModeloXCommerceContainer())
            {
                return contex.Salones
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new SalaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado,
                        DescripcionLista = x.ListaPrecio.Descripcion



                    }).ToList();
            }


        }

        public SalaDto ObtenerPorID(long endtidadID)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                return contex.Salones
                    .AsNoTracking()
                    .Select(x => new SalaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado,
                        ListaPrecioId = x.ListaPrecio.Id
                    }

                    ).FirstOrDefault(x => x.Id == endtidadID);

            }
        }



        public long insertar(SalaDto dto)
        {

            using (var contex = new ModeloXCommerceContainer())
                
            {
                var nuevasala = new XCommerce.AccesoDatos.Salon

                {

                    Descripcion = dto.Descripcion,
                    ListaPrecioID = dto.ListaPrecioId,
                    ListaPrecio = contex.ListaPrecios.FirstOrDefault(x=> x.Id == dto.ListaPrecioId)
                };

                contex.Salones.Add(nuevasala);

                contex.SaveChanges();
                return nuevasala.Id;
            }

        }
        public SalaDto ObtenerSalaPorMesa(long mesaId)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                var lista = contex.Salones.FirstOrDefault(x => x.Mesas.FirstOrDefault(z=> z.Id == mesaId ).Id == mesaId);

                if (lista == null)
                {
                    Mensaje.Mostrar("Asigne un precio al producto", Mensaje.Tipo.Informacion);
                }
                else
                {
                    return new SalaDto
                    {
                        Id = lista.Id,
                        EstaEliminado = lista.EstaEliminado,
                        Descripcion = lista.Descripcion,
                        ListaPrecioId = lista.ListaPrecioID
                    };
                }
                return null;
            }
        }

        public IEnumerable<SalaDto> ObtenerCMB(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Salones

                    .Where(x => x.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new SalaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        ListaPrecioId = x.ListaPrecioID


                    }).ToList();
            }
        }

        public void Eliminar(long salonID)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                var salaElimianr = contex.Salones
                    .FirstOrDefault(x => x.Id == salonID);

                if (salaElimianr == null)
                    throw new Exception("NO SE ENCONTRARON SALAS ");

                salaElimianr.EstaEliminado = true;
                contex.SaveChanges();
            }
        }

        public void Modificar(SalaDto dto)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                var salonModif = contex.Salones
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (salonModif == null)
                    throw new Exception("OCURRIÓ UN ERROR AL OBTENER SALA ");
                salonModif.Descripcion = dto.Descripcion;
                contex.SaveChanges();
            }


        }

        public IEnumerable<MesaDtos> ObtenerMesasParaSalon()
        {

            using (var context = new ModeloXCommerceContainer())
            {
                return context.Mesas.AsNoTracking()
                    .Include("ComprobantesSalones")
                    .Select(x => new MesaDtos()
                    {
                        Id = x.Id,
                        Numero = x.Numero,
                        Descripcion = x.Descripcion,
                        EstadoMesa = x.EstadoMesa,
                        ComprobanteId = x.ComprobantesSalones.Any(s => s.EstadoComprobanteSalon == EstadoComprobanteSalon.EnProceso)
                           ? x.ComprobantesSalones
                               .FirstOrDefault(s => s.EstadoComprobanteSalon == EstadoComprobanteSalon.EnProceso).Id
                               : -1
                    }).ToList();
            }

        }
    }
}
