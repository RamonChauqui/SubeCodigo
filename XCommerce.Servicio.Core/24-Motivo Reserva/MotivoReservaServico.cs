using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core._24_Motivo_Reserva
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AccesoDatos;
    using DTOs;

    public class MotivoReservaServico : IMotivoReservaServicio
    {
        public void Eliminar(long motivoReservaId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var motivoReservaEliminar = context.MotivoReservas.OfType<MotivoReserva>()
                    .FirstOrDefault(x => x.Id == motivoReservaId);
                if (motivoReservaEliminar == null)
                    throw new Exception(@"Se produjo un Error al Obtener el Motivo de Reserva");
                //motivoReservaEliminar.EstaEliminado = true;
                //context.SaveChanges();
            }
        }

        public long Insertar(MotivoReservaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var nuevoMotivoReserva = new MotivoReserva
                {
                    Id = dto.Id,
                    Descripcion = dto.Descripcion
                };
                context.MotivoReservas.Add(nuevoMotivoReserva);
                context.SaveChanges();
                return nuevoMotivoReserva.Id;
            }
        }

        public void Modificar(MotivoReservaDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var motivoReservaModificar = context.MotivoReservas.OfType<MotivoReserva>()
                    .FirstOrDefault(x => x.Id == dto.Id);
                if (motivoReservaModificar == null)
                    throw new Exception(@"Ocurrio un error al Obtener el Motivo de Reserva");

                motivoReservaModificar.Id = dto.Id;
                motivoReservaModificar.Descripcion = dto.Descripcion;

                context.SaveChanges();
            }
        }

        public IEnumerable<MotivoReservaDto> Obtener(string cadenaBuscar)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.MotivoReservas
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenaBuscar))
                    .Select(x => new MotivoReservaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion
                    }).ToList();
            }
        }

        public MotivoReservaDto ObtenerPorId(long entidadId)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.MotivoReservas
                    .AsNoTracking()
                    .Select(x => new MotivoReservaDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion
                    }).FirstOrDefault(x => x.Id == entidadId);
            }
        }
    }
}
