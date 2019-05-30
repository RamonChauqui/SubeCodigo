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
using XCommerce.Servicio.Core._16_Planes_de_Yarjeta;

namespace Presentacion.Core._16_Planes_de_tarjeta
{
    public partial class _00025_PlanesTarjetas : FormularioConsulta
    {
        private IPlanesTajeta _planesTarjeta;

        public _00025_PlanesTarjetas()
            :this (new PlanesTajeta())
        {
            InitializeComponent();
        }
        public _00025_PlanesTarjetas(IPlanesTajeta planesTarjeta)
        {
            _planesTarjeta = planesTarjeta;
        }


        public override void FormatearGrilla(DataGridView grilla)
        {

            base.FormatearGrilla(grilla);

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Descripcion";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Tarjeta"].Visible = true;
            grilla.Columns["Tarjeta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Tarjeta"].HeaderText = @"Tarjeta";
            grilla.Columns["Tarjeta"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            
            grilla.Columns["Alicuota"].Visible = true;
            grilla.Columns["Alicuota"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Alicuota"].HeaderText = @"Alicuota";
            grilla.Columns["Alicuota"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            
            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        
        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _planesTarjeta.Obtener(cadenaBuscar);
        }
        public override void EjecutarNuevo()
        {
            var fEmpleadoAbm = new _00025_ABM_PlanesTarjetas(TipoOperacion.Nuevo);
            fEmpleadoAbm.ShowDialog();

            ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
        }
        public override void EjecutarModificar()
        {
            if (!((PlanesTajetaDTOs)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fClienteAbm = new _00025_ABM_PlanesTarjetas(TipoOperacion.Modificar, EntidadId);
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

        public override void EjecutarEliminar()
        {
            if (!((PlanesTajetaDTOs)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fClienteAbm = new _00025_ABM_PlanesTarjetas(TipoOperacion.Eliminar, EntidadId);

                fClienteAbm.ShowDialog();

                ActualizarSegunOperacion(fClienteAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El plan se encuentra eliminado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

    }
}
