using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core._06_Rubro
{
    public class VarGlobarRubro
    {
        public void Iniciar()
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                if (!contex.Rubros.Any())
                {
                    contex.Rubros.Add(new AccesoDatos.Rubro { Descripcion = "Golosinas", EstaEliminado = false });

                }

                if (!contex.Rubros.Any())
                {
                    contex.Rubros.Add(new AccesoDatos.Rubro { Descripcion = "Bebidas", EstaEliminado = false });

                }

                if (!contex.Rubros.Any())
                {
                    contex.Rubros.Add(new AccesoDatos.Rubro { Descripcion = "Menu Diario", EstaEliminado = false });

                }
                contex.SaveChanges();
            }



        }


    }
}
