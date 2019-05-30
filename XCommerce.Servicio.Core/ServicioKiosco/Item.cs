using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Articulo;

namespace XCommerce.Servicio.Core.ServicioKiosco
{
    public class Item
    {
        //Propieades
        public ArtiuculoDto Producto { get; set; }

        public string Codigo
        {
            get { return Producto.Codigo; }
        }
        public string CodigoBarra
        {
            get { return Producto.CodigoBarra; }
        }
        public string Descripcion
        {
            get { return Producto.Descripcion; }
        }
        public decimal Precio { get; set; }

        public int Cantidad { get; set; }

        public decimal SubTotal
        {
            get { return Cantidad * Precio; }
        }
    }
}
