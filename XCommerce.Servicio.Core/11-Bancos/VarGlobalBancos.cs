using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core._11_Bancos
{
    public class VarGlobalBancos
    {
        public void Inicial()
        {
            using (var contex = new ModeloXCommerceContainer())
            {

                if (!contex.Bancos.Any())
                {
                    contex.Bancos.Add(

                        new Banco()
                        {
                            Descripcion = " Banco Macro",
                            EstaEliminado = false,

                        }                      
                    
                        );

                    contex.Bancos.Add(

                       new Banco()
                       {
                           Descripcion = "Banco Nacion",
                           EstaEliminado = false,

                       }

                       );

                    contex.Bancos.Add(

                       new Banco()
                       {
                           Descripcion = "Banco Patagonia",
                           EstaEliminado = false,

                       }

                       );
                }


                contex.SaveChanges();
            }            

        }
    }
}
