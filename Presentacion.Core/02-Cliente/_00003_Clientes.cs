using System.Windows.Forms;
using Presentacion.FormularioBase;
using Presentacion.Helpers;
using XCommerce.Servicio.Core.Cliente;
using XCommerce.Servicio.Core.Cliente.DTOs;
using XCommerce.Servicio.Core._02_Cliente;
using Presentacion.Core._02_Cliente;

namespace Presentacion.Core.Cliente
{
    public partial class _00003_Clientes : FormularioConsulta
    {
        private readonly IClienteServicio _empleadoServicio;

        public _00003_Clientes()
            : this(new ClienteServicio())
        {
            InitializeComponent();


        }

        public _00003_Clientes(IClienteServicio empleadoServicio)
        {
            _empleadoServicio = empleadoServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["ApyNom"].Visible = true;
            grilla.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["ApyNom"].HeaderText = @"Apellido y Nombre";
            grilla.Columns["ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Dni"].Visible = true;
            grilla.Columns["Dni"].Width = 100;
            grilla.Columns["Dni"].HeaderText = @"DNI";
            grilla.Columns["Dni"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Celular"].Visible = true;
            grilla.Columns["Celular"].Width = 150;
            grilla.Columns["Celular"].HeaderText = @"Celular";
            grilla.Columns["Celular"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _empleadoServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fClienteAbm = new _00004_ABM_Cliente(TipoOperacion.Nuevo);
            fClienteAbm.ShowDialog();

            ActualizarSegunOperacion(fClienteAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!((ClienteDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fClienteAbm = new _00004_ABM_Cliente(TipoOperacion.Modificar, EntidadId);
                fClienteAbm.ShowDialog();

                ActualizarSegunOperacion(fClienteAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El empleado se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()
        {
            if (!((ClienteDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fClienteAbm = new _00004_ABM_Cliente(TipoOperacion.Eliminar, EntidadId);

                fClienteAbm.ShowDialog();

                ActualizarSegunOperacion(fClienteAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El empleado se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        // ======================================================================================= //

        private void ActualizarSegunOperacion(bool realizoAlgunaOperacion)
        {
            if (realizoAlgunaOperacion)
            {
                ActualizarDatos(dgvGrilla, string.Empty);
            }
        }

        private void btnCtaCte_Click(object sender, System.EventArgs e)
        {

            if (EntidadId == null)
            {
                MessageBox.Show("Elija un cliente ");
              
            }
            else
            {
                var formulario = new _00004_CtaCte_Cliente(EntidadId);
                formulario.ShowDialog();
            }



        }
    }
}
