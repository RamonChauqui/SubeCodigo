using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core._13_Proveedores
{
    public class ProveedoresServicio : IProveedores
    {
        public void Eliminar(long provID)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var provElimianr = context.Proveedores
                    .FirstOrDefault(x => x.Id == provID);

                if (provElimianr == null)
                    throw new Exception("No se encontro el Empleado");

                provElimianr.EstaEliminado = true;


                context.SaveChanges();
            }


        }

        public long Insertar(ProveedoresDtos dtos)
        {
            using (var contex = new  ModeloXCommerceContainer())
            {
                var nuevoproveedor = new AccesoDatos.Proveedor
                {
                    RazonSocial = dtos.RazonSocial,
                    Telefono = dtos.Telefono,
                    Contacto = dtos.Contacto,
                    EstaEliminado = dtos.EstaEliminado,
                    Email = dtos.EMail,
                    /*===============================*/
                    CondicionIvaId = dtos.CondicionIvaId,                                             
                    /*===============================*/
                };
                contex.Proveedores.Add(nuevoproveedor);
                contex.SaveChanges();
                return nuevoproveedor.Id;
            }
        }

        public void Modificar(ProveedoresDtos dto)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                var modificprovv = contex.Proveedores
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (modificprovv == null)
                    throw new Exception("Ocurrio un error al Obtener los proveedores");

                modificprovv.RazonSocial = dto.RazonSocial;
                modificprovv.Telefono = dto.Telefono;
                modificprovv.Email = dto.EMail;
                modificprovv.Contacto = dto.Contacto;
                modificprovv.CondicionIvaId = dto.CondicionIvaId;

            }
            



        }

        /*========================================================================================*/

        public IEnumerable<ProveedoresDtos> Obtener(string cadenaBuscar)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                return contex.Proveedores
                    .AsNoTracking()
                    .Where(x => x.RazonSocial.Contains(cadenaBuscar)
               )
                    .Select(x => new ProveedoresDtos
                    {
                        Id = x.Id,
                        RazonSocial = x.RazonSocial,
                        Contacto = x.Contacto,
                        Telefono = x.Telefono,
                        EMail = x.Email,
                        EstaEliminado = x.EstaEliminado,
                        /*===================================*/
                        CondicionIvaId = x.CondicionIvaId,
                        CondicionIVA = x.CondicionIva.Descripcion
                        
                        /*===================================*/
                    }
                    ).ToList();
            }
        }

        public IEnumerable<ProveedoresDtos> ObtenerCAdena(string cadenaBuscar)
        {

            using (var contex = new ModeloXCommerceContainer())
            {
                return contex.Proveedores
                    .AsNoTracking()
                    .Where(x => x.RazonSocial.Contains(cadenaBuscar))
                    .Select(x => new ProveedoresDtos
                    {
                        Id = x.Id,

                        RazonSocial = x.RazonSocial,

                        Telefono = x.Telefono,

                        EMail = x.Email,

                        CondicionIVA = x.CondicionIva.Descripcion,


                        Contacto = x.Contacto,

                        CondicionIvaId = x.CondicionIvaId,

                        ComprovanteCompra = x.ComprobantesCompras,

                        

                        EstaEliminado = x.EstaEliminado
                    }).ToList();
            }


        }



        public ProveedoresDtos obtenerPorID(long entidadId)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                return contex.Proveedores
                    .AsNoTracking()
                    .Select
                    (x => new ProveedoresDtos
                    {
                        Id = x.Id,
                        Contacto = x.Contacto,
                        RazonSocial = x.RazonSocial,
                        EMail = x.Email,
                        EstaEliminado = x.EstaEliminado,
                        Telefono = x.Telefono,
                        CondicionIvaId = x.CondicionIvaId,

                        CondicionIVA = x.CondicionIva.Descripcion

                    }).FirstOrDefault(x => x.Id == entidadId);
            }            
        }
        
    }
}
