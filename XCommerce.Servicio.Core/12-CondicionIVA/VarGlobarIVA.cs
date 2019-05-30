using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core._12_CondicionIVA
{
    public class VarGlobarIVA
    {
        public void inicializarIVA()
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                if (!contex.CondicionIvas.Any())
                {
                    contex.CondicionIvas.Add(

                        new CondicionIva()
                        {
                            Descripcion = "IVA Responsable Inscripto",
                            EstaElminado = false,
                        }
                       );

                    contex.CondicionIvas.Add(

                        new CondicionIva()
                        {
                            Descripcion = "IVA Responsable no Inscripto",
                            EstaElminado = false,
                        }
                       );

                    contex.CondicionIvas.Add(

                       new CondicionIva()
                       {
                           Descripcion = "Consumidor Final",
                           EstaElminado = false,
                       }
                      );

                    contex.CondicionIvas.Add(

                      new CondicionIva()
                      {
                          Descripcion = "Responsable Monotributo",
                          EstaElminado = false,
                      }
                     );

                    contex.CondicionIvas.Add(

                   new CondicionIva()
                   {
                       Descripcion = "Sujeto no Categorizado",
                       EstaElminado = false,
                   }
                  );
                    contex.SaveChanges();
                }

                contex.SaveChanges();
            }


        }
    }
}
