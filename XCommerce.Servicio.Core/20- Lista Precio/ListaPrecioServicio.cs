using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core._20__Lista_Precio
{
   public  class ListaPrecioServicio : IListaPrecioServicio
    {
        public void Crear(ListaPrecioDto dto)
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                var nuevalista = new ListaPrecio
                {
                    Descripcion = dto.Descripcion,
                    EstaEliminado = dto.EstaEliminado,
                

                };
                contex.ListaPrecios.Add(nuevalista);
                contex.SaveChanges();
            }     
        }

        public void Elimiar(long marcaID)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var rubroEliminar = context.ListaPrecios
                    .FirstOrDefault(x => x.Id == marcaID);

                if (rubroEliminar == null)
                    throw new Exception("Ocurrio un error al Obtener la lista");

                rubroEliminar.EstaEliminado = true;

                context.SaveChanges();
            }


        }

        public void Modificar(ListaPrecioDto dto)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var rubroModificar = context.ListaPrecios
                    .FirstOrDefault(x => x.Id == dto.Id);

                if (rubroModificar == null)
                    throw new Exception("Ocurrio un error al Obtener la Provincia");

                rubroModificar.Descripcion = dto.Descripcion;
                

                context.SaveChanges();
            }
        }


        public ListaPrecioDto ObtenerPorId(long Id)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                return context.ListaPrecios
                    .AsNoTracking()
                    .Select(x => new ListaPrecioDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado,
                

                    }).FirstOrDefault(x => x.Id == Id); 
             
            }
        }

    
            


        public IEnumerable<ListaPrecioDto> obtner(string cadenaBuscar)
        {
            using (var contex = new ModeloXCommerceContainer())
            {

                return contex.ListaPrecios
                    .AsNoTracking()
                    .Where(x => x.Descripcion.Contains(cadenaBuscar))
                    .Select
                    (
                    x => new ListaPrecioDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado,                      
                        
                        

                    }

                    ).ToList();

            }
        }
    }
}
