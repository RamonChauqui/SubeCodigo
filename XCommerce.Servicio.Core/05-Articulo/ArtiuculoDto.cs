using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core.Articulo
{
    public class ArtiuculoDto : BaseDto
    { 
        public string Codigo { get; set; }
        public string CodigoBarra { get; set; }
        public string Abreviatura { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
        public decimal PrecioPublico { get; set; }//
        public byte[] Foto { get; set; }
        public bool ActivarLimiteDeVenta { get; set; }
        public decimal LimiteDeVenta { get; set; }
        public bool PermitirStokNegativo { get; set; }
        public bool EstaDiscontinuado { get; set; }
        public decimal StockMaximo { get; set; }
        public decimal StockMinimo { get; set; }
        public bool DescuentaStock { get; set; }
        public decimal Stock { get; set; }
        /*==============DATOS MARCA Y  RUBRO=============*/

        public long MarcaId { get; set; }
        public string Marca { get; set; }

        public long RubroId { get; set; }
        public string Rubro { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
