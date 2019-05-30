using Presentacion.Core._05_Articulos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.Servicio.Core._19_Producto;
using XCommerce.Servicio.Core._19_Producto.ProductoMesa;
using XCommerce.Servicio.Core._19_ProductoXMesa;
using XCommerce.Servicio.Core._20__Lista_Precio;
using XCommerce.Servicio.Core._21_Lista_Precio_Producto.DTos;
using XCommerce.Servicio.Core._22_ComprobanteSalon;
using XCommerce.Servicio.Core._22_ComprobanteSalon.Dtos;
using XCommerce.Servicio.Core.Articulo;
using XCommerce.Servicio.Core.Empleado;
using XCommerce.Servicio.Core.Empleado.DTOs;
using XCommerce.Servicio.Core.Mesa_Comprobante;
using XCommerce.Servicio.Core.Mesa_Comprobante.DTO;
using XCommerce.Servicio.Core.Sala;

namespace Presentacion.Core._10_Ventas_Salon
{
    public partial class _00019_ComprobanteSalon : Form
    {
        private long _ClienteID;

        private ComprobanteSalonDto _comprobante;

        public delegate void ActualizarTotal(decimal total);

        public event ActualizarTotal ActualizarTotalDelControlMesa;

        public virtual void OnActualizarTotalDelControlMesa(decimal total)
        {
            ActualizarTotalDelControlMesa?.Invoke(total);
        }

        private ArtiuculoDto _articulo;


        private EmpleadoDto _empleado;

        private ComporobanteSAlonDetalleDto _comprobantedetalle;
        public ComprobanteSalonDto Comprobante;
       



        private long _mesaId;//C2
        private readonly IComprobanteMesaServicio _comprobanteMesaServicio;
        private readonly IProductoServicio _productoServicio;

        private readonly ISalaServicio _salaServicio;
        private readonly IComprobanteSalon _comprobanteSalon;//C2
        private readonly IListaPrecioServicio _listaPrecioServicio; 
        private readonly IListaPrecioProducto _listaPrecioProducto;
        private readonly IEmpleadoServicio _empladoServicio;

        private readonly IProductoMesa _productoMesa;

        private readonly IArticuloServicio _articuloServicio;




        public _00019_ComprobanteSalon()
           : this(new ComprobanteMesaServicio(), new ProductoServicio(), new ComprobanteSalon(), new ListaPrecioServicio(),/* new ProductoMesaServicio(),*/ new ArticuloServicio(), new SalaServicio())
        {
            InitializeComponent();
            nudDescuento.Enabled = false;


        }
        public _00019_ComprobanteSalon(IComprobanteMesaServicio comprobante, IProductoServicio productoServicio, /**/ IComprobanteSalon comprobanteSalon, 
            IListaPrecioServicio listaPrecioServicio,/* IProductoMesa productoMesa,*/ IArticuloServicio articuloServicio, ISalaServicio salaServicio)
        {
            _comprobanteMesaServicio = comprobante;
            _productoServicio = productoServicio;
            _salaServicio = salaServicio;
            

            _productoServicio = new ProductoServicio();
            _listaPrecioProducto = new ListaPrecioProducto();
            _empladoServicio = new EmpleadoServicio();
       

            //_productoMesa = productoMesa;//C2
            _comprobanteSalon = comprobanteSalon;

            _articuloServicio = articuloServicio;
        }

        public _00019_ComprobanteSalon(long  mesaId, int nuemroMesa )// necesito saber el valor de la mesa porque el comprobante para salir necesita saber de que mesa es para traer los datos de esas mesa
          : this()
        {
            this.Text = $"Venta de salon - Mesa {nuemroMesa}  ";
            this._mesaId = mesaId;
            ObtenerComprobanteMEsa(_mesaId);

        }

        /*==========================================================================*/
        private void ObtenerComprobanteMEsa(long mesaId)
        {
            ActualizarGrilla(_mesaId);
        }

        private void ActualizarGrilla(long _mesaId)
        {
            
            _comprobante = _comprobanteSalon.ObtenerComprobantePorMesa(_mesaId);
            if (_comprobante == null)
            {
                _comprobanteMesaServicio.AbrirMesa(1, _mesaId, 1, 1);
                _comprobante = _comprobanteSalon.ObtenerComprobantePorMesa(_mesaId);
                dgvGrilla.DataSource = _comprobante.ComprobanteSalonDetalleDtos.ToList();

                nudSubTotoal.Value = _comprobante.ComprobanteSalonDetalleDtos.Sum(x=> x.SubTotal);
                nudTotal.Value = _comprobante.Total;
            }
            else
            {
                dgvGrilla.DataSource = _comprobante.ComprobanteSalonDetalleDtos.ToList();

                nudSubTotoal.Value = _comprobante.ComprobanteSalonDetalleDtos.Sum(x => x.SubTotal);
                //numericUpDown2.Value = _comprobante.Total;
                nudTotal.Value = _comprobante.Total;
            }
            
            //nudDescuento.Value = comprobante.Descueto;
        
          
        }
        public virtual void FormatearGrilla(DataGridView dgvGrilla)
        {
            for (int i = 0; i < dgvGrilla.ColumnCount; i++)
            {
                dgvGrilla.Columns[i].Visible = false;
                dgvGrilla.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvGrilla.Columns["Codigo"].Visible = true;
            dgvGrilla.Columns["Codigo"].Width = 100;
            dgvGrilla.Columns["Codigo"].HeaderText = @"Código";

            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Descripcion"].HeaderText = @"Descripción";

            dgvGrilla.Columns["Precio"].Visible = true;
            dgvGrilla.Columns["Precio"].Width = 100;
            dgvGrilla.Columns["Precio"].HeaderText = @"Precio";

            dgvGrilla.Columns["Cantidad"].Visible = true;
            dgvGrilla.Columns["Cantidad"].Width = 50;
            dgvGrilla.Columns["Cantidad"].HeaderText = @"Cantidad";

            //dgvGrilla.Columns["Stock"].Visible = true;
            //dgvGrilla.Columns["Stock"].Width = 50;
            //dgvGrilla.Columns["Stock"].HeaderText = @"Cantidad";


            dgvGrilla.Columns["SubTotal"].Visible = true;
            dgvGrilla.Columns["SubTotal"].Width = 100;
            dgvGrilla.Columns["SubTotal"].HeaderText = @"SubTotal";

            


        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)

        {
            #region C4
            if (e.KeyChar == (char)Keys.Enter)
            {

                if (string.IsNullOrEmpty(txtCodigo.Text))
                {
                    MessageBox.Show("Por favor ingrese el CODIGO");
                    return;

                }


                //BUSCAR EL PRODUCTO
                var producto = _articuloServicio.ObtenerPorDescripcion(txtCodigo.Text);
                if (producto != null)/*Esto no trabaja en memoria*/
                {
                    var sala = _salaServicio.ObtenerSalaPorMesa(_mesaId);
                    if (sala != null)
                    {


                    
                        if (producto.Stock > 0)
                        {

                            _comprobanteSalon.AgregarItem(_comprobante.Id, (int)nudCantidad.Value, producto, sala.ListaPrecioId);
                            _articuloServicio.DisminuirStock(producto);
                        }
                        else
                        {
                            MessageBox.Show("No hay stock del producto");
                        }
                    }
                    else
                    {//es el internet 
                        return;
                    }
                    
                    

                    ActualizarGrilla(_mesaId);

                }
                else
                {

                    var lookUpProducto = new Producto_LookUp();
                    lookUpProducto.ShowDialog();

                    var productoSeleccionado = (ArtiuculoDto)lookUpProducto.Entidad;
                    var listaPrecioProducto = _listaPrecioProducto.ObtenerListaPorProductoId(productoSeleccionado.Id);
                    if (listaPrecioProducto == null) return; //CambioPorElimiar
                    productoSeleccionado.PrecioPublico = listaPrecioProducto.PrecioPublico;
                    txtCodigo.Text = productoSeleccionado.Codigo.ToString();
                    txtDescripcion.Text = productoSeleccionado.Descripcion.ToString();
                    //txtPrecios.Text = productoSeleccionado.PrecioPublico.ToString();



                    //if (_comprobante != null)
                    //        {
                    //            _comprobanteSalon.AgregarItem(_comprobante.Id, 1, productoSeleccionado, 1 );
                    //    _comprobante = _comprobanteSalon.ObtenerComprobantePorMesa(_ClienteID);

                    //            //dgvGrilla.DataSource = _comprobante.ComprobanteSalonDetalleDtos.ToList();
                    //           // nudTOTAL.Value = _comprobante.ComprobanteKioscoDetalleDtos.Sum(x => x.SubTotoal);
                    //            nudCantidad.Enabled = true;
                    //        }


                }


            }

            #endregion
        }
          

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Por favor ingrese el CODIGO");
                return;

            }


            //BUSCAR EL PRODUCTO
            var producto = _articuloServicio.ObtenerPorDescripcion(txtCodigo.Text);
            if (producto != null)/*Esto no trabaja en memoria*/
            {
                var listaPrecioProducto = _listaPrecioProducto.ObtenerListaPorProductoId(producto.Id);
                if (listaPrecioProducto != null)
                {


                    producto.PrecioPublico = listaPrecioProducto.PrecioPublico;

                    if (producto.Stock > 0)
                    {

                        _comprobanteSalon.AgregarItem(_comprobante.Id, (int)nudCantidad.Value, producto, listaPrecioProducto.Id);
                        _articuloServicio.DisminuirStock(producto);
                    }
                    else
                    {
                        MessageBox.Show("No hay stock del producto");

                    }
                }
                else
                {
                    return;
                }



                ActualizarGrilla(_mesaId);

            }
            else
            {
                //
                var lookUpProducto = new Producto_LookUp();
                lookUpProducto.ShowDialog();

                var productoSeleccionado = (ArtiuculoDto)lookUpProducto.Entidad;
                var listaPrecioProducto = _listaPrecioProducto.ObtenerListaPorProductoId(productoSeleccionado.Id);
                productoSeleccionado.PrecioPublico = listaPrecioProducto.PrecioPublico;
                txtCodigo.Text = productoSeleccionado.Codigo.ToString();
                txtDescripcion.Text = productoSeleccionado.Descripcion.ToString();
                txtPrecios.Text = productoSeleccionado.PrecioPublico.ToString();


                if (_comprobante != null)
                {
                    _comprobanteSalon.AgregarItem(_comprobante.Id, 2, productoSeleccionado, 2);
                    _comprobante = _comprobanteSalon.ObtenerComprobantePorMesa(_ClienteID);

                    //dgvGrilla.DataSource = _comprobante.ComprobanteSalonDetalleDtos.ToList();
                    // nudTOTAL.Value = _comprobante.ComprobanteKioscoDetalleDtos.Sum(x => x.SubTotoal);
                    nudCantidad.Enabled = true;
                }
            }

            }

            private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void _00019_ComprobanteSalon_Load(object sender, EventArgs e)
        {
            _comprobante = _comprobanteSalon.ObtenerComprobantePorMesa(_mesaId);
            if (_comprobante != null)
            {
                FormatearGrilla(dgvGrilla);

            }
        }

        private void nudSubTotoal_ValueChanged(object sender, EventArgs e)
        {
            OnActualizarTotalDelControlMesa(!string.IsNullOrEmpty(nudSubTotoal.Text) ? nudSubTotoal.Value : 0 );
        }

        private void btnDescuento_Click(object sender, EventArgs e)
        {
            nudDescuento.Enabled = true;
        }

        private void nudDescuento_ValueChanged(object sender, EventArgs e)
        {

            _comprobante = _comprobanteSalon.ObtenerComprobantePorMesa(_mesaId);
            if (_comprobante != null)
            {
                _comprobanteSalon.Descuento(_comprobante.Id, (int)nudDescuento.Value);
                ActualizarGrilla(_mesaId);
            }

        }
    }
}
