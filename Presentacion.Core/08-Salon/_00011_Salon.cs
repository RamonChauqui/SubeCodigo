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
using XCommerce.Servicio.Core._08_Sala;
using XCommerce.Servicio.Core.Sala;

namespace Presentacion.Core._8_Salon
{

    public partial class _00011_Salon : FormularioConsulta
    {

        private readonly ISalaServicio _salaServicio;

        public _00011_Salon()
            : this(new SalaServicio())
        {
            InitializeComponent();

            //var GlobalSala = new VarGlobalSalas();
            //GlobalSala.Inicial();

        }
        public _00011_Salon(ISalaServicio salaServicio)
        {
            _salaServicio = salaServicio;
            ;
        }


        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {

            grilla.DataSource = _salaServicio.ObtenerCAdena(cadenaBuscar);

        }


        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);



            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"DESCRIPCION";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["DescripcionLista"].Visible = true;
            grilla.Columns["DescripcionLista"].Width = 100;
            grilla.Columns["DescripcionLista"].HeaderText = @"Eliminado";
            grilla.Columns["DescripcionLista"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["DescripcionLista"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }
        public override void EjecutarNuevo()
        {
            var nuevamses = new _00011_ABM_Salon(TipoOperacion.Nuevo);
            nuevamses.ShowDialog();
            ActualizarSegunOperacion(nuevamses.RealizoAlgunaOperacion);


        }
        public override void EjecutarEliminar()
        {
            if (!((SalaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fEmpleadoAbm = new _00011_ABM_Salon(TipoOperacion.Eliminar, EntidadId);

                fEmpleadoAbm.ShowDialog();

                ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"LA SALA SE ENCUENTRA ELIMINADA", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }



        private void ActualizarSegunOperacion(bool realizoAlgunaOperacion)
        {
            if (realizoAlgunaOperacion)
            {
                ActualizarDatos(dgvGrilla, string.Empty);
            }
        }

        public override void EjecutarModificar()
        {
            if (!((SalaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();
                if (!PuedeEjecutarComando) return;

                var fsala = new _00011_ABM_Salon(TipoOperacion.Modificar, EntidadId);
                fsala.ShowDialog();

                ActualizarSegunOperacion(fsala.RealizoAlgunaOperacion);

            }
            else
            {
                MessageBox.Show(@"LA SALA SE ENCUENTRA ELIMINADA", @"ATENCION", MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
            }
        }

        private void _00011_Salon_Load(object sender, EventArgs e)
        {
        }
    }
}
