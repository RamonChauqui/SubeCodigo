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
    public partial class _00022_ReservasMotivo : FormularioConsulta
    {
        private readonly IMotivoReservaServicio _motivoReservaServicio;

  
        public _00022_ReservasMotivo()
            : this(new MotivoReservaServico())

        {
            InitializeComponent();

        }


        public _00022_ReservasMotivo(IMotivoReservaServicio motivoReservaServicio)
        {

            _motivoReservaServicio = motivoReservaServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].Width = 600;
            grilla.Columns["Descripcion"].HeaderText = @"Descripcion";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _motivoReservaServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fMotivoAbm = new _00022_ABM_MotivoReserva(TipoOperacion.Nuevo);
            fMotivoAbm.ShowDialog();

            ActualizarSegunOperacion(fMotivoAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!((MotivoReservaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fMotivoAbm = new _00022_ABM_MotivoReserva(TipoOperacion.Modificar, EntidadId);
                fMotivoAbm.ShowDialog();

                ActualizarSegunOperacion(fMotivoAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El empleado se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()
        {
            if (!((MotivoReservaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fMotivoAbm = new _00022_ABM_MotivoReserva(TipoOperacion.Eliminar, EntidadId);

                fMotivoAbm.ShowDialog();

                ActualizarSegunOperacion(fMotivoAbm.RealizoAlgunaOperacion);
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
