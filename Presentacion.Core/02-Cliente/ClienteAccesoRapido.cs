using Presentacion.FormularioBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.Servicio.Core.Cliente;

namespace Presentacion.Core._02_Cliente
{
    public partial class ClienteAccesoRapido : FormularioLookUp
    {
        private IClienteServicio _clienteServicio;

        public ClienteAccesoRapido()
        {
            _clienteServicio = new ClienteServicio();

            InitializeComponent();
        }

        private void ClienteAccesoRapido_Load(object sender, EventArgs e)
        {
            
        }
        public override void ActualizarDatos(string cadenaBuscar)
        {

            var clientes = _clienteServicio.Obtener(cadenaBuscar);
            dgvGrilla.DataSource = clientes.ToList();
        }

        private void btnBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ActualizarDatos(txtBuscar.Text);
            }
        }

        private void btnBuscar_TextChanged(object sender, EventArgs e)
        {
            ActualizarDatos(txtBuscar.Text);

        }
    }
}
