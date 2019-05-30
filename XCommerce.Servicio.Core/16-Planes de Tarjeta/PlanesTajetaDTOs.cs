using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.Servicio.Core.Base;

namespace XCommerce.Servicio.Core._16_Planes_de_Yarjeta
{
    public class PlanesTajetaDTOs : BaseDto
    {
        public string Descripcion { get; set; }

        public decimal Alicuota { get; set; }

        public long TarjetaID { get; set; }

        public string Tarjeta { get; set; }




    }
}
