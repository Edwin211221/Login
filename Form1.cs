using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Form1 : Form
    {
        Controllers.AuthController _authController = new Controllers.AuthController();
        private int intentos = 0; // <-- Aquí agregas la variable

        public Form1()
        {
            InitializeComponent();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var usuario = new Models.LoginModel
            {
                NombreUsuario = txtUsuario.Text.Trim(),
                Contrasenia = txtContrasenia.Text.Trim()
            };
            var res = _authController.login(usuario);
            if (res == "ok")
            {
                MessageBox.Show("Bienvenido al Sistema");
                var frmMenuPrincipal = new Vistas.FRM_MenuPrincipal();
                this.Hide(); //oculta el formulario
                frmMenuPrincipal.Show();
            }
            else
            {
                intentos++; // Aumenta el contador de intentos
                MessageBox.Show($"Acceso denegado. Intento {intentos} de 3.");
                lblMensaje.Text = res;
                lblMensaje.Visible = true;

                if (intentos >= 3)
                {
                    MessageBox.Show("Ha superado el número de intentos permitidos. La aplicación se cerrará.");
                    Application.Exit();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();   //para cerrar la aplicaicon

            txtContrasenia.Text = "";
            txtUsuario.Text = "";
        }
    }
}
