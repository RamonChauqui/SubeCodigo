using System;
using System.Windows.Forms;
using Presentacion.Constantes;
using XCommerce.Servicio.Seguridad.Seguridad;
using XCommerce.Servicio.Seguridad.Usuario;
using Color = System.Drawing.Color;

namespace Presentacion.Seguridad
{
    public partial class Login : Form
    {
        // Atributos / Variables

        private readonly IAccesoSistema _accesoSistema;
        private readonly IUsuarioServicio _usuarioServicio;

        private int _cantidadAccesosFallidos;

        // Propiedades
        public bool PuedeAccederSistema { get; protected set; }

        public Login()
            
        {
            InitializeComponent();

            //Asignar los eventos

            imgLogo.Image = Imagen.Login;
            imgOjo.Image = Imagen.OjoPassword;
        }

        public Login(IAccesoSistema accesoSistema, IUsuarioServicio usuarioServicio)
            : this()
        {
            _accesoSistema = accesoSistema;

            _cantidadAccesosFallidos = 0;
        }

        private void BtnIngresar_Click(object sender, System.EventArgs e)
        {
            // 1 - Verificar si esta cargado el usuario
            // 2 - verificar si esta cargado el password

            if (!VerificarDatosObligatorios()) return;

            // 3 - verificar si el usuario y la Pass son Correctos (Autenticacion)
            if (_accesoSistema.VerificarSiExisteUsuario(txtUsuario.Text, txtPassoword.Text))
            {
                // 5 - Verificar si Esta Bloqueado
                if (!_accesoSistema.VerificarSiEstaBloqueadoUsuario(txtUsuario.Text))
                {
                    // 7 - Cuando este correcto ingresar al sistema.

                    PuedeAccederSistema = true;

                    this.Close(); // Cierro el Formulario de Login
                }
                else
                {
                    // 6 - Si esta bloqueado mostrar mensaje
                    MessageBox.Show(@"El Usuario esta BLOQUEADO.");

                    txtPassoword.Clear();

                    txtUsuario.Clear();

                    txtUsuario.Focus();

                    _cantidadAccesosFallidos = 0;

                    PuedeAccederSistema = false;

                    return;
                }

            }
            else
            {
                PuedeAccederSistema = false;

                // 4 - Si no existe mostrar Mensaje
                MessageBox.Show(@"El usuario o la contraseña son incorrectos.");

                txtPassoword.Clear();

                txtPassoword.Focus();

                // incrementar los Intentos Fallidos
                _cantidadAccesosFallidos++;

                if (_cantidadAccesosFallidos >= 3)
                {
                    try
                    {
                        // Bloquear el Usuario
                        _usuarioServicio.CambiarEstado(txtUsuario.Text, true);
                        // Notificar al Usuario que esta Bloqueado
                        MessageBox.Show(@"El Usuario FUE BLOQUEADO. Comunicarse con el Adminsitrador.");
                        Application.Exit();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                        txtPassoword.Clear();
                        txtPassoword.Focus();
                    }
                        
                }
            }
        }

        private bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show(@"El nombre de Usuario es Obligatorio.");
                return false;
            }

            if (string.IsNullOrEmpty(txtPassoword.Text))
            {
                MessageBox.Show(@"La contraseña es Obligatoria.");
                return false;
            }

            return true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Esta seguro que desea salir", @"Atencion", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == @"USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
            ;
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = @"USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtPassoword_Enter(object sender, EventArgs e)
        {
            if (txtPassoword.Text == @"CONTRASEÑA")
            {
                txtPassoword.Text = "";
                txtPassoword.ForeColor = Color.LightGray;
                txtPassoword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassoword_Leave(object sender, EventArgs e)
        {
            if (txtPassoword.Text == "")
            {
                txtPassoword.Text = @"CONTRASEÑA";
                txtPassoword.ForeColor = Color.DimGray;
                txtPassoword.UseSystemPasswordChar = false;
            }
        }

        private void imgOjo_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassoword.PasswordChar = Char.MinValue;
        }

        private void imgOjo_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassoword.PasswordChar = '*';
        }
    }
}
