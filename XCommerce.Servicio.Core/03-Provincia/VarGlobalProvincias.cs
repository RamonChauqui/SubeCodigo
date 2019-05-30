using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core._03_Provincia
{
   public  class VarGlobalProvincias
    {
        public void Iniciar()
        {
    using (var contex = new ModeloXCommerceContainer())
            {
                if (!contex.Provincias.Any())
                {
                    contex.Provincias.Add(new AccesoDatos.Provincia { Descripcion = "Tucuman", EstaEliminado = false, Id = 1 });

                }
                if (!contex.Provincias.Any())
                {
                    contex.Provincias.Add(new AccesoDatos.Provincia { Descripcion = "Salta", EstaEliminado = false, });

                }
                if (!contex.Provincias.Any())
                {
                    contex.Provincias.Add(new AccesoDatos.Provincia { Descripcion = "Jujuy", EstaEliminado = false, });

                }
                if (!contex.Provincias.Any())
                {
                    contex.Provincias.Add(new AccesoDatos.Provincia { Descripcion = "BSAS", EstaEliminado = false, });

                }
                if (!contex.Provincias.Any())
                {
                    contex.Provincias.Add(new AccesoDatos.Provincia { Descripcion = "Formosa", EstaEliminado = false, });

                }

                contex.SaveChanges();
            }



        }
   


    }
}
