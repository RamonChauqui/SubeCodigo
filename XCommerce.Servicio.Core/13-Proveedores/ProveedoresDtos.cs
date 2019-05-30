using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core._13_Proveedores
{
    public class ProveedoresDtos : BaseDto
    {
        public string RazonSocial { get; set; }

        public string Telefono { get; set; }

        public string EMail { get; set; }

        public string Contacto { get; set; }

        /*=================CMBcONIVA=========================*/

        public long CondicionIvaId { get; set; }
        public string CondicionIVA { get; set; }


        public ICollection<ComprobanteCompra> ComprovanteCompra { get; set; }

    }
}
