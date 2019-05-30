using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core.ServicioKiosco
{
    public class ServicioDetalleFactura
    {
        private static List<DetalleFactura> _DetalleFacturas = new List<DetalleFactura>();
        /*
        public static int ObtenerSiguienteNumeroDeFacturaDetalle()
        {
            return _DetalleFacturas.Any() ? _DetalleFacturas.Max(x => x.CantidadDetalle) + 1 : 1;
        }
        */
        public static DetalleFactura ObetenerFacturaPorCodigo(int id)
        {
            return _DetalleFacturas.FirstOrDefault(x => x.CodigoDeDetalle == id);
        }

        public static void Insertar(DetalleFactura facturadeta)
        {
            var detalle = new DetalleFactura
            {

                CodigoDeDetalle = facturadeta.CodigoDeDetalle,

                Items = facturadeta.Items
            };


            _DetalleFacturas.Add(detalle);
        }
        /*/  
          public static DetalleFactura ObetenerFacturaPorCodigoItem(Item2 id)
          {
          }
          */
        public static DetalleFactura ObetenerFacturaPorCodigoId(int id)
        {
            return _DetalleFacturas.FirstOrDefault(x => x.iD == id);
        }


        public static List<DetalleFactura> ObtenerTodasLasFacturas()
        {
            return _DetalleFacturas.ToList();
        }

        public static void BorrarDetalles()
        {
            _DetalleFacturas = new List<DetalleFactura>();
        }

        public static List<DetalleFactura> ObtenerTodasLasFacturasPorCodigoDeDetalle(int codigo)
        {
            return _DetalleFacturas.Where(x => x.CodigoDeDetalle == codigo).ToList();
        }

        public static List<Item2> ObtenerXXX(DetalleFactura deta)
        {


            return deta.Items.ToList();



        }



        public static int ObtenerSiguienteCodigo()
        {
            // verificar si hay datos en la lista
            if (_DetalleFacturas.Any())
            {
                return _DetalleFacturas.Max(x => x.iD) + 1;
            }

            return 1;
        }

    }
}
