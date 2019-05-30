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
using XCommerce.Servicio.Core._25_Reserva;
using XCommerce.Servicio.Core._25_Reserva.DTOs;

namespace Presentacion.Core._14_Reserva
{
    public partial class _00022_Reservas : FormularioConsulta
    {

        private readonly IReservaServicio _reservaServicio;

        public _00022_Reservas()
              : this(new ReservaServicio())
        {
            InitializeComponent();
        }

        public _00022_Reservas(IReservaServicio reservaServicio)
        {
            _reservaServicio = reservaServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Fecha"].Visible = true;
            grilla.Columns["Fecha"].Width = 100;
            grilla.Columns["Fecha"].HeaderText = @"Fecha de Reserva";
            grilla.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["EstadoReserva"].Visible = true;
            grilla.Columns["EstadoReserva"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["EstadoReserva"].HeaderText = @"Estado de Reserva";
            grilla.Columns["EstadoReserva"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Senia"].Visible = true;
            grilla.Columns["Senia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Senia"].HeaderText = @"Seña";
            grilla.Columns["Senia"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["MesaId"].Visible = true;
            grilla.Columns["MesaId"].Width = 50;
            grilla.Columns["MesaId"].HeaderText = @"Mesa";
            grilla.Columns["MesaId"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["MotivoReservaId"].Visible = true;
            grilla.Columns["MotivoReservaId"].Width = 50;
            grilla.Columns["MotivoReservaId"].HeaderText = @"Motivo de Reserva";
            grilla.Columns["MotivoReservaId"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["ClienteId"].Visible = true;
            grilla.Columns["ClienteId"].Width = 50;
            grilla.Columns["ClienteId"].HeaderText = @"Cliente";
            grilla.Columns["ClienteId"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            grilla.Columns["EstaEliminadoStr"].Visible = true;
            grilla.Columns["EstaEliminadoStr"].Width = 100;
            grilla.Columns["EstaEliminadoStr"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _reservaServicio.Obtener(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fReservaAbm = new _00023_ABM_Reservas(TipoOperacion.Nuevo);
            fReservaAbm.ShowDialog();

            ActualizarSegunOperacion(fReservaAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (!((ReservaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarModificar();

                if (!PuedeEjecutarComando) return;

                var fReservaAbm = new _00023_ABM_Reservas(TipoOperacion.Modificar, EntidadId);
                fReservaAbm.ShowDialog();

                ActualizarSegunOperacion(fReservaAbm.RealizoAlgunaOperacion);
            }
            else
            {
                MessageBox.Show(@"El empleado se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public override void EjecutarEliminar()
        {
            if (!((ReservaDto)EntidadSeleccionada).EstaEliminado)
            {
                base.EjecutarEliminar();

                if (!PuedeEjecutarComando) return;

                var fReservaAbm = new _00023_ABM_Reservas(TipoOperacion.Eliminar, EntidadId);

                fReservaAbm.ShowDialog();

                ActualizarSegunOperacion(fReservaAbm.RealizoAlgunaOperacion);
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
