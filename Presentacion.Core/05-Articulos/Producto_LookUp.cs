using Presentacion.FormularioBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.Servicio.Core._21_Lista_Precio_Producto.DTos;
using XCommerce.Servicio.Core.Articulo;

namespace Presentacion.Core._05_Articulos
{
    public partial class Producto_LookUp : FormularioLookUp
    {
      
        private readonly long _listaPrecioId;
        private IArticuloServicio _articuloServicio;

        private readonly IListaPrecioProducto listaPrecioProducto;



        public Producto_LookUp()          
        {        

            _articuloServicio = new ArticuloServicio();
            listaPrecioProducto = new ListaPrecioProducto();
            InitializeComponent();
        
        }
        public Producto_LookUp(long listaPrecioId)
              : this()
        {
         
            _listaPrecioId = listaPrecioId;
        }
    
        public override void ActualizarDatos(string cadenaBuscar)
        {
            //dgvGrilla.DataSource = /*_listaPrecioId >  ? listaPrecioProducto.ObtenerLista(cadenaBuscar, _listaPrecioId).ToList() : */listaPrecioProducto.ObtenerTodo();


            var clientes = _articuloServicio.Obtenert(cadenaBuscar);
            dgvGrilla.DataSource = clientes.ToList();
        }
        private void btnBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ActualizarDatos(txtBuscar.Text);
               
            }
        }
        
       

        public override void FormatearGrilla(DataGridView s)
        {
            base.FormatearGrilla(s);

            
            

            s.Columns["Codigo"].Visible = true;
            s.Columns["Codigo"].Width = 100;
            s.Columns["Codigo"].HeaderText = @"Codigo";
            s.Columns["Codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
          
            s.Columns["CodigoBarra"].Visible = true;
            s.Columns["CodigoBarra"].Width = 100;
            s.Columns["CodigoBarra"].HeaderText = @"Codigo Barra";
            s.Columns["CodigoBarra"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
         
            s.Columns["Descripcion"].Visible = true;
            s.Columns["Descripcion"].Width = 100;
            s.Columns["Descripcion"].HeaderText = @"Descripcion";
            s.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            s.Columns["Stock"].Visible = true;
            s.Columns["Stock"].Width = 100;
            s.Columns["Stock"].HeaderText = @"Stock";
            s.Columns["Stock"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        
            s.Columns["Marca"].Visible = true;
            s.Columns["Marca"].Width = 100;
            s.Columns["Marca"].HeaderText = @"Marca";
            s.Columns["Marca"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
         
            s.Columns["Rubro"].Visible = true;
            s.Columns["Rubro"].Width = 100;
            s.Columns["Rubro"].HeaderText = @"Rubro";
            s.Columns["Rubro"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


    }



    private void btnBuscar_TextChanged(object sender, EventArgs e)
        {
            ActualizarDatos(txtBuscar.Text);

        }

        private void Producto_LookUp_Load(object sender, EventArgs e)
        {
            FormatearGrilla(dgvGrilla);
        }
    }
}
