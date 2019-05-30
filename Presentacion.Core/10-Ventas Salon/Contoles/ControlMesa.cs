using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.AccesoDatos;
using XCommerce.Servicio.Core.Mesa_Comprobante;
using XCommerce.Servicio.Core._22_ComprobanteSalon;
using XCommerce.Servicio.Core.Mesas;
using Presentacion.Core._14_Reserva;

namespace Presentacion.Core._10_Ventas_Salon.Contoles
{
    public partial class ControlMesa : UserControl
    {
        private readonly IComprobanteSalon _comprobanteSalon;
        private readonly IMesaServicio _mesaServicio;

        long _mesaId;
        public long MesaID { set => _mesaId = value; }

        private readonly IComprobanteMesaServicio _comprobanteMesaServicio;
        private int numeroMesa;

        public int NumeroMesa
        {
            set
            {

                numeroMesa = value;
                lblNumeroMesa.Text = $" Mesa {value}";
            }
        }

        public decimal PrecioConsumido
        {
            set { lblPrecioConsumido.Text = $"{value.ToString("C")}"; }
        }



        private EstadoMesa _estadoMesa;

        public EstadoMesa EsatdoDeMEsa
        {

            set
            {
                _estadoMesa = value;

                menuAbrirMesa.Visible = false;
                menuCerrarMesa.Visible = false;
                menuReservarMesa.Visible = false;


                switch (value)
                {
                    case XCommerce.AccesoDatos.EstadoMesa.Cerrada:
                        this.BackColor = Color.DarkRed;
                        lblEstado.Text = "Mesa cerrada";
                        menuAbrirMesa.Visible = true;
                        menuReservarMesa.Visible = true;


                        break;

                    case XCommerce.AccesoDatos.EstadoMesa.Abierta:
                        this.BackColor = Color.DarkGreen;
                        lblEstado.Text = "Mesa abierta";

                        menuCerrarMesa.Visible = true;


                        break;

                    case XCommerce.AccesoDatos.EstadoMesa.FueraServicio:
                        this.BackColor = Color.Black;

                        lblEstado.Text = "Fuera de servicio";

                        menuAbrirMesa.Visible = false;
                        menuCerrarMesa.Visible = false;

                        break;

                    case XCommerce.AccesoDatos.EstadoMesa.Reservada:
                        this.BackColor = Color.DarkBlue;

                        lblEstado.Text = "En reserva";

                        menuAbrirMesa.Visible = true;


                        break;


                }
            }
        }


        public ControlMesa()
            : this(new ComprobanteMesaServicio(), new XCommerce.Servicio.Core._22_ComprobanteSalon.ComprobanteSalon(),new MesaServicio())
        {
            InitializeComponent();

            decimal  a = 1;
            Actualizar(a);
        }

        public ControlMesa(IComprobanteMesaServicio comprobanteMesaServicio, IComprobanteSalon comprobanteSalon, IMesaServicio mesaServicio )
        {
            _comprobanteMesaServicio = comprobanteMesaServicio;
            _comprobanteSalon = comprobanteSalon;
            _mesaServicio = mesaServicio;
        }

        private void lblPrecioConsumido_DoubleClick(object sender, EventArgs e)
        {
            /*======NECESITO SABER EL ESTADO DE LA MESA, PARA ESO DEBO GUARDARA EN UNA VARIABLE  =======*/
            EjecutarFormulairoComprobante();


        }

        private void EjecutarFormulairoComprobante()
        {
            if (_estadoMesa == EstadoMesa.Cerrada || _estadoMesa == EstadoMesa.Reservada)
            {
                //No debemos poner el Id Hard de usuario y empelado, mozo
                _comprobanteMesaServicio.AbrirMesa(1, _mesaId, 1, 1);

                EsatdoDeMEsa = EstadoMesa.Abierta;
            }
            if (_estadoMesa == EstadoMesa.Abierta)
            {
                 var fcompribantesalon = new _00019_ComprobanteSalon(_mesaId,numeroMesa);
                fcompribantesalon.ActualizarTotalDelControlMesa += Actualizar;
                fcompribantesalon.ShowDialog();
            };            
        }
        private void menuAbrirMesa_Click(object sender, EventArgs e)
        {
            EjecutarFormulairoComprobante();

        }

        private void menuCerrarMesa_Click(object sender, EventArgs e)
        {
                                

            //if (_estadoMesa == EstadoMesa.Abierta)
            //{
            //    //No debemos poner el Id Hard de usuario y empelado, mozo


            //    EsatdoDeMEsa = EstadoMesa.Cerrada;
            //}
            //if (_estadoMesa == EstadoMesa.Cerrada)
            //{
            //      var pagarFactura = new _00019_FormaDePago(_mesaId);            

            //    pagarFactura.ShowDialog();
   //};

            var comprobante = _comprobanteSalon.ObtenerComprobantePorMesa(_mesaId);

            if (comprobante.Total == 0)
            {
                _mesaServicio.CambiarEstado(_mesaId, EstadoMesa.Cerrada);
                EsatdoDeMEsa = EstadoMesa.Cerrada;
                PrecioConsumido = comprobante.Total;
            }
            else
            {
                var pagarFactura = new _00019_FormaDePago(_mesaId);
                pagarFactura.ShowDialog();
                if (pagarFactura.realizoOperacion)
                {
                    _mesaServicio.CambiarEstado(_mesaId, EstadoMesa.Cerrada);
                    EsatdoDeMEsa = EstadoMesa.Cerrada;
                    PrecioConsumido = 0m;
                }
                else
                {
                    _mesaServicio.CambiarEstado(_mesaId, EstadoMesa.Abierta);
                    EsatdoDeMEsa = EstadoMesa.Abierta;
                    PrecioConsumido = comprobante.Total;
                }
            }
         


        }

        public void Actualizar(decimal totalFacturado)
        {
            PrecioConsumido = totalFacturado;

        }

        private void menuReservarMesa_Click(object sender, EventArgs e)
        {
            
                 var fcompribantesalon = new _00023_ABM_Reservas(Helpers.TipoOperacion.Nuevo);            
            fcompribantesalon.ShowDialog();

            if (_estadoMesa == EstadoMesa.Cerrada)
            {
                _comprobanteMesaServicio.ReservarMesa(1, _mesaId, 1);

                EsatdoDeMEsa = EstadoMesa.Reservada;
            }

        }
     
    }
}
 