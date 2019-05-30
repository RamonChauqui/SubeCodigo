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
using XCommerce.Servicio.Core._24_Motivo_Reserva;
using XCommerce.Servicio.Core._24_Motivo_Reserva.DTOs;

namespace Presentacion.Core._14_Reserva.Motivo_de_Reserva
{
    public partial class _00022_ABM_MotivoReserva : FormularioAbm
    {
        private readonly IMotivoReservaServicio _motivoReservaServicio;

        public _00022_ABM_MotivoReserva(TipoOperacion tipoOperacion, long? entidadId = null)
              :base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _motivoReservaServicio = new MotivoReservaServico();

            if (tipoOperacion == TipoOperacion.Eliminar || tipoOperacion == TipoOperacion.Modificar)
            {
                CargarDatos(entidadId);
            }

            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);


            AgregarControlesObligatorios(txtDescripcion, "Descripcion");



            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;


            txtDescripcion.KeyPress += Validacion.NoSimbolos;
            //txtDescripcion.KeyPress += Validacion.NoNumeros;


        }

        public override void CargarDatos(long? entidadId)
        {
            if (!entidadId.HasValue)
            {
                MessageBox.Show(@"Ocurrio un Error Grave", @"Error Grave", MessageBoxButtons.OK
                    , MessageBoxIcon.Stop);

                this.Close();
            }

            if (TipoOperacion == TipoOperacion.Eliminar)
            {
                btnLimpiar.Enabled = false;
            }

            var motivo = _motivoReservaServicio.ObtenerPorId(entidadId.Value);

            txtDescripcion.Text = motivo.Descripcion;

        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevoMotivo = new MotivoReservaDto
            {
                Descripcion = txtDescripcion.Text

            };

            _motivoReservaServicio.Insertar(nuevoMotivo);

            return true;
        }

        public override bool EjecutarComandoModificar()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var motivoModificar = new MotivoReservaDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text

            };

            _motivoReservaServicio.Modificar(motivoModificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _motivoReservaServicio.Eliminar(EntidadId.Value);

            return true;
        }
    }
}
