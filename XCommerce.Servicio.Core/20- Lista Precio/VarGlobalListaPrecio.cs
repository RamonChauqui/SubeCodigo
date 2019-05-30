using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core._20__Lista_Precio
{
    public class VarGlobalListaPrecio
    {

        public void ListaPrecio()
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                if (!contex.ListaPrecios.Any())
                {
                    contex.ListaPrecios.Add(new AccesoDatos.ListaPrecio()
                    {
                        Descripcion = "Lista Barra",
                        EstaEliminado = false,
                        Rentabilidad = 1,
                    }
                       );



                    contex.ListaPrecios.Add(new ListaPrecio()
                    {
                        Descripcion = "Lista Salon",
                        EstaEliminado = false,
                        Rentabilidad = 1,


                    }
                    );

                    contex.ListaPrecios.Add(new ListaPrecio()
                    {
                        Descripcion = "Lista Kiosko",
                        EstaEliminado = false,
                        Rentabilidad = 1,


                    }
                    );


                }

                contex.SaveChanges();
            }
        }
    }
}
