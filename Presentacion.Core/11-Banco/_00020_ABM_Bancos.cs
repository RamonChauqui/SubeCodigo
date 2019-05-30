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
using XCommerce.Servicio.Core.Bancos;

namespace Presentacion.Core._11_Banco
{
    public partial class _00020_ABM_Bancos : FormularioAbm
    {
        private readonly IBancosServicios _bancoServicio;

        public _00020_ABM_Bancos(TipoOperacion tipoOperacion, long? entidadId = null)
            : base (tipoOperacion,entidadId)
        {
            InitializeComponent();

            _bancoServicio = new BancosServicios();

            AgregarControlesObligatorios(txtDescripcion, "Descripción");
            Inicializador(entidadId);


            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                DesactivarControles(this);
            }

        }
        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;


            txtDescripcion.KeyPress += Validacion.NoNumeros;

            txtDescripcion.Focus();
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

            var provincia = _bancoServicio.obtenerPorID(entidadId.Value);

            // Datos Personales
            txtDescripcion.Text = provincia.Descripcion;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevaProvincia = new BancosDtos
            {
                Descripcion = txtDescripcion.Text,
            };

            _bancoServicio.Insertar(nuevaProvincia);

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

            var provinciaParaModificar = new BancosDtos
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text
            };

            _bancoServicio.Modificar(provinciaParaModificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _bancoServicio.Eliminar(EntidadId.Value);

            return true;
        }





    }
}
