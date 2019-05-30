using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core._04_Localidad
{
    class VarGlobalLocalidad
    {
        public void Iniciar()
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                if (!contex.Localidades.Any())
                {
                    contex.Localidades.Add(new AccesoDatos.Localidad { Descripcion = "San miguel", EstaEliminado = false, });

                }
                if (!contex.Localidades.Any())
                {
                    contex.Localidades.Add(new AccesoDatos.Localidad { Descripcion = "Cafayate", EstaEliminado = false, });

                }
                if (!contex.Localidades.Any())
                {
                    contex.Localidades.Add(new AccesoDatos.Localidad { Descripcion = "Perico", EstaEliminado = false, });

                }
                if (!contex.Localidades.Any())
                {
                    contex.Localidades.Add(new AccesoDatos.Localidad { Descripcion = "Rosario", EstaEliminado = false, });

                }
                if (!contex.Localidades.Any())
                {
                    contex.Localidades.Add(new AccesoDatos.Localidad { Descripcion = "Lomas ", EstaEliminado = false, });

                }

                contex.SaveChanges();
            }



        }
    }
}
