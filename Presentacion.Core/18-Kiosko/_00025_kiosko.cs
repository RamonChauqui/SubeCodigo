using Presentacion.Core._01_Empleado;
using Presentacion.Core._02_Cliente;
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
using XCommerce.Servicio.Core._00_Base;
using XCommerce.Servicio.Core._20__Lista_Precio;
using XCommerce.Servicio.Core._21_Lista_Precio_Producto.DTos;
using XCommerce.Servicio.Core._23_ComporbanteKiosco;
using XCommerce.Servicio.Core.Articulo;
using XCommerce.Servicio.Core.Cliente.DTOs;
using XCommerce.Servicio.Core.Empleado;
using XCommerce.Servicio.Core.Empleado.DTOs;
using XCommerce.Servicio.Core.ServicioKiosco;
using XCommerce.Servicio.Core.ServicioKiosco.Dto;

namespace Presentacion.Core._18_Kiosko
{
     

    public partial class _00025_kiosko : Presentacion.FormularioBase.FormularioBase
    {
        //       private long _ClienteID;

        //       long _mesaId;
        //       public long MesaID { set => _mesaId = value; }

        //       private ComprobanteKioscoDto _comporbante;
        private readonly IListaPrecioServicio _listaPrecio;

        //       private readonly IComprobanteKiosco _comprobantkisoco;
        //       private IListaPrecioServicio _listaPrecioServicio;
        private IArticuloServicio _productoServicio;
        //       private readonly IListaPrecioProducto _listaPrecioProducto;
        //       private readonly IEmpleadoServicio _EmpleadoServicio;
        private long listaId;
        private Factura _factura;
        private DetalleFactura _nuevoDetalle;
        private FacturaDto _Dto = new FacturaDto();


        

        public _00025_kiosko()
                   : this(/*new ComprobanteKiosco(),*/ new ArticuloServicio())
        //                 , new ListaPrecioServicio(), new EmpleadoServicio())
        {
            InitializeComponent();
            _factura = new Factura();
            _nuevoDetalle = new DetalleFactura();

            _listaPrecio = new ListaPrecioServicio();


           

        }
        public _00025_kiosko(/*IComprobanteKiosco comprobanteKiosco, */IArticuloServicio articuloServicio
          /*  IListaPrecioServicio listaPrecioServicio, IEmpleadoServicio empleadoServicio*/)
        {
            //           _comprobantkisoco = comprobanteKiosco;
            _productoServicio = articuloServicio;
            //           _listaPrecioServicio = listaPrecioServicio;
            //           _EmpleadoServicio = empleadoServicio;
            //           _listaPrecioProducto = new ListaPrecioProducto();
        }

        //       public override void FormatearGrilla(DataGridView dgvGrilla)
        //       {
        //           base.FormatearGrilla(dgvGrilla);
        //           dgvGrilla.Columns["Descripcion"].Visible = true;
        //           dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //           dgvGrilla.Columns["Descripcion"].HeaderText = @"Descripción";

        //           dgvGrilla.Columns["PrecioUnitario"].Visible = true;
        //           dgvGrilla.Columns["PrecioUnitario"].Width = 100;
        //           dgvGrilla.Columns["PrecioUnitario"].HeaderText = @"Precio";

        //           dgvGrilla.Columns["Cantidad"].Visible = true;
        //           dgvGrilla.Columns["Cantidad"].Width = 50;
        //           dgvGrilla.Columns["Cantidad"].HeaderText = @"Cantidad";

        //           dgvGrilla.Columns["SubTotoal"].Visible = true;
        //           dgvGrilla.Columns["SubTotoal"].Width = 100;
        //           dgvGrilla.Columns["SubTotoal"].HeaderText = @"SubTotal";

        //           dgvGrilla.Columns["Codigo"].Visible = true;
        //           dgvGrilla.Columns["Codigo"].Width = 100;
        //           dgvGrilla.Columns["Codigo"].HeaderText = @"Código";

        //       }

        //       protected override CreateParams CreateParams
        //       {
        //           get
        //           {
        //               CreateParams cp = base.CreateParams;
        //               cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED
        //               return cp;
        //           }

        //       }

        //       private void _00025_kiosko_Load(object sender, EventArgs e)
        //       {

        //           CargarDatos();
        //       }

        //private void CargarDatos()
        //{
        //    CargarComboBox(cmbListaPrecio, _listaPrecioServicio.obtner(string.Empty), "Descripcion", "Id");


        //    txtFecha.Text = DateTime.Now.ToString();
        //    if (_ClienteID != 0)
        //    {
        //        _comporbante = _comprobantkisoco.ObtenerComprobantePorCliente(_ClienteID);

        //        nudTOTAL.Value = _comporbante.ComprobanteKioscoDetalleDtos.Sum(x => x.SubTotoal);
        //        dgvGrilla.DataSource = _comporbante.ComprobanteKioscoDetalleDtos.ToList();

        //        FormatearGrilla(dgvGrilla);


        //    }
        //}

        //       private void txtFacturar_Click(object sender, EventArgs e)
        //       {

        //           //var comprobante = _comprobantkisoco.ObtenerComprobantePorkiosco(_mesaId);

        //           //if (comprobante.TotalVentas == 0)
        //           //{

        //           //    return;
        //           //}
        //           //else
        //           //{

        //           var pagarFactura = new _10000_FormaDePAgo();
        //           pagarFactura.ShowDialog();
        //           //}






        //       }

        private void CalcularTotales()
        {
            nudSubTotal.Value = _factura.SubTotal;

            _factura.Total = _factura.SubTotal - (_factura.SubTotal * (_factura.Descuento / 100m));
            nudTotal.Value = _factura.Total;
        }

        private void ActualizarGrilla()
        {
            dgvGrilla.DataSource = _factura.Items.ToList();

        }

        private void _00025_kiosko_Load(object sender, EventArgs e)
        {
            CargarComboBox(cmbListaPrecio, _listaPrecio.obtner(string.Empty), "Descripcion", "Id");


            // 2 Paso: Obtener el siguiente numero de factura

            _factura.Numero = FacturaServicio.ObtenerSiguienteNumeroDeFactura();
            // 3 Paso: Actualizar Grilla Items
            txtDescripcion.Enabled = true;
            ActualizarGrilla();
            FormatearGrilla();
            CalcularTotales();
          
            this.nudCantidad.Value = 1;
        }

        private void FormatearGrilla()
        {
            // 1) Ocultar Todas las Columnas
            for (int i = 0; i < dgvGrilla.ColumnCount; i++)
            {
                dgvGrilla.Columns[i].Visible = false;
            }

            // 2) Mostrar Columnas
            dgvGrilla.Columns["Codigo"].Visible = true;
            dgvGrilla.Columns["Codigo"].Width = 70;
            dgvGrilla.Columns["Codigo"].HeaderText = @"Código";

            dgvGrilla.Columns["CodigoBarra"].Visible = true;
            dgvGrilla.Columns["CodigoBarra"].Width = 100;
            dgvGrilla.Columns["CodigoBarra"].HeaderText = @"CodigoBarra";

            dgvGrilla.Columns["Precio"].Visible = true;
            dgvGrilla.Columns["Precio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Precio"].HeaderText = @"Precio";

            dgvGrilla.Columns["SubTotal"].Visible = true;
            dgvGrilla.Columns["SubTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["SubTotal"].HeaderText = @"SubTotal";

            dgvGrilla.Columns["Descripcion"].Visible = true;
            dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Descripcion"].HeaderText = @"Descripcion";

            dgvGrilla.Columns["Cantidad"].Visible = true;
            dgvGrilla.Columns["Cantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Cantidad"].HeaderText = @"Cantidad";

        }

        private void txtDescripcion_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((char)Keys.Enter != e.KeyChar) return;

            _nuevoDetalle = new DetalleFactura();

           
            var producto = _productoServicio.ObtenerPorDescripcionLista(txtDescripcion.Text,((ListaPrecioDto)cmbListaPrecio.SelectedItem).Id);
            if (string.IsNullOrEmpty(txtDescripcion.Text)) return;

            if (producto != null)
            
            {


                txtDescripcion.Text = producto.Descripcion;
                nudCantidad.Enabled = true;

                //btnAgregar.Focus();
                if (!_factura.Items.Any(x => x.Codigo == producto.Codigo && x.Precio == producto.PrecioPublico ) )
                {
                    var nuevoItem = new Item();
                    var newItem2 = new Item2();

                    nuevoItem.Cantidad = (int)nudCantidad.Value;
                    nuevoItem.Producto = producto;

                    _nuevoDetalle.CodigoDeDetalle = _factura.Numero;
                    newItem2.Codigo = _nuevoDetalle.CodigoDeDetalle;
                    newItem2.CodigoBarra = producto.CodigoBarra;
                    newItem2.Descripcion = producto.Descripcion;
                    newItem2.Precio = producto.PrecioPublico;
                    newItem2.Cantidad = nuevoItem.Cantidad;
                    nuevoItem.Precio = producto.PrecioPublico;
                    nuevoItem.Cantidad = nuevoItem.Cantidad;
                    newItem2.SubTotal = nuevoItem.Cantidad * newItem2.Precio;
                    newItem2.IdProducto = producto.CodigoBarra;



                    var det = ServicioDetalleFactura.ObetenerFacturaPorCodigo(_factura.Numero);

                    if (det != null)
                    {
                        det.Items.Add(newItem2);
                    }
                    else
                    {
                        _nuevoDetalle.Items.Add(newItem2);
                    }


                    if (producto.Stock >= nudCantidad.Value)
                    {
                        producto.Stock -= nudCantidad.Value;
                        _factura.Items.Add(nuevoItem);

                    }


                }
                else
                {
                    // Buscar elproducto en lalista de items para modificar la cantidad
                    var item = _factura.Items.First(x => x.Codigo == producto.Codigo && x.Precio == producto.PrecioPublico);
                    item.Cantidad += (int)nudCantidad.Value;

                    var inicio = ServicioDetalleFactura.ObetenerFacturaPorCodigo(_factura.Numero);
                    var prueba = inicio.Items.First(x => x.CodigoBarra == producto.CodigoBarra && x.Precio == producto.PrecioPublico);
                    prueba.Cantidad += (int)nudCantidad.Value;
                    prueba.SubTotal = prueba.Cantidad * prueba.Precio;
                }

            }
            else
            {
                var lookUpProducto = new Producto_LookUp();
                lookUpProducto.ShowDialog();
                if (lookUpProducto.Entidad != null)
                {


                    var productoSeleccionado = (ArtiuculoDto)lookUpProducto.Entidad;
                    //aca
                    txtDescripcion.Text = productoSeleccionado.Descripcion;
                    producto = _productoServicio.ObtenerPorDescripcionLista(txtDescripcion.Text, ((ListaPrecioDto)cmbListaPrecio.SelectedItem).Id);

                    nudCantidad.Value = 1;
                    //txtDescripcion.Focus();

                    if (!_factura.Items.Any(x => x.Codigo == producto.Codigo && x.Precio == producto.PrecioPublico))
                    {
                        var nuevoItem = new Item();
                        var newItem2 = new Item2();

                        nuevoItem.Cantidad = (int)nudCantidad.Value;
                        nuevoItem.Producto = producto;

                        _nuevoDetalle.CodigoDeDetalle = _factura.Numero;
                        newItem2.Codigo = _nuevoDetalle.CodigoDeDetalle;
                        newItem2.CodigoBarra = producto.CodigoBarra;
                        newItem2.Descripcion = producto.Descripcion;
                        newItem2.Precio = producto.PrecioPublico;
                        newItem2.Cantidad = nuevoItem.Cantidad;
                        nuevoItem.Precio = producto.PrecioPublico;
                        nuevoItem.Cantidad = nuevoItem.Cantidad;
                        newItem2.SubTotal = nuevoItem.Cantidad * newItem2.Precio;
                        newItem2.IdProducto = producto.CodigoBarra;

                        var det = ServicioDetalleFactura.ObetenerFacturaPorCodigo(_factura.Numero);

                        if (det != null)
                        {
                            det.Items.Add(newItem2);
                        }
                        else
                        {
                            _nuevoDetalle.Items.Add(newItem2);
                        }


                        if (producto.Stock >= nudCantidad.Value)
                        {
                            producto.Stock -= nudCantidad.Value;
                            _factura.Items.Add(nuevoItem);

                        }


                    }
                    else
                    {
                        // Buscar elproducto en lalista de items para modificar la cantidad

                        var item = _factura.Items.First(x => x.Codigo == producto.Codigo && x.Precio == producto.PrecioPublico);
                        item.Cantidad += (int)nudCantidad.Value;

                        var inicio = ServicioDetalleFactura.ObetenerFacturaPorCodigo(_factura.Numero);
                        var prueba = inicio.Items.First(x => x.CodigoBarra == producto.CodigoBarra && x.Precio == producto.PrecioPublico);
                        prueba.Cantidad += (int)nudCantidad.Value;
                        prueba.SubTotal = prueba.Cantidad * prueba.Precio;
                    }


                }
            }
            //////////////////////////////////////////
            _factura.Descuento = nudDescuento.Value;
            ActualizarGrilla();
            CalcularTotales();

            ///////////////////////////////////////////////////////////




            /////////////////////////////////////
            if (_nuevoDetalle != null)
            {
                ServicioDetalleFactura.Insertar(_nuevoDetalle);
            }


            producto = null; // Reiniciar para una nueva busqueda
            txtDescripcion.Clear();
            _nuevoDetalle = null;
            nudCantidad.Value = 1;

        }

        private void txtFacturar_Click(object sender, EventArgs e)
        {

            if (_factura.Total == 0)
            {
                Mensaje.Mostrar("No se cargo ningun producto", Mensaje.Tipo.Informacion);
                return;
            }
            else
            {
                var pagarFactura = new _10000_FormaDePAgo(_factura);
                pagarFactura.ShowDialog();
                if (pagarFactura.RealizoOperacion)
                {
                    _LimpiarParaNuevaFactura();

                }
               
            }
        }

        private void _LimpiarParaNuevaFactura()
        {
            _nuevoDetalle = null;
            _factura = new Factura();
            nudDescuento.Value = 0;
            ActualizarGrilla();
            CalcularTotales();

            _factura.Numero = FacturaServicio.ObtenerSiguienteNumeroDeFactura();
        }

        private void nudDescuento_ValueChanged(object sender, EventArgs e)
        {
            _factura.Descuento = nudDescuento.Value;
            CalcularTotales();
        }

        private void btnDescuento_Click(object sender, EventArgs e)
        {
            nudDescuento.Enabled = true;
        }
    }

        //       private void btnLookUpCliente_Click(object sender, EventArgs e)
        //       {
        //var lookUpProducto = new ClienteAccesoRapido();
        //           lookUpProducto.ShowDialog();
        //           if (lookUpProducto.Entidad != null)
        //           {
        //               var EmpleadoSeleccionado = (ClienteDto)lookUpProducto.Entidad;
        //               txtCliente.Text = EmpleadoSeleccionado.Id.ToString();
        //               lblCliente.Text = EmpleadoSeleccionado.Apellido + " " + EmpleadoSeleccionado.Nombre;

        //               _ClienteID = EmpleadoSeleccionado.Id;
        //               if (_comporbante == null)
        //               {


        //                       _comprobantkisoco.Crear(_ClienteID, new ComprobanteKioscoDto
        //                       {
        //                           ClienteId = _ClienteID,
        //                           TotalVentas = nudTOTAL.Value,


        //                       });
        //                       CargarDatos();


        //               }
        //           }
        //       }

        //       private void btnLookUpEmpleado_Click(object sender, EventArgs e)
        //       {

        //       }

        //       private void txtEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        //       {
        //           if (string.IsNullOrEmpty(txtCliente.Text)) return;
        //           if ((char)Keys.Enter != e.KeyChar) return;

        //           var Empleado = BusaEmpelado(txtCliente.Text);

        //           if (Empleado != null)
        //           {

        //               var EmpaeldoSeleccionado = _EmpleadoServicio.ObtenerPorLegajo(txtCliente.Text);
        //               txtCliente.Text = EmpaeldoSeleccionado.Legajo.ToString();

        //           }
        //           else
        //           {
        //               var lookUpProducto = new Empleado_LookUp();// despues
        //               lookUpProducto.ShowDialog();
        //               if (lookUpProducto.Entidad != null)
        //               {
        //                   var EmpleadoSeleccionado = (EmpleadoDto)lookUpProducto.Entidad;
        //                   txtCliente.Text = EmpleadoSeleccionado.Id.ToString();


        //               }


        //           }

        //       }

        //       private object BusaEmpelado(string text)
        //       {
        //           return _EmpleadoServicio.ObtenerPorLegajo(text);
    //    // 
    //  }
    //}
}
