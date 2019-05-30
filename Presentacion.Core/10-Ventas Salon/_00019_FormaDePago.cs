using Presentacion.Core._02_Cliente;
using Presentacion.Core._10_Ventas_Salon.Contoles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core._00_Base;
using XCommerce.Servicio.Core._17_Caja;
using XCommerce.Servicio.Core._22_ComprobanteSalon;
using XCommerce.Servicio.Core._22_ComprobanteSalon.Dtos;
using XCommerce.Servicio.Core.Cliente;
using XCommerce.Servicio.Core.Cliente.DTOs;

namespace Presentacion.Core._10_Ventas_Salon
{
    public partial class _00019_FormaDePago :Presentacion.FormularioBase.FormularioBase
    {

        public bool realizoOperacion;
        private long _clienteId;
        private long _mesaId;

        private readonly IComprobanteSalon _comprobanteSalon;
        private readonly IClienteServicio _clienteServicio;
        private readonly ICajaSalon _cajaSalon;


        private ComprobanteSalonDto _comprobante;


        public _00019_FormaDePago(long mesaId)
            :this(new XCommerce.Servicio.Core._22_ComprobanteSalon.ComprobanteSalon(), new ClienteServicio(), new CajaSalon())
        {
            InitializeComponent();
            _mesaId = mesaId;
            realizoOperacion= false;
        }

        public _00019_FormaDePago(IComprobanteSalon comprobanteSalon, IClienteServicio clienteServicio,ICajaSalon cajaSalon)
        {
            _comprobanteSalon = comprobanteSalon;
            _clienteServicio = clienteServicio;
            _cajaSalon = cajaSalon;
        }



        private void btnCliente_Click(object sender, EventArgs e)
        {
            var lookUpProducto = new ClienteAccesoRapido();
            lookUpProducto.ShowDialog();
            if (lookUpProducto.Entidad != null)
            {

                var ClienteSeleccionado = (ClienteDto)lookUpProducto.Entidad;
                _clienteId = ClienteSeleccionado.Id;

                var comprobante = _comprobanteSalon.ObtenerComprobantePorMesa(_mesaId);
                _comprobanteSalon.AgregarCliente(_mesaId, _clienteId);

                txtCliente.Text = ClienteSeleccionado.Apellido + "" + ClienteSeleccionado.Nombre;
          
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();

            var comprobante = _comprobanteSalon.ObtenerComprobantePorMesa(_mesaId);
            if (comprobante.Total == 0)
            {
                Close();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Esta seguro de Cancelar ", "Cancelar", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Close();
                }
            }

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            if (chekEfectivo.Checked == true)
            {
                chkCtaCte.Checked = false;
            }
                     


            if (chkCtaCte.Checked == true)
            {

                
                MessageBox.Show("Se realizo el pago con cuenta corriente");

          
                realizoOperacion = true;

            }
            else
            {
                MessageBox.Show("Se realizo el pago en Efectivo");
                Close();
     
                var caja = _cajaSalon.ObtenerComprobantePorEstado(EstadoCaja.Abierto);
                var comprobante = _comprobanteSalon.ObtenerComprobantePorMesa(_mesaId);


                _cajaSalon.AgregarMonto(comprobante.Total, caja.Id);

                _comprobanteSalon.QuitarComprobante(_mesaId);


                realizoOperacion = true;
                

            }

        }

        private void chkCtaCte_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCtaCte.Checked == true)
            {
                chekEfectivo.Checked = false;

            }
        }

        private void chekEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            if (chekEfectivo.Checked == true)
            {
                chkCtaCte.Checked = false;

            }

        }

        private void _00019_FormaDePago_Load(object sender, EventArgs e)
        {
            var comprobante = _comprobanteSalon.ObtenerComprobantePorMesa(_mesaId);
            txtTotal.Text = $" $ {comprobante.Total.ToString()}   "; 

        }
    }
}
