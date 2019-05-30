using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core._08_Sala
{
    public class VarGlobalSalas
    {
        public void Inicial()
        {
            using (var contex = new ModeloXCommerceContainer())
            {

                if (!contex.Salones.Any())
                {
                    contex.Salones.Add(new Salon { Descripcion = "Sala Principal", EstaEliminado = false });
                

                }

                if (!contex.Salones.Any())
                {
                    contex.Salones.Add(new Salon { Descripcion = "Sala Lateral", EstaEliminado = false });
            

                }

                if (!contex.Salones.Any())
                {
                    contex.Salones.Add(new Salon { Descripcion = "Sala Barra", EstaEliminado = false });
                  

                }
                contex.SaveChanges();

            }


        }
    }
}
