using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core._02_Cliente
{
   public  class VarGlobalCliente
    {
        public void Iniciar()
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                if (!contex.Personas.OfType<AccesoDatos.Cliente>().Any())
                {
                    contex.Personas.Add(new AccesoDatos.Cliente { Nombre = "Consumidor", Apellido = "Final", Celular= "99999999", Cuil ="99999999", Dni ="9",Email = "999999999" , Telefono = "99999999", EstaEliminado = false });

                }

                contex.SaveChanges();
            }

        }

    }
}
