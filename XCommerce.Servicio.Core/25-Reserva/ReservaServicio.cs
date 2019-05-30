using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core._25_Reserva
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using AccesoDatos;
    using DTOs;

    public class ReservaServicio : IReservaServicio
    {
        public void CambiarEstado(long id, EstadoReserva estado)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var reserva = context.Reservas.Find(id);
                reserva.EstadoReserva = estado;
                context.SaveChanges();
            }
        }


        public void Eliminar(long reservaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var reservaEliminar = context.Reservas.OfType<AccesoDatos.Reserva>()
                    .FirstOrDefault(x => x.Id == reservaId);
                if (reservaEliminar == null)
                    throw new Exception(@"Ocurrio un Error al Obtener la Reserva");
                reservaEliminar.EstaEliminado = true;
                context.SaveChanges();
            }

        }

        public long Insertar(ReservaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevaReserva = new AccesoDatos.Reserva
                {
                    Id = dto.Id,
                    Fecha = dto.Fecha,
                    Senia = dto.Senia,
                    EstadoReserva = EstadoReserva.Confirmada,
                    MesaId = dto.MesaId,
                    UsuarioId = dto.UsuarioId,
                    ClienteId = dto.ClienteId,
                    MotivoReservaId = dto.MotivoReservaId,
                    EstaEliminado = dto.EstaEliminado
                };
                context.Reservas.Add(nuevaReserva);
                context.SaveChanges();
                return nuevaReserva.Id;
            }
        }




        public void Modificar(ReservaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var reservaModificar = context.Reservas.OfType<AccesoDatos.Reserva>()
                    .FirstOrDefault(x => x.Id == dto.Id);
                if (reservaModificar == null)
                    throw new Exception(@"Ocurrio un Error al Obtener la Reserva");

                reservaModificar.Id = dto.Id;
                reservaModificar.Fecha = dto.Fecha;
                reservaModificar.Senia = dto.Senia;
                reservaModificar.EstadoReserva = dto.EstadoReserva;
                reservaModificar.MesaId = dto.MesaId;
                reservaModificar.UsuarioId = dto.UsuarioId;
                reservaModificar.ClienteId = dto.ClienteId;
                reservaModificar.MotivoReservaId = dto.MotivoReservaId;
                reservaModificar.EstaEliminado = dto.EstaEliminado;

                context.SaveChanges();
            }
        }

        public IEnumerable<ReservaDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Reservas
                    .AsNoTracking()
                    .Include(x => x.Mesa)
                    .Include(x => x.Cliente)
                    .Include(x => x.Usuario)
                    .Include(x => x.MotivoReserva)
                    //.Where(x => x.MotivoReserva.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new ReservaDto
                    {
                        Fecha = x.Fecha,
                        Senia = x.Senia,
                        EstadoReserva = x.EstadoReserva,
                        MesaId = x.Mesa.Id,
                        UsuarioId = x.Usuario.Id,
                        ClienteId = x.Cliente.Id,
                        MotivoReservaId = x.MotivoReserva.Id,
                        EstaEliminado = x.EstaEliminado


                    }).ToList();
            }
        }

        public IEnumerable<ReservaDto> ObtenerMesasParaReserva()
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Reservas.AsNoTracking()
                    .Select(x => new ReservaDto
                    {
                        Fecha = x.Fecha,
                        Senia = x.Senia,
                        MesaId = x.Mesa.Id,
                        UsuarioId = x.Usuario.Id,
                        ClienteId = x.Cliente.Id,
                        EstaEliminado = x.EstaEliminado,
                        MotivoReservaId = x.MotivoReserva.Id,
                        EstadoReserva = EstadoReserva.Cancelada

                    }).ToList();
            }
        }

        public ReservaDto ObtenerPorId(long entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.Reservas
                    .AsNoTracking()
                    .Include(x => x.Mesa)
                    .Include(x => x.Cliente)
                    .Include(x => x.Usuario)
                    .Include(x => x.EstadoReserva)
                    .Select(x => new ReservaDto
                    {
                        Id = x.Id,
                        Fecha = x.Fecha,
                        Senia = x.Senia,
                        EstadoReserva = x.EstadoReserva,
                        MesaId = x.Mesa.Id,
                        UsuarioId = x.Usuario.Id,
                        ClienteId = x.Cliente.Id,
                        MotivoReservaId = x.MotivoReserva.Id,
                        EstaEliminado = x.EstaEliminado

                    }).FirstOrDefault(x => x.Id == entidadId);
            }
        }

        public void ReservarMesa(long clienteId, long mesaId, int comensales)
        {

            using (var context = new ModeloXCommerceContainer())
            {
                var mesaSeleccionada = context.Reservas
                    .FirstOrDefault(x => x.Id == mesaId);
                if (mesaSeleccionada == null)
                    throw new Exception(@"Ocurrio un Error al Obtener la Mesa");
                mesaSeleccionada.EstadoReserva = EstadoReserva.Confirmada;

            }
        }
    }
}
