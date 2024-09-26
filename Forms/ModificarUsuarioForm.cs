using System;
using System.Drawing;
using System.Windows.Forms;

namespace CheckIn.Forms
{
    public partial class ModificarUsuarioForm : Form
    {
        public string NuevoCorreo { get; private set; }
        public string NuevaContraseña { get; private set; }
        public string NuevoRol { get; private set; }

        public ModificarUsuarioForm()
        {
            InitializeComponent();
            // Inicializa ComboBox con roles
            comboBoxRol.Items.Add("Empleado");
            comboBoxRol.Items.Add("Administrador");

            // Establecer texto de marcador de posición
            txtCorreo.Text = "Nuevo Correo";
            txtCorreo.ForeColor = Color.Gray;

            txtContraseña.Text = "Nueva Contraseña";
            txtContraseña.ForeColor = Color.Gray;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Obtener valores de los campos
            NuevoCorreo = txtCorreo.Text == "Nuevo Correo" ? null : txtCorreo.Text;
            NuevaContraseña = txtContraseña.Text == "Nueva Contraseña" ? null : txtContraseña.Text;
            NuevoRol = comboBoxRol.SelectedItem?.ToString();

            // Validar que al menos uno de los campos esté lleno
            if (string.IsNullOrEmpty(NuevoCorreo) && string.IsNullOrEmpty(NuevaContraseña) && string.IsNullOrEmpty(NuevoRol))
            {
                MessageBox.Show("Debes ingresar al menos un campo para modificar.");
                return;
            }

            this.DialogResult = DialogResult.OK; // Establecer resultado del diálogo a OK
            this.Close(); // Cerrar el formulario
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Establecer resultado del diálogo a Cancel
            this.Close(); // Cerrar el formulario
        }

        private void txtCorreo_Enter(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "Nuevo Correo")
            {
                txtCorreo.Text = "";
                txtCorreo.ForeColor = Color.Black; // Cambia el color del texto al negro.
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                txtCorreo.Text = "Nuevo Correo";
                txtCorreo.ForeColor = Color.Gray; // Cambia el color del texto a gris.
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "Nueva Contraseña")
            {
                txtContraseña.Text = "";
                txtContraseña.UseSystemPasswordChar = true; // Mostrar caracteres como contraseña.
                txtContraseña.ForeColor = Color.Black; // Cambia el color del texto al negro.
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                txtContraseña.Text = "Nueva Contraseña";
                txtContraseña.UseSystemPasswordChar = false; // No mostrar caracteres como contraseña.
                txtContraseña.ForeColor = Color.Gray; // Cambia el color del texto a gris.
            }
        }
    }
}