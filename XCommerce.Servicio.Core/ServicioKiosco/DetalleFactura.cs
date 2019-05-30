using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core.ServicioKiosco
{
    public class DetalleFactura
    {
        public DetalleFactura()
        {
            Items = new List<Item2>();
        }

        public int iD { get; set; }

        public int CodigoDeDetalle { get; set; }

        public List<Item2> Items { get; set; }



    }
}
