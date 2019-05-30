using System;
using System.Windows.Forms;
using XCommerce.Servicio.Seguridad.Usuario;
using XCommerce.Servicio.Seguridad.Usuario.DTOs;


namespace Presentacion.Seguridad.Usuario
{
    public partial class _00009_Usuario : FormularioBase.FormularioBase
    {
     
        private readonly IUsuarioServicio _usuarioServicio;
        private object entidad; 

        public _00009_Usuario()
        {
            InitializeComponent();

            btnNuevo.Image = Presentacion.Constantes.Imagen.BotonNuevo;
            btnEliminar.Image = Presentacion.Constantes.Imagen.BotonEliminar;
            btnActualizar.Image = Presentacion.Constantes.Imagen.BotonActualizar;
            btnSalir.Image = Presentacion.Constantes.Imagen.BotonSalir;
            imgBuscar.Image = Presentacion.Constantes.Imagen.Buscar;

            _usuarioServicio = new UsuarioServicio();
            entidad = null;
        }

        private void ActualizarDatos(string cadenaBuscar)
        {
            dgvGrilla.DataSource = _usuarioServicio.Obtener(!string.IsNullOrEmpty(cadenaBuscar) 
                ? cadenaBuscar : string.Empty);

            FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            for (int i = 0; i < dgvGrilla.ColumnCount; i++)
            {
                dgvGrilla.Columns[i].Visible = false;
            }

            
            dgvGrilla.Columns["ApyNom"].Visible = true;
            dgvGrilla.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["ApyNom"].HeaderText = @"Apellido y Nombre";
            dgvGrilla.Columns["ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dgvGrilla.Columns["Nombre"].Visible = true;
            dgvGrilla.Columns["Nombre"].Width = 200;
            dgvGrilla.Columns["Nombre"].HeaderText = @"Usuario";
            dgvGrilla.Columns["Nombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dgvGrilla.Columns["EstaBloqueadoStr"].Visible = true;
            dgvGrilla.Columns["EstaBloqueadoStr"].Width = 100;
            dgvGrilla.Columns["EstaBloqueadoStr"].HeaderText = @"Bloqueado";
            dgvGrilla.Columns["EstaBloqueadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrilla.Columns["EstaBloqueadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void _00009_Usuario_Load(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(txtBuscar.Text);
        }

        private void txtBuscar_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ActualizarDatos(txtBuscar.Text);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (entidad == null) return;
            var usuarioSeleccionado = (UsuarioDto) entidad;
            _usuarioServicio.Crear(usuarioSeleccionado.PersonaId, 
                usuarioSeleccionado.ApellidoPersona, usuarioSeleccionado.NombrePersona);
            ActualizarDatos(string.Empty);
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            entidad = dgvGrilla.RowCount > 0 
                ? dgvGrilla.Rows[e.RowIndex].DataBoundItem 
                : null;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (entidad == null || ((UsuarioDto)entidad).Nombre == "NO ASIGNADO") return;
            var usuarioSeleccionado = (UsuarioDto)entidad;
            _usuarioServicio.CambiarEstado(usuarioSeleccionado.Nombre, !usuarioSeleccionado.EstaBloqueado);

            var mensaje = usuarioSeleccionado.EstaBloqueado 
                ? @"El usuario se Desbloqueo correctamente"
                : @"El usuario se Bloqueo Correctamente";

            ActualizarDatos(string.Empty);

            MessageBox.Show(mensaje, @"Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
