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
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core._15_Tarjetas;
using XCommerce.Servicio.Core._16_Planes_de_Yarjeta;

namespace Presentacion.Core._16_Planes_de_tarjeta
{
    public partial class _00025_ABM_PlanesTarjetas : FormularioAbm
    {
        private readonly IPlanesTajeta _planesTajeta;
        private readonly ITarjetasServicio _tarjetas;

        public _00025_ABM_PlanesTarjetas(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
            _planesTajeta = new PlanesTajeta();
            _tarjetas = new TarjetasServicio();


            if (tipoOperacion == TipoOperacion.Eliminar || tipoOperacion == TipoOperacion.Modificar)
            {
                CargarDatos(entidadId);
            }


            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);


            Inicializador(entidadId);

        }
        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            CargarComboBox(cmbTarjetas, _tarjetas.obtener(string.Empty), "Descripcion", "Id");

            // Asignando un Evento
            txtDescripcion.KeyPress += Validacion.NoSimbolos;

            AgregarControlesObligatorios(txtDescripcion, "Descripcion");

    

            txtDescripcion.Focus();
        }
        public override bool EjecutarComandoModificar()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            var tarjmodific = new PlanesTajetaDTOs
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text,
                Alicuota = nudAlicuota.Value,
                TarjetaID = ((TarjetasServicioDtos)cmbTarjetas.SelectedItem).Id,
                EstaEliminado = false,
            };

            _planesTajeta.Modifocar(tarjmodific);

            return true;

        }


        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevPaltj = new PlanesTajetaDTOs
            {
                Descripcion = txtDescripcion.Text,
                Alicuota = nudAlicuota.Value,
                TarjetaID = ((TarjetasServicioDtos)cmbTarjetas.SelectedItem).Id,
                EstaEliminado = false,
            };

            _planesTajeta.Insertar(nuevPaltj);


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
            var plan = _planesTajeta.ObtenerPorId(entidadId.Value);

            txtDescripcion.Text = plan.Descripcion;
            nudAlicuota.Value = plan.Alicuota;
            

            CargarComboBox(cmbTarjetas, _tarjetas.obtener(string.Empty), "Descripcion", "Id");
            

        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _planesTajeta.Eliminar(EntidadId.Value);

            return true;
        }

        private void _00025_ABM_PlanesTarjetas_Load(object sender, EventArgs e)
        {

        }
    }
}
