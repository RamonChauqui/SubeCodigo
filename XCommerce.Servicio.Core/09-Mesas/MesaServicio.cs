using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core.Mesas
{
    public class MesaServicio : IMesaServicio
    {
        public long insertar(MesaDtos dto)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                var nuevamesa = new XCommerce.AccesoDatos.Mesa
                {
                    Id = dto.Id,
                    Numero = dto.Numero,
                    Descripcion = dto.Descripcion,
                    EstaEliminado = dto.EstaEliminado,
                    EstadoMesa = dto.EstadoMesa,
                    SalonId = dto.SalonId
                };
                contex.Mesas.Add(nuevamesa);

                contex.SaveChanges();
                return nuevamesa.Id;
            }
        }

        public void Modificar(MesaDtos dtos)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var mesaModific = context.Mesas
                    .FirstOrDefault(x => x.Id == dtos.Id);

                if (mesaModific == null)
                    throw new Exception("Ocurrio un error al Obtener la Provincia");

                mesaModific.Descripcion = dtos.Descripcion;
                mesaModific.SalonId = dtos.SalonId;

                context.SaveChanges();
            };
        }

        public void Eliminar(long mesaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var mesaEliminar = context.Mesas
                    .FirstOrDefault(x => x.Id == mesaId);

                if (mesaEliminar == null)
                    throw new Exception("Ocurrio un error al Obtener la mesaa");

                mesaEliminar.EstaEliminado = true;

                context.SaveChanges();
            }
        }

        /*==========================================================================*/
        public IEnumerable<MesaDtos> obtenerPorSala(long SalaID)
        {

            using (var contex = new ModeloXCommerceContainer())
            {
                return contex.Mesas
                    .AsNoTracking()
                    .Where(x => !x.EstaEliminado && x.SalonId == SalaID)
                    .Select(x => new MesaDtos
                    {
                        Id = x.Id,
                        Numero = x.Numero,
                        Descripcion = x.Descripcion,
                        SalonId = x.SalonId,
                        EstadoMesa = x.EstadoMesa
                    }
                    ).ToList();
            }
        }

        public IEnumerable<MesaDtos> Obtener(string cadenaBuscar)
        {

            using (var contex = new ModeloXCommerceContainer())
            {
                return contex.Mesas
                    .AsNoTracking()

                    .Where(x => x.Descripcion.Contains(cadenaBuscar)
                    ).Select(x => new MesaDtos
                    {
                        Id = x.Id,
                        Numero = x.Numero,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado,
                        SalonId = x.Salon.Id,
                        Salon = x.Salon.Descripcion
                        
                    }).ToList();
            }
        }

        public MesaDtos ObtenerPorID(long entidadId)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                return contex.Mesas
                    .Select(x => new MesaDtos
                    {
                        Id = x.Id,
                        Numero = x.Numero,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado,
                        SalonId = x.SalonId,
                        Salon = x.Salon.Descripcion

                    }).FirstOrDefault(x => x.Id == entidadId);
            }
        }

        public int ObtenerSiguientenumero()
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                if (contex.Mesas.Any())
                {
                    return contex.Mesas
                                      .Max(x => x.Numero) + 1;
                }

                else
                {
                    return 1;
                }


            }
        }

        public void CambiarEstado(long id, EstadoMesa estado)
        {

            using (var context = new ModeloXCommerceContainer())
            {
                var mesa = context.Mesas.Find(id);
                mesa.EstadoMesa = estado;
                context.SaveChanges();
            }
        }

        public IEnumerable<MesaDtos> ObtenerPorEstado(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Mesas
                    .AsNoTracking()
                    .Where(x => x.EstadoMesa != EstadoMesa.Reservada)
                    .Select(x =>
                    new MesaDtos
                    {
                        Id = x.Id,
                        Numero = x.Numero,
                        Descripcion = x.Descripcion,
                        EstadoMesa = x.EstadoMesa,
                        EstaEliminado = x.EstaEliminado,
                        SalonId = x.Salon.Id,
                        Salon = x.Salon.Descripcion

                    }).ToList();
            }
        }
    }
}
