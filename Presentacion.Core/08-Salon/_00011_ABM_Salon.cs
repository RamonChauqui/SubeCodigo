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
using XCommerce.Servicio.Core._20__Lista_Precio;
using XCommerce.Servicio.Core.Sala;

namespace Presentacion.Core._8_Salon
{
    public partial class _00011_ABM_Salon : FormularioAbm
    {
        private readonly ISalaServicio _salaServicio;
        private readonly IListaPrecioServicio _listaPrecio;

        public _00011_ABM_Salon(TipoOperacion tipoOperacion, long? entidadID = null)
            : base(tipoOperacion, entidadID)
        {
            InitializeComponent();

            _salaServicio = new SalaServicio();
            _listaPrecio = new ListaPrecioServicio();

            if (tipoOperacion == TipoOperacion.Eliminar || tipoOperacion == TipoOperacion.Modificar)
            {
                CargarDatos(entidadID);
            }

            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                DesactivarControles(this);

            }
            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtDescrpcion, "Descripción");

            Inicializador(entidadID);

        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;
            CargarComboBox(CMBListaPrecio, _listaPrecio.obtner(string.Empty), "Descripcion", "Id");


            txtDescrpcion.Focus();
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevaMesa = new SalaDto
            {
                Descripcion = txtDescrpcion.Text,
              //ListaPrecioId = ((ListaPrecioDto)CMBListaPrecio.SelectedItem).Id,
                ListaPrecioId = ((ListaPrecioDto)CMBListaPrecio.SelectedItem).Id,
                DescripcionLista = ((ListaPrecioDto)CMBListaPrecio.SelectedItem).Descripcion,

                EstaEliminado = false,


            };
            _salaServicio.insertar(nuevaMesa);

            return true;
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

            CargarComboBox(CMBListaPrecio, _listaPrecio.obtner(string.Empty), "Descripcion", "Id");


            var sala = _salaServicio.ObtenerPorID(entidadId.Value);


            txtDescrpcion.Text = sala.Descripcion;




        }

        public override bool EjecutarComandoModificar()
        {

            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                return false;
            }

            var salamodific = new SalaDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescrpcion.Text
            };

            _salaServicio.Modificar(salamodific);

            return true;

        }


        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _salaServicio.Eliminar(EntidadId.Value);

            return true;
        }

        private void _00011_ABM_Salon_Load(object sender, EventArgs e)
        {

        }
    }
}
