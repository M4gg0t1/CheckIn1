using System;
using System.Linq;
using System.Windows.Forms;
using CheckIn.Data;

namespace CheckIn.Forms
{
    public partial class LoginForm : Form
    {
        private DatabaseHelper dbHelper;

        public LoginForm()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            pictureBox1.Visible = true; // Asegúrate de que el PictureBox sea visible.
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var usuarios = dbHelper.ObtenerUsuarios();
            var usuarioEncontrado =
              usuarios.FirstOrDefault(u => u.Correo == txtCorreo.Text && u.Contraseña == txtContraseña.Text);

            if (usuarioEncontrado != null)
            {
                MainForm mainForm =
                   new MainForm(usuarioEncontrado.Id); // Pasar ID del usuario.
                mainForm.Show();
                this.Hide(); // Ocultar el formulario de login.
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.");
            }
        }
    }
}