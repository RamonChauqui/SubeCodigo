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
using XCommerce.Servicio.Core._00_Base;
using XCommerce.Servicio.Core._20__Lista_Precio;
using XCommerce.Servicio.Core._21_Lista_Precio_Producto.DTos;
using XCommerce.Servicio.Core.Articulo;

namespace Presentacion.Core._21_ListaPrecioProducto
{
    public partial class _00021_ABM_ListaPrecioProducto : FormularioAbm
    {
        private readonly IListaPrecioProducto _listaPrecioProducto;
        private readonly IListaPrecioServicio _listaPrecioServicio; 
        private readonly IArticuloServicio _articuloServicio; 

        public _00021_ABM_ListaPrecioProducto(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
     

            _articuloServicio = new ArticuloServicio();
            _listaPrecioServicio = new ListaPrecioServicio();
            _listaPrecioProducto = new ListaPrecioProducto();

            Inicializador(entidadId);

            if (tipoOperacion == TipoOperacion.Eliminar || tipoOperacion == TipoOperacion.Modificar)
            {
                CargarDatos(entidadId);
            }

            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                DesactivarControles(this);
            }
            AsignarEventoEnterLeave(this);

        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            CargarComboBox(cmbProducto, _articuloServicio.Obtenert(string.Empty), "Descripcion", "Id");
            CargarComboBox(cmdLista, _listaPrecioServicio.obtner(string.Empty), "Descripcion", "Id");
            
            // Asignando un Evento            
        }


        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            try
            {
                var nuevalista = new ListaPecioProductoDto()
                {
                    ListaPrecioId = ((ListaPrecioDto)cmdLista.SelectedItem).Id,
                    ArticuliId = ((ArtiuculoDto)cmbProducto.SelectedItem).Id,
                    PrecioCosto = nudPrecioCosto.Value,
                    PrecioPublico = nudPrecioPublico.Value,
                    FechaActualizacion = dtpFecha.Value,
                    EstaEliminado = false,
                    HoraVenta = dtpActivarHOraventa.Value,
                    ActivarHoraVenta = chActivarHoraVenta.AllowDrop,
                };

                _listaPrecioProducto.CrearListaPrecioProducto(nuevalista);
                return true;
            }
            catch (Exception)
            {
                throw;
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

            var Precios = _listaPrecioProducto.ObtenerPorId(entidadId.Value);

            CargarComboBox(cmdLista, _listaPrecioServicio.obtner(string.Empty), "Descripcion", "Id");
            CargarComboBox(cmbProducto, _articuloServicio.Obtenert(string.Empty), "Descripcion", "Id");

            nudPrecioCosto.Value = Precios.PrecioCosto;
            nudPrecioPublico.Value = Precios.PrecioPublico;
            dtpActivarHOraventa.Value = Precios.HoraVenta;
            




        }
        public override bool EjecutarComandoEliminar()
        {
            try
            {
                _listaPrecioProducto.Eliminar(_listaPrecioProducto.ObtenerPorId((long)EntidadId));
                Mensaje.Mostrar("Los datos se eliminaron correctamente", Mensaje.Tipo.Informacion);
                return true;
            }
            catch (Exception ex)
            {

                Mensaje.Mostrar(ex.Message, Mensaje.Tipo.Stop);
                return false;
            }
        }
        public override bool EjecutarComandoModificar()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var PrecioModificar = new ListaPecioProductoDto
            {
                Id = EntidadId.Value,
                ArticuliId = ((ArtiuculoDto)cmbProducto.SelectedItem).Id,
                ListaPrecioId = ((ListaPrecioDto)cmdLista.SelectedItem).Id,            
                PrecioCosto = nudPrecioCosto.Value,
                PrecioPublico = nudPrecioPublico.Value,
                FechaActualizacion = dtpFecha.Value,
                EstaEliminado = false,
                HoraVenta = dtpActivarHOraventa.Value,
                ActivarHoraVenta = chActivarHoraVenta.AllowDrop,
            };

            _listaPrecioProducto.Modificar(PrecioModificar);

            return true;
        }

        private void _00021_ABM_ListaPrecioProducto_Load(object sender, EventArgs e)
        {

        }
    }

}
