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

namespace Presentacion.Core._12_CondicionIVA
{
    public partial class _00021_ABM_CondicionIva : FormularioAbm
    {
        private readonly ICondicionIVASServicvios _condicionIVASServicvios;


        public _00021_ABM_CondicionIva(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _condicionIVASServicvios = new CondicionIIVAServicios();

            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                DesactivarControles(this);
            }

            AgregarControlesObligatorios(txtDescripcion, "Descripción");
            Inicializador(entidadId);

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

            var iva = _condicionIVASServicvios.obtenerPorID(entidadId.Value);

            // Datos Personales
            txtDescripcion.Text = iva.Descripcion;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevaProvincia = new CondicionIIVADTOs
            {
                Descripcion = txtDescripcion.Text,
            };

            _condicionIVASServicvios.Insertar(nuevaProvincia);

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

            var provinciaParaModificar = new CondicionIIVADTOs
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text
            };

            _condicionIVASServicvios.Modifocar(provinciaParaModificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _condicionIVASServicvios.Elimianar(EntidadId.Value);

            return true;
        }



    }
}
