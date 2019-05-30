using Presentacion.Core.Empleado;
using System.Windows.Forms;
using Presentacion.Core.Cliente;
using Presentacion.Core.Localidad;
using Presentacion.Core.Provincia;
using Presentacion.Helpers;
using Presentacion.Seguridad.Usuario;
using Presentacion.Core._7_Marcas;
using Presentacion.Core._6_Rubros;
using Presentacion.Core._5_Articulos;
using Presentacion.Core._8_Salon;
using Presentacion.Core._9_Mesa;
using Presentacion.Core._10_Ventas;
using Presentacion.Core._11_Banco;
using Presentacion.Core._12_CondicionIVA;
using Presentacion.Core._13_Proveedores;
using Presentacion.Core._15_Tarjetas;
using Presentacion.Core._16_Planes_de_tarjeta;
using XCommerce.Servicio.Core._17_Caja.CajaKiosco;
using Presentacion.Core._20_Lista_Precio;
using Presentacion.Core._21_ListaPrecioProducto;
using Presentacion.Core._18_Kiosko;
using XCommerce.Servicio.Core._11_Bancos;
using XCommerce.Servicio.Core._03_Provincia;
using XCommerce.Servicio.Core._06_Rubro;
using XCommerce.Servicio.Core._07_Marca;
using XCommerce.Servicio.Core._12_CondicionIVA;
using XCommerce.Servicio.Core._15_Tarjetas;
using XCommerce.Servicio.Core._20__Lista_Precio;
using XCommerce.Servicio.Core._17_Caja;
using XCommerce.AccesoDatos;
using Presentacion.Core._14_Reserva.Motivo_de_Reserva;
using Presentacion.Core._14_Reserva;

namespace XCommerce
{
    public partial class Principal : Form
    {
        private readonly ICajaSalon cajaSalon;
        public Principal()
        {
            InitializeComponent();

            var Global = new VarGlobalBancos();
            Global.Inicial();

            var Global1 = new VarGlobalProvincias();
            Global1.Iniciar();


            var GlobalRubro = new VarGlobarRubro();
            GlobalRubro.Iniciar();

            var GLobalMarca = new VarGlobalMarcas();
            GLobalMarca.Iniciar();

            var Globa = new VarGlobarIVA();
            Globa.inicializarIVA();

            var Globald = new VarGlobarTarjeta();
            Globald.IniciarTarjeta();

            var ini = new VarGlobalListaPrecio();
            ini.ListaPrecio();

            cajaSalon = new CajaSalon();

        }

        private void consultaDeEmpleadosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fEmpleados = new _00001_Empleados();
            fEmpleados.Show();
        }

        private void consultaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fProvincia = new _00005_Provincia();
            fProvincia.ShowDialog();
        }

        private void nuevaProvinciaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fNuevaProvincia = new _00006_Provincia_ABM(TipoOperacion.Nuevo);
            fNuevaProvincia.ShowDialog();
        }

        private void consultaToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            var fLocalidad = new _00007_Localidad();
            fLocalidad.ShowDialog();
        }

        private void nuevaLocalidadToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fNuevaLocalidad = new _00008_Localidad_ABM(TipoOperacion.Nuevo);
            fNuevaLocalidad.ShowDialog();
        }

        private void nuevoEmpleadoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fNuevoEmpleado = new _00002_ABM_Empleados(TipoOperacion.Nuevo);
            fNuevoEmpleado.ShowDialog();
        }

        private void consultaToolStripMenuItem2_Click(object sender, System.EventArgs e)
        {
            var fClientes = new _00003_Clientes();
            fClientes.ShowDialog();
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fClienteAbm = new _00004_ABM_Cliente(TipoOperacion.Nuevo);
            fClienteAbm.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
        }

        private void consultaToolStripMenuItem3_Click(object sender, System.EventArgs e)
        {

            var fUsuarios = new _00009_Articulos();
            fUsuarios.ShowDialog();

        }

        private void marcaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fmarca = new _00011_Marcas();
            fmarca.ShowDialog();
        }

        private void rubroToolStripMenuItem_Click(object sender, System.EventArgs e)
        {


            var rubro = new _00010_Rubros();
            rubro.ShowDialog();
        }

        private void salonToolStripMenuItem_Click(object sender, System.EventArgs e)
        {



        }

        private void mesaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {



        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var salon = new Venta();
            salon.ShowDialog();
        }

        private void seguridadToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            var fUsuarios = new _00009_Usuario();
            fUsuarios.ShowDialog();
        }

        private void bancosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
           
        }

        private void condicionIVaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var iva = new _00021_CondicionIva();

            iva.ShowDialog();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
           
        }

        private void tarjetaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {


        }

        private void consultaToolStripMenuItem4_Click(object sender, System.EventArgs e)
        {
            var tj = new _00023_Tarjetas();
            tj.ShowDialog();
        }

        private void consultaToolStripMenuItem5_Click(object sender, System.EventArgs e)
        {
            var provv = new _00022_Proveedores();
            provv.ShowDialog();

        }

        private void consultaSalonToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var salon = new _00011_Salon();
            salon.ShowDialog();
        }

        private void consultaMesaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {       
            var salon = new _00019_Mesa();
            salon.ShowDialog();
        }

        private void planesDeTarjetaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var plantj = new _00025_PlanesTarjetas();
            plantj.ShowDialog();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
           
                pnlCaja.Visible = false;
                var abrCaja = new _00022_ABM_CajaSalon(TipoOperacion.Nuevo);
            abrCaja.ShowDialog();
            if (abrCaja.RealizoAlgunaOperacion)
            {
                btnCerCaja.Enabled = true;
                btnAbrirCaja.Enabled = false;
                btnVntaSAlon.Enabled = true;
                btnVenks.Enabled = true;
            }
            

        }

        private void consultaToolStripMenuItem6_Click(object sender, System.EventArgs e)
        {
 var bcos = new _00020_Bancos();
            bcos.ShowDialog();
        }

        private void listasToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            

                 var LPrecio = new _00023_ListaPrecio();
            LPrecio.ShowDialog();
        }

        private void consultaPreciosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var LPrecio = new _00021_ListaPrecioProducto();
            LPrecio.ShowDialog();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            
                var LPrecio = new _00025_kiosko();
            LPrecio.ShowDialog();
        }

        private void Principal_Load(object sender, System.EventArgs e)
        {
            var caja = cajaSalon.ObtenerComprobantePorEstado(EstadoCaja.Abierto);
            if (caja == null)
            {
                btnCerCaja.Enabled = false;
                btnVntaSAlon.Enabled = false;
                btnVenks.Enabled = false;
            }
            else
            {
                btnAbrirCaja.Enabled = false;
            }    
        }

        private void button3_Click_1(object sender, System.EventArgs e)
        {
            pnlCaja.Visible = false;
            var abrCaja = new _00022_ABM_CajaSalon(TipoOperacion.Imprimir);
            abrCaja.ShowDialog();

            if (abrCaja.RealizoAlgunaOperacion)
            {
                btnAbrirCaja.Enabled = true;
                btnCerCaja.Enabled = false;
                btnVntaSAlon.Enabled = false;
                btnVenks.Enabled = false;
            }
           
        }

        private void motivosDeReservaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var fMotivoReserva = new _00022_ReservasMotivo();
            fMotivoReserva.ShowDialog();

        }

        private void consultasToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

            var freserva = new _00022_Reservas();
            freserva.ShowDialog();
        }
    }
}
