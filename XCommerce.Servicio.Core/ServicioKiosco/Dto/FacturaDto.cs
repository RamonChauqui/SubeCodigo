using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core.ServicioKiosco.Dto
{
    public class FacturaDto
    {

        public FacturaDto()
        {
            Itemss = new List<Item>();
        }

        public int ID { get; set; }

        //public Factura Facture{ get; set; }
        public List<Item> Itemss { get; set; }

    }
}
