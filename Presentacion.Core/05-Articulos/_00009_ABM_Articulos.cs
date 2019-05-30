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
using XCommerce.Servicio.Core._22_ComprobanteSalon;
using XCommerce.Servicio.Core.Articulo;
using XCommerce.Servicio.Core.DescuantraStok;
using XCommerce.Servicio.Core.Marca;
using XCommerce.Servicio.Core.Rubro;

namespace Presentacion.Core._5_Articulos
{
    public partial class _00009_ABM_Articulos : FormularioAbm
    {
        private readonly IArticuloServicio _articuloServicio;
        private readonly IMarcaServicio _marcaServicio;
        private readonly IRubroServicio _rubroServicio;

        /*=====================*/
        private readonly IComprobanteSalon _comprobanteSalon;
        /*=====================*/



        public _00009_ABM_Articulos(TipoOperacion tipoOperacion, long? entidadId = null)
          : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _articuloServicio = new ArticuloServicio();
            _marcaServicio = new MarcaServicio();
            _rubroServicio = new RubroServicio();

            /*=====================*/
            _comprobanteSalon = new ComprobanteSalon();
            /*=====================*/


            if (tipoOperacion == TipoOperacion.Eliminar || tipoOperacion == TipoOperacion.Modificar)
            {
                CargarDatos(entidadId);
            }

            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtCodigo, "Codigo");
            AgregarControlesObligatorios(txtCodigoBarra, "Codigo de barra");
            AgregarControlesObligatorios(txtDescripcion, "Descripcion");
          



            Inicializador(entidadId);
        }
        /*====================================================*/

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            CargarComboBox(cmbMarca, _marcaServicio.obtner(string.Empty), "Descripcion", "Id");
            CargarComboBox(cmbRubro, _rubroServicio.obtner(string.Empty), "Descripcion", "Id");

            txtCodigo.KeyPress += Validacion.NoLetras;
            txtCodigoBarra.KeyPress += Validacion.NoLetras;


            imgFotoArticulo.Image = Constantes.Imagen.Carrito;

            txtDescripcion.Focus();
        }


        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }


            var nuevoArticulo = new ArtiuculoDto
            {
                Codigo = txtCodigo.Text,

                Descripcion = txtDescripcion.Text,

                Detalle = txtDetalle.Text,

                MarcaId = ((MarcaDto)cmbMarca.SelectedItem).Id,

                CodigoBarra = txtCodigoBarra.Text,

                Abreviatura = txtAbreviatura.Text,              

                RubroId = ((RubroDto)cmbRubro.SelectedItem).Id,

                Stock = nudStock.Value,           

                StockMaximo = nudStockMaximo.Value,

                StockMinimo = nudStokMinimo.Value,

                LimiteDeVenta = nudLimiteVenta.Value,

                Foto = ImagenDb.Convertir_Imagen_Bytes(imgFotoArticulo.Image),
                



            };
            _articuloServicio.Insertar(nuevoArticulo);
            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _articuloServicio.Eliminar(EntidadId.Value);

            return true;
        }


        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            if (archivo.ShowDialog() == DialogResult.OK)
            {

                // Pregunta si Selecciono un Archivo
                if (!string.IsNullOrEmpty(archivo.FileName))
                {
                    imgFotoArticulo.Image = Image.FromFile(archivo.FileName);
                }
                else
                {
                    imgFotoArticulo.Image = Constantes.Imagen.Carrito;
                }
            }
            else
            {
                imgFotoArticulo.Image = Presentacion.Constantes.Imagen.Carrito;
            }

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
            var art = _articuloServicio.ObtenerPorId(entidadId.Value);

            txtCodigo.Text = art.Codigo;
            txtDescripcion.Text = art.Descripcion;
            txtCodigoBarra.Text = art.CodigoBarra;
            txtAbreviatura.Text = art.Abreviatura;
            txtDetalle.Text = art.Detalle;         

            CargarComboBox(cmbMarca, _marcaServicio.obtner(string.Empty), "Descripcion", "Id");
            CargarComboBox(cmbRubro, _rubroServicio.obtner(string.Empty), "Descripcion", "Id");

            nudStock.Value = art.Stock;
            nudStokMinimo.Value = art.StockMinimo;
            nudStockMaximo.Value = art.StockMaximo;
            nudLimiteVenta.Value = art.LimiteDeVenta;
            imgFotoArticulo.Image = ImagenDb.Convertir_Bytes_Imagen(art.Foto);


        }

        public override bool EjecutarComandoModificar()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var empleadoParaModificar = new ArtiuculoDto
            {
                Id = EntidadId.Value,
                Codigo = txtCodigo.Text,
                CodigoBarra = txtCodigoBarra.Text,
                Descripcion = txtDescripcion.Text,
                Abreviatura = txtAbreviatura.Text,
                Detalle = txtDetalle.Text,
                EstaDiscontinuado = ChekEstaDiscontinuado.AllowDrop,
                Stock = nudStock.Value,
                StockMaximo = nudStockMaximo.Value,
                StockMinimo =nudStokMinimo.Value,
                PermitirStokNegativo = ChekPermiteStokNegativo.AllowDrop,
                DescuentaStock = ChekDescuenoEstock.AllowDrop,
                ActivarLimiteDeVenta = ChekLimiteVentaActivar.AllowDrop,
                LimiteDeVenta = nudLimiteVenta.Value,            
              
                MarcaId = ((MarcaDto)cmbMarca.SelectedItem).Id,
                RubroId = ((RubroDto)cmbRubro.SelectedItem).Id,

                Foto = ImagenDb.Convertir_Imagen_Bytes(imgFotoArticulo.Image),

                EstaEliminado = false,
            
            };

            _articuloServicio.Modificar(empleadoParaModificar);

            return true;
        }

        

        private void ChekDescuenta_CheckedChanged(object sender, EventArgs e)
        {         

            var deskstk = new DSTk();

            ArtiuculoDto a; 

            if (ChekDescuenta.Checked == true)
            {
                //deskstk.DescontarStok( 1 , a );
                
            }
        }
    }
}
