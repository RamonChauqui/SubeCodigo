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
using XCommerce.Servicio.Core._15_Tarjetas;

namespace Presentacion.Core._15_Tarjetas
{
    public partial class _00024_ABM_Tarjetas : FormularioAbm
    {
        private readonly ITarjetasServicio _tarjetasServicio;

        public _00024_ABM_Tarjetas(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
            _tarjetasServicio = new TarjetasServicio();

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

            var provincia = _tarjetasServicio.obtenerPorID(entidadId.Value);

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

            var nuevaProvincia = new TarjetasServicioDtos
            {
                Descripcion = txtDescripcion.Text,
            };

            _tarjetasServicio.Insertar(nuevaProvincia);

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

            var provinciaParaModificar = new TarjetasServicioDtos
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text
            };

            _tarjetasServicio.Modificar(provinciaParaModificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _tarjetasServicio.Eliminar(EntidadId.Value);
            return true;
        }



    }
}
