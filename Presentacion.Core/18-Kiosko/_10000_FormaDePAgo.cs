using Presentacion.Core._02_Cliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.Servicio.Core._22_ComprobanteSalon;
using XCommerce.Servicio.Core._23_ComporbanteKiosco;
using XCommerce.Servicio.Core.Cliente;
using XCommerce.Servicio.Core.Cliente.DTOs;
using XCommerce.Servicio.Core.ServicioKiosco;

namespace Presentacion.Core._18_Kiosko
{
    public partial class _10000_FormaDePAgo : Presentacion.FormularioBase.FormularioBase
    {
        public bool RealizoOperacion;
        public long _ClienteId;
        public long _mesaId;
        private Factura _factura;

        private readonly IComprobanteKiosco _comprobanteKiosco;
        private readonly IClienteServicio _clienteServicio;
        private readonly IComprobanteSalon _comprobanteSalon;


        public _10000_FormaDePAgo(Factura factura)
            : this(new ComprobanteSalon(), new ClienteServicio() )
        {
            InitializeComponent();
            _factura = factura;
            RealizoOperacion = false;

        }
        public _10000_FormaDePAgo(IComprobanteSalon comprobanteSalon, IClienteServicio clienteServicio)
        {
            _comprobanteSalon = comprobanteSalon;
            _clienteServicio = clienteServicio;               
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (chekEfectivo.Checked == true)
            {
                chkCtaCte.Checked = false;

                _comprobanteSalon.CrearComprobante(_factura,_ClienteId);
                RealizoOperacion = true;
            }

            if (chkCtaCte.Checked == true)
            {


                MessageBox.Show("Se realizo el pago con cuenta corriente");


                RealizoOperacion = true;

            }
            else
            {
                MessageBox.Show("Se realizo el pago en Efectivo");
                Close();









                RealizoOperacion = true;


            }


        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            var lokCliente = new ClienteAccesoRapido();

            lokCliente.ShowDialog();

            if (lokCliente.Entidad != null)
            {

                var ClienteSeleccionado = (ClienteDto)lokCliente.Entidad;
                _ClienteId = ClienteSeleccionado.Id;

                //var comprobante = _comprobanteKiosco.ObtenerComprobantePorMesa(_mesaId);
                //_comprobanteKiosco.AgregarCliente(_mesaId, _ClienteId);

                txtCliente.Text = ClienteSeleccionado.Apellido + "" + ClienteSeleccionado.Nombre;
                

            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
        //    var comprobante = _comprobanteSalon.ObtenerComprobantePorMesa(_mesaId);
        //    if (comprobante.Total == 0)
        //    {
        //        Close();
        //    }
        //    else
        //    {
        //        DialogResult dialogResult = MessageBox.Show("Esta seguro de Cancelar ", "Cancelar", MessageBoxButtons.YesNo);
        //        if (dialogResult == DialogResult.Yes)
        //        {
        //            Close();
        //        }
        //        else if (dialogResult == DialogResult.No)
        //        {
        //            Close();
        //        }
        //    }

        }

        private void _10000_FormaDePAgo_Load(object sender, EventArgs e)
        {
            txtTotal.Text = _factura.Total.ToString();
        }
    }
}
