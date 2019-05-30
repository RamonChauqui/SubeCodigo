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
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core._22_ComprobanteSalon;
using XCommerce.Servicio.Core.Empleado;
using XCommerce.Servicio.Core.Empleado.DTOs;
using XCommerce.Servicio.Core.Mesas;

namespace XCommerce.Servicio.Core._17_Caja.CajaKiosco
{
    public partial class _00022_ABM_CajaSalon : FormularioAbm
    {
        /*============================================*/
        private readonly IComprobanteSalon _comprobanteSalon;
        private readonly IMesaServicio _mesaServicio;
        /*============================================*/


        private readonly ICajaSalon _cajaSalon;
        private readonly IEmpleadoServicio _empleadoservicio;

        public _00022_ABM_CajaSalon(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
            _cajaSalon = new CajaSalon();
            _empleadoservicio = new EmpleadoServicio();
            RealizoAlgunaOperacion = false;
            /*==================================*/
             
            /*==================================*/


            Inicializador(entidadId);
        }
        public _00022_ABM_CajaSalon()
            : this(new XCommerce.Servicio.Core._22_ComprobanteSalon.ComprobanteSalon())
        {

        }
        public _00022_ABM_CajaSalon(IComprobanteSalon comprobanteSalon)
        {
            _comprobanteSalon = comprobanteSalon;
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            CargarComboBox(cmbApertura , _empleadoservicio.Obtener(string.Empty), "Descripcion", "Id");
            CargarComboBox(cmbCierre , _empleadoservicio.Obtener(string.Empty), "Descripcion", "Id");

        
        }

        public override bool EjecutarComandoNuevo()
        {
            


                if (!VerificarDatosObligatorios())
                {
                    MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }

            var nuevoCja = new DtoCajaSAlon
            {
                MontoApertura = nudMontoApertura.Value,
                MontoCierre = nudmontoCierre.Value,
                EstaEliminado = false,
                FechaApertura = dtpFechaApertura.Value,
                FechaCierre = dtpFechaCierre.Value,
                UsuarioAperturaId = ((EmpleadoDto)cmbApertura.SelectedItem).Id,
                UsuarioCierreId = ((EmpleadoDto)cmbCierre.SelectedItem).Id,

            
                };

            ocultarBotonAbrirCaja();
            RealizoAlgunaOperacion = true;
            _cajaSalon.Insertar(nuevoCja);
            Close();
            return true;
        }

        private void ocultarBotonAbrirCaja()
        {
      

            



        }

        private void _00022_ABM_CajaSalon_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            if (TipoOperacion == TipoOperacion.Nuevo)
            {
               
                btnSalir.Hide();
            }
            else
            {
                var caja = _cajaSalon.ObtenerComprobantePorEstado(AccesoDatos.EstadoCaja.Abierto);

                nudMontoApertura.Value = caja.MontoApertura;
                nudmontoCierre.Value = caja.MontoCierre;
                dtpFechaApertura.Value = caja.FechaApertura;
                dtpFechaCierre.Value = caja.FechaCierre;
                cmbApertura.Hide();
                cmbCierre.Hide();
                nudMontoApertura.Enabled = false;
                nudmontoCierre.Enabled = false;
                dtpFechaApertura.Enabled = false;
                dtpFechaCierre.Enabled = false;
                
            }


        }

        long _mesaId;
        public long MesaID { set => _mesaId = value; }

        private void btnSalir_Click(object sender, EventArgs e)
        {
        //    var comprobante = _comprobanteSalon.ObtenerComprobantePorMesa(_mesaId);

        //    if (comprobante.Total >= 0)
        //    {

        //        MessageBox.Show("Aun hay mesas aviertas ");
        //    }


            var caja = _cajaSalon.ObtenerComprobantePorEstado(AccesoDatos.EstadoCaja.Abierto);
            _cajaSalon.CerrarCaja(caja.Id);
            RealizoAlgunaOperacion = true;

            Close();
        }
    }
}
