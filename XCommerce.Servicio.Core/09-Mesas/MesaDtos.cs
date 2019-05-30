using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Base;
using XCommerce.Servicio.Core.Sala;

namespace XCommerce.Servicio.Core.Mesas
{
    public class MesaDtos : BaseDto
    {

        public int Numero { get; set; }

        public string Descripcion { get; set; }

        public long SalonId { get; set; }

        public string Salon { get; set; }

        public EstadoMesa EstadoMesa { get; set; }

        public decimal Total => SalaServicio.ObtenerTotalVenta(Id);


        public string SAlonstr => SalonId.ToString();

        public long ComprobanteId { get; set; }

        /*====================SALON================================*/



    }
}
