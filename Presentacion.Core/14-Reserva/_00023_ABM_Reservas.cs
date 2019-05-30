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
using XCommerce.Servicio.Core._25_Reserva;
using XCommerce.Servicio.Core.Cliente;
using XCommerce.Servicio.Core.Cliente.DTOs;
using XCommerce.Servicio.Core.Empleado;
using XCommerce.Servicio.Core.Empleado.DTOs;
using XCommerce.Servicio.Core.Mesas;

namespace Presentacion.Core._14_Reserva
{
    public partial class _00023_ABM_Reservas : FormularioAbm
    {
        private readonly IReservaServicio _reservaServicio;
        private readonly IMesaServicio _mesaServicio;
        private readonly IClienteServicio _clienteServicio;
        private readonly IMotivoReservaServicio _motivoReservaServicio;
        /*===================================================================*/
        private readonly IEmpleadoServicio _empleadoservicio;
        /*===================================================================*/

        public _00023_ABM_Reservas(TipoOperacion tipoOperacion, long? entidadId = null)
              : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _clienteServicio = new ClienteServicio();
            _motivoReservaServicio = new MotivoReservaServico();
            _mesaServicio = new MesaServicio();
            _reservaServicio = new ReservaServicio();

            /*===================================================================*/

            _empleadoservicio = new EmpleadoServicio();
            /*===================================================================*/
             

            if (tipoOperacion == TipoOperacion.Eliminar || tipoOperacion == TipoOperacion.Modificar)
            {
                CargarDatos(entidadId);
            }

            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(dtpFecha, "Fecha");
            AgregarControlesObligatorios(nudSenia, "Senia");
            AgregarControlesObligatorios(cmbMesa, "Mesa");
            //AgregarControlesObligatorios(cmbCliente, "Cliente");
            AgregarControlesObligatorios(cmbMotivoReserva, "E-MotivoReserva");


            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            CargarComboBox(cmbUsuario, _empleadoservicio.Obtener(string.Empty), "Descripcion", "Id");

            CargarComboBox(cmbMesa, _mesaServicio.ObtenerPorEstado(string.Empty), "Descripcion", "Id");
            CargarComboBox(cmbCliente, _clienteServicio.Obtener(string.Empty), "Dni", "Id");
            CargarComboBox(cmbMotivoReserva, _motivoReservaServicio.Obtener(string.Empty), "Descripcion", "Id");


            nudSenia.Minimum = 1;
            nudSenia.Maximum = 99999999;

        }

        public override void CargarDatos(long? entidadId)
        {
            if (!entidadId.HasValue)
            {
                MessageBox.Show(@"Ocurrio un Error Grave", @"Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                this.Close();
            }

            if (TipoOperacion == TipoOperacion.Eliminar)
            {
                btnLimpiar.Enabled = false;
            }

            var reserva = _reservaServicio.ObtenerPorId(entidadId.Value);

            nudSenia.Minimum = 1;
            nudSenia.Maximum = 9999999999;
            nudSenia.Value = reserva.Senia;

            dtpFecha.Value = reserva.Fecha;

            CargarComboBox(cmbMesa, _mesaServicio.ObtenerPorEstado(string.Empty), "Descripcion", "Id");
            CargarComboBox(cmbCliente, _clienteServicio.Obtener(string.Empty), "Dni", "Id");
            CargarComboBox(cmbMotivoReserva, _motivoReservaServicio.Obtener(string.Empty), "Descripcion", "Id");
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevaReserva = new XCommerce.Servicio.Core._25_Reserva.DTOs.ReservaDto
            {
                Senia = nudSenia.Value,
                ClienteId = ((ClienteDto)(cmbCliente.SelectedItem)).Id,
                Fecha = dtpFecha.Value,
                MesaId = ((MesaDtos)cmbMesa.SelectedItem).Id,
                MotivoReservaId = ((MotivoReservaDto)cmbMotivoReserva.SelectedItem).Id,
                EstaEliminado = false,

                UsuarioId = ((EmpleadoDto)cmbUsuario.SelectedItem).Id,

            };


            _reservaServicio.Insertar(nuevaReserva);

            return true;
        }

        public override bool EjecutarComandoModificar()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var reservaModificar = new XCommerce.Servicio.Core._25_Reserva.DTOs.ReservaDto
            {
                Id = EntidadId.Value,
                Senia = nudSenia.Value,
                ClienteId = ((ClienteDto)(cmbCliente.SelectedItem)).Id,
                Fecha = dtpFecha.Value,
                MesaId = ((MesaDtos)cmbMesa.SelectedItem).Id,
                MotivoReservaId = ((MotivoReservaDto)cmbMotivoReserva.SelectedItem).Id,
                EstaEliminado = false
            };

            _reservaServicio.Modificar(reservaModificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _reservaServicio.Eliminar(EntidadId.Value);

            return true;
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevoMotivo_Click(object sender, EventArgs e)
        {

        }
    }
}
