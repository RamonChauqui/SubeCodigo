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
using XCommerce.Servicio.Core.Rubro;

namespace Presentacion.Core._6_Rubros
{

    public partial class _00010_ABM_Rubros : FormularioAbm
    {
        private readonly IRubroServicio _rubroServicio;

        public _00010_ABM_Rubros(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
            _rubroServicio = new RubroServicio();
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

            Inicializador(entidadId);
        }
        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            // Asignando un Evento
            txtDescripcion.KeyPress += Validacion.NoSimbolos;


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

            var provincia = _rubroServicio.ObtenerPorId(entidadId.Value);

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

            var nuevoRubro = new RubroDto
            {
                Descripcion = txtDescripcion.Text,
            };

            _rubroServicio.insertar(nuevoRubro);

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

            var provinciaParaModificar = new RubroDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text
            };

            _rubroServicio.Modificar(provinciaParaModificar);

            return true;
        }
        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _rubroServicio.Elimiar(EntidadId.Value);

            return true;
        }
    }
}
