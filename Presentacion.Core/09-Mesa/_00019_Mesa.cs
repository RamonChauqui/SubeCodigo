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
using XCommerce.Servicio.Core.Mesas;

namespace Presentacion.Core._9_Mesa
{
    public partial class _00019_Mesa : FormularioConsulta

    {
        private readonly IMesaServicio _mesaservicio;

        public _00019_Mesa()
            : this(new MesaServicio())
        {
            InitializeComponent();
        }
        public _00019_Mesa(IMesaServicio mesaServicio)
        {
            _mesaservicio = mesaServicio;
        }
        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Descripcion";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            grilla.Columns["Salon"].Visible = true;
            grilla.Columns["Salon"].Width = 100;            
            grilla.Columns["Salon"].HeaderText = @"Tipo Salon";
         

        }

        public override void EjecutarNuevo()
        {
            var fmESAAbm = new _00019_ABM_Mesa(TipoOperacion.Nuevo);
            fmESAAbm.ShowDialog();

            ActualizarSegunOperacion(fmESAAbm.RealizoAlgunaOperacion);
        }


        private void ActualizarSegunOperacion(bool realizoAlgunaOperacion)
        {
            if (realizoAlgunaOperacion)
            {
                ActualizarDatos(dgvGrilla, string.Empty);
            }

        }
        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {

            grilla.DataSource = _mesaservicio.Obtener(cadenaBuscar);

        }
        public override void EjecutarEliminar()
        {
            if (!((MesaDtos)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fEmpleadoAbm = new _00019_ABM_Mesa(TipoOperacion.Eliminar, EntidadId);

                fEmpleadoAbm.ShowDialog();

                ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"La mesa se encuetra Elimnada", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        public override void EjecutarModificar()
        {
            if (!((MesaDtos)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fEmpleadoAbm = new _00019_ABM_Mesa(TipoOperacion.Modificar, EntidadId);
                fEmpleadoAbm.ShowDialog();

                ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El empleado se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }



    }
}
