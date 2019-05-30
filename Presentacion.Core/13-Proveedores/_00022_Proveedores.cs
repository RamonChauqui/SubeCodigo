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
using XCommerce.Servicio.Core._13_Proveedores;

namespace Presentacion.Core._13_Proveedores
{
    public partial class _00022_Proveedores : FormularioConsulta
    {
        private readonly IProveedores _proveedores;

        public _00022_Proveedores()
            : this(new ProveedoresServicio())
        {
            InitializeComponent();
        }
        public _00022_Proveedores(IProveedores proveedores)
        {
            _proveedores = proveedores;
        }
        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["RazonSocial"].Visible = true;
            grilla.Columns["RazonSocial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["RazonSocial"].HeaderText = @"Razon Social";
            grilla.Columns["RazonSocial"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Telefono"].Visible = true;
            grilla.Columns["Telefono"].Width = 100;
            grilla.Columns["Telefono"].HeaderText = @"Telefono";
            grilla.Columns["Telefono"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EMail"].Visible = true;
            grilla.Columns["EMail"].Width = 100;
            grilla.Columns["EMail"].HeaderText = @"EMail";
            grilla.Columns["EMail"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Contacto"].Visible = true;
            grilla.Columns["Contacto"].Width = 150;
            grilla.Columns["Contacto"].HeaderText = @"Contacto";
            grilla.Columns["Contacto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            grilla.Columns["CondicionIVA"].Visible = true;
            grilla.Columns["CondicionIVA"].Width = 100;
            grilla.Columns["CondicionIVA"].HeaderText = @"Condicion IVA";
            grilla.Columns["CondicionIVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["CondicionIVA"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _proveedores.ObtenerCAdena(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fEmpleadoAbm = new _00022_ABM_Proveedores(TipoOperacion.Nuevo);
            fEmpleadoAbm.ShowDialog();

            ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
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
            if (!((ProveedoresDtos)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var provv = new _00022_ABM_Proveedores(TipoOperacion.Eliminar, EntidadId);

                provv.ShowDialog();

                ActualizarSegunOperacion(provv.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El proveedor se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        public override void EjecutarModificar()
        {
            if (!((ProveedoresDtos)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var prov = new _00022_ABM_Proveedores(TipoOperacion.Modificar, EntidadId);
                prov.ShowDialog();

                ActualizarSegunOperacion(prov.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El empleado se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

    }
}
