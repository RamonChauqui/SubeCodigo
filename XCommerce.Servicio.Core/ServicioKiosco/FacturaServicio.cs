using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Core.ServicioKiosco
{
    public class FacturaServicio
    {
        private static List<Factura> facturas = new List<Factura>();

        public static int ObtenerSiguienteNumeroDeFactura()
        {
            return facturas.Any() ? facturas.Max(x => x.Numero) + 1 : 1;
        }

        public static Factura ObetenerFacturaPorCodigo(int codigo)
        {
            return facturas.FirstOrDefault(x => x.Numero == codigo);
        }

        public static void BorrarFacturas()
        {
            facturas = new List<Factura>();
        }

        public static void Insertar(Factura factura)
        {
            facturas.Add(factura);

            //var nuevoMovimiento = new Movimiento
            //{
            //    Cliente = factura.Cliente,
            //    Empleado = factura.Empleado,
            //    Fecha = factura.Fecha,
            //    Monto = factura.Total,
            //    TipoMovimiento = TipoMovimiento.Egreso
            //};

            //MovimientoServicio.Insertar(nuevoMovimiento);
        }

        public static List<Factura> ObtenerTodasLasFacturas()
        {
            return facturas.ToList();
        }

        //public static List<Factura> ObtenerFacturasPorCliente(Cliente cliente)
        //{
        //    return facturas.Where(x => x.Cliente == cliente).ToList();
        //}
    }
}
