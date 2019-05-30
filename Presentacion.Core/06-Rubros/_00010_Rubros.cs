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
using XCommerce.Servicio.Core._06_Rubro;
using XCommerce.Servicio.Core.Rubro;

namespace Presentacion.Core._6_Rubros
{
    

        public partial class _00010_Rubros : FormularioConsulta
        {
            private readonly IRubroServicio _rubroServicio;

            public _00010_Rubros()
                : this(new RubroServicio())
            {
                InitializeComponent();


            var GlobalRubro = new  VarGlobarRubro();
            GlobalRubro.Iniciar();

            }

            public _00010_Rubros(IRubroServicio rubroServicio)
            {
                _rubroServicio = rubroServicio;
            }



            public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
            {
                dgvGrilla.DataSource = _rubroServicio.obtner(cadenaBuscar);
            }

            public override void FormatearGrilla(DataGridView grilla)
            {
                base.FormatearGrilla(grilla);

                grilla.Columns["Descripcion"].Visible = true;
                grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                grilla.Columns["Descripcion"].HeaderText = @"Rubro";
                grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                grilla.Columns["EstaEliminadoStr"].Visible = true;
                grilla.Columns["EstaEliminadoStr"].Width = 100;
                grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
                grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            public override void EjecutarNuevo()
            {
                var fEmpleadoAbm = new _00010_ABM_Rubros(TipoOperacion.Nuevo);
                fEmpleadoAbm.ShowDialog();

                ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
            }
            public override void EjecutarModificar()
            {
                if (!((RubroDto)EntidadSeleccionada).EstaEliminado)
                {
                    base.EjecutarModificar();

                    if (!PuedeEjecutarComando) return;

                    var fEmpleadoAbm = new _00010_ABM_Rubros(TipoOperacion.Modificar, EntidadId);
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
                if (!((RubroDto)EntidadSeleccionada).EstaEliminado)
                {
                    base.EjecutarEliminar();

                    if (!PuedeEjecutarComando) return;

                    var fEmpleadoAbm = new _00010_ABM_Rubros(TipoOperacion.Eliminar, EntidadId);

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
