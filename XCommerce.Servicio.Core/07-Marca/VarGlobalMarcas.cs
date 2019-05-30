using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core._07_Marca
{
   public  class VarGlobalMarcas
    {
        public void Iniciar()
        {

            using (var contex = new ModeloXCommerceContainer())
            {
                if (!contex.Marcas.Any())
                {
                    contex.Marcas.Add(new AccesoDatos.Marca { Descripcion = "Arcor", EstaEliminado = false });

                }
                if (!contex.Marcas.Any())
                {
                    contex.Marcas.Add(new AccesoDatos.Marca { Descripcion = "Pepsi", EstaEliminado = false });

                }
                if (!contex.Marcas.Any())
                {
                    contex.Marcas.Add(new AccesoDatos.Marca { Descripcion = "Light", EstaEliminado = false });

                }
                if (!contex.Marcas.Any())
                {
                    contex.Marcas.Add(new AccesoDatos.Marca { Descripcion = "Coca-Cola", EstaEliminado = false });

                }
                contex.SaveChanges();
            }
        }

    }
}
