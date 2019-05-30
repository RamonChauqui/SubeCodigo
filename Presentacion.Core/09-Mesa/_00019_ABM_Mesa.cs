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
using XCommerce.Servicio.Core.Mesas;
using XCommerce.Servicio.Core.Sala;

namespace Presentacion.Core._9_Mesa
{
    public partial class _00019_ABM_Mesa : FormularioAbm
    {
        private readonly ISalaServicio _salalServicio;
        private readonly IMesaServicio _mesaServicio;

        public _00019_ABM_Mesa(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _salalServicio = new SalaServicio();
            _mesaServicio = new MesaServicio();
            Inicializador(entidadId);


            if (tipoOperacion == TipoOperacion.Eliminar || tipoOperacion == TipoOperacion.Modificar)
            {
                CargarDatos(entidadId);
            }

            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);

           AgregarControlesObligatorios(txtDescripcion, "Descripción");

        }
        public override void Inicializador(long? entidadId)
        {
            CargarComboBox(cmbSala, _salalServicio.ObtenerCMB(string.Empty), "Descripcion", "Id");
            txtDescripcion.KeyPress += Validacion.NoSimbolos;

            txtDescripcion.Focus();
            nudNumero.Value = _mesaServicio.ObtenerSiguientenumero();

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

            var sala = _salalServicio.ObtenerPorID(entidadId.Value); var mesa = _mesaServicio.ObtenerPorID(entidadId.Value);

            nudNumero.Value = mesa.Numero;
            txtDescripcion.Text = mesa.Descripcion;
     
            CargarComboBox(cmbSala, _salalServicio.ObtenerCAdena(string.Empty), "Descripcion", "Id");
       cmbSala.SelectedItem = sala.Id;

        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevamesa = new MesaDtos
            {
                Numero = (int)nudNumero.Value,
                Descripcion = txtDescripcion.Text,
                SalonId = ((SalaDto)cmbSala.SelectedItem).Id
            };
            _mesaServicio.insertar(nuevamesa);
            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _mesaServicio.Eliminar(EntidadId.Value);

            return true;
        }
        public override bool EjecutarComandoModificar()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var mesamodific = new MesaDtos
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text,
               SalonId = ((SalaDto)cmbSala.SelectedItem).Id,
            };
            _mesaServicio.Modificar(mesamodific);
            return true;
        }

        public override void EjecutarComando()
        {
            base.EjecutarComando();

            if (TipoOperacion == TipoOperacion.Nuevo)
                nudNumero.Value = _mesaServicio.ObtenerSiguientenumero();
        }    
        

    }
}
