using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core.ServicioKiosco
{
    public class Factura
    {
        public Factura()
        {
            Items = new List<Item>();
        }

        public int Numero { get; set; }

        public DateTime Fecha { get; set; }

        // Cliente que Compro
        //public Cliente Cliente { get; set; }

        //public string Cliente_Comprador
        //{
        //    get { return Cliente.Nombre; }
        //}
     

        public decimal Total { get; set; }

        public decimal TotalConfig { get; set; }
        public decimal SubTotal
        {
            get { return Items.Sum(x => x.SubTotal); }
        }

        public decimal Descuento { get; set; }

        public List<Item> Items { get; set; }

       

        /*========================================*/

        //public decimal ValorInicial { get; set; }

        /*========================================*/

    }
}
