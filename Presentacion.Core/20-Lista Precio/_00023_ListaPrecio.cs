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
using XCommerce.Servicio.Core._20__Lista_Precio;

namespace Presentacion.Core._20_Lista_Precio
{
    public partial class _00023_ListaPrecio : FormularioConsulta
    {
        private readonly IListaPrecioServicio _ListaPrecioServicio;

        public _00023_ListaPrecio()
            :this(new ListaPrecioServicio())
        {
            InitializeComponent();

        }
        public _00023_ListaPrecio(IListaPrecioServicio listaPrecioServicio)
        {
            _ListaPrecioServicio = listaPrecioServicio;

            var ini = new VarGlobalListaPrecio();
            ini.ListaPrecio();

        }
        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            base.ActualizarDatos(grilla, cadenaBuscar);
            dgvGrilla.DataSource = _ListaPrecioServicio.obtner(string.Empty);
            FormatearGrilla(dgvGrilla);
        }
      
        public override void FormatearGrilla(DataGridView dgvGrilla)
        {
            base.FormatearGrilla(dgvGrilla);

            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            dgvGrilla.Columns["EstaEliminadoStr"].Visible = true;
            dgvGrilla.Columns["EstaEliminadoStr"].Width = 100;
            dgvGrilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            dgvGrilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
        public override void EjecutarNuevo()
        {
            var fEmpleadoAbm = new _00023_ABM_ListaPrecio(TipoOperacion.Nuevo);
            fEmpleadoAbm.ShowDialog();

            ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
        }
        public override void EjecutarModificar()
        {
            if (!((ListaPrecioDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fEmpleadoAbm = new _00023_ABM_ListaPrecio(TipoOperacion.Modificar, EntidadId);
                fEmpleadoAbm.ShowDialog();

                ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El rubro se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        public override void EjecutarEliminar()
        {
            if (!((ListaPrecioDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fEmpleadoAbm = new _00023_ABM_ListaPrecio(TipoOperacion.Eliminar, EntidadId);

                fEmpleadoAbm.ShowDialog();

                ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
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
    }
}
