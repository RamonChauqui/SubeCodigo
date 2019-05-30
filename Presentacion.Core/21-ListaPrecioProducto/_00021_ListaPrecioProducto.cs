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
using XCommerce.Servicio.Core._21_Lista_Precio_Producto.DTos;

namespace Presentacion.Core._21_ListaPrecioProducto
{
    public partial class _00021_ListaPrecioProducto : FormularioConsulta
    {
        private readonly IListaPrecioProducto _listaPrecioProducto;

        public _00021_ListaPrecioProducto()
        {
            InitializeComponent();
            _listaPrecioProducto = new ListaPrecioProducto();
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            base.ActualizarDatos(grilla, cadenaBuscar);
            dgvGrilla.DataSource = _listaPrecioProducto.Obtener(string.Empty);

        }
        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            dgvGrilla.Columns["Lista"].Visible = true;
            dgvGrilla.Columns["Lista"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Lista"].HeaderText = @"Lista";
            dgvGrilla.Columns["Lista"].DisplayIndex = 1;


            dgvGrilla.Columns["Producto"].Visible = true;
            dgvGrilla.Columns["Producto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Producto"].HeaderText = @"Producto";
            dgvGrilla.Columns["Producto"].DisplayIndex = 2;

            dgvGrilla.Columns["PrecioCosto"].Visible = true;
            dgvGrilla.Columns["PrecioCosto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["PrecioCosto"].HeaderText = @"Precio Costo";
            dgvGrilla.Columns["PrecioCosto"].DisplayIndex = 3;
            dgvGrilla.Columns["PrecioCosto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvGrilla.Columns["PrecioCosto"].DefaultCellStyle.Format = "C2";

            dgvGrilla.Columns["PrecioPublico"].Visible = true;
            dgvGrilla.Columns["PrecioPublico"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["PrecioPublico"].HeaderText = @"Precio Publico";
            dgvGrilla.Columns["PrecioPublico"].DisplayIndex = 4;
            dgvGrilla.Columns["PrecioPublico"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvGrilla.Columns["PrecioPublico"].DefaultCellStyle.Format = "C2";

            dgvGrilla.Columns["FechaActualizacion"].Visible = true;
            dgvGrilla.Columns["FechaActualizacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["FechaActualizacion"].HeaderText = @"Fecha";
            dgvGrilla.Columns["FechaActualizacion"].DisplayIndex = 6;


            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
        public override void EjecutarNuevo()
        {

            var fEmpleadoAbm = new _00021_ABM_ListaPrecioProducto(TipoOperacion.Nuevo);
            fEmpleadoAbm.ShowDialog();

            ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
        }
        public override void EjecutarEliminar()
        {
            if (!((ListaPecioProductoDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fClienteAbm = new _00021_ABM_ListaPrecioProducto(TipoOperacion.Eliminar, EntidadId);

                fClienteAbm.ShowDialog();

                ActualizarSegunOperacion(fClienteAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El empleado se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        public override void EjecutarModificar()
        {
            if (!((ListaPecioProductoDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fEmpleadoAbm = new _00021_ABM_ListaPrecioProducto(TipoOperacion.Modificar, EntidadId);
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
