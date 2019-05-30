using Presentacion.Core._12_CondicionIVA;
using Presentacion.FormularioBase;
using Presentacion.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.Servicio.Core._12_CondicionIVA;
using XCommerce.Servicio.Core._13_Proveedores;

namespace Presentacion.Core._13_Proveedores
{
    public partial class _00022_ABM_Proveedores : FormularioAbm
    {
        private readonly IProveedores _proveedores;

        private readonly ICondicionIVASServicvios _condicionIVASServicvios;

        public _00022_ABM_Proveedores(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
            _proveedores = new ProveedoresServicio();
            _condicionIVASServicvios = new CondicionIIVAServicios();

            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                DesactivarControles(this);


            }
            AgregarControlesObligatorios(txtRazoSocial, "Razon Social");
            AgregarControlesObligatorios(txtContacto, "Contacto");
            AgregarControlesObligatorios(txtEMail, "EMail");

            Inicializador(entidadId);

        }
        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            CargarComboBox(cmbCondIVA, _condicionIVASServicvios.obtener(string.Empty), "Descripcion", "Id");


            txtRazoSocial.Focus();
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevPrveedor = new ProveedoresDtos
            {
                RazonSocial = txtRazoSocial.Text,
                Telefono = txtTelefono.Text,
                Contacto = txtContacto.Text,            
                EMail = txtEMail.Text,
               
                CondicionIvaId = ((CondicionIIVADTOs)cmbCondIVA.SelectedItem).Id,
               
            };

            _proveedores.Insertar(nuevPrveedor);

            return true;
        }
        public override void CargarDatos(long? entidadId)
        {
            if (!entidadId.HasValue)
            {
                MessageBox.Show(@"Ocurrio un Error Grave", @"Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                this.Close();
            }

            if (TipoOperacion == TipoOperacion.Eliminar)
            {
                btnLimpiar.Enabled = false;
            }

            var provv = _proveedores.obtenerPorID(entidadId.Value);

            txtRazoSocial.Text = provv.RazonSocial;
            txtTelefono.Text = provv.Telefono;
            txtContacto.Text = provv.Contacto;
            txtEMail.Text = provv.EMail;
            CargarComboBox(cmbCondIVA, _condicionIVASServicvios.obtener(string.Empty), "Descripcion", "Id");

            cmbCondIVA.SelectedItem = provv.Id;
        }
        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _proveedores.Eliminar(EntidadId.Value);

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var fNuevaProvincia = new _00021_ABM_CondicionIva(TipoOperacion.Nuevo);
            fNuevaProvincia.ShowDialog();

            if (!fNuevaProvincia.RealizoAlgunaOperacion) return;

            CargarComboBox(cmbCondIVA, _condicionIVASServicvios.obtener(string.Empty), "Descripcion", "Id");


        }

        public override bool EjecutarComandoModificar()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var provmodific = new ProveedoresDtos
            {
                Id = EntidadId.Value,
                RazonSocial = txtRazoSocial.Text,
                Telefono = txtTelefono.Text,
                Contacto = txtContacto.Text,
                EMail = txtEMail.Text,
                
                CondicionIvaId = ((CondicionIIVADTOs)cmbCondIVA.SelectedItem).Id
            };

            _proveedores.Modificar(provmodific);

            return true;
        }
    }
}
