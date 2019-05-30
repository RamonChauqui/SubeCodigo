using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Core._15_Tarjetas
{
    public class VarGlobarTarjeta
    {
        public void IniciarTarjeta()
        {
            using (var contex = new ModeloXCommerceContainer())
            {
                if (!contex.TarjetaSet.Any())
                {
                    contex.TarjetaSet.Add(new Tarjeta()
                    {
                        Descripcion = "Visa",
                        EstaEliminado = false,

                    });

                    contex.TarjetaSet.Add(new Tarjeta()
                    {

                        Descripcion = "Master Card",
                        EstaEliminado = false,
                    });
                    contex.SaveChanges();
                }

                contex.SaveChanges();
            }
        }
    }
}
