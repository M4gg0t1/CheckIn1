using System;
using System.Windows.Forms;

namespace CheckIn.Forms
{
    public partial class AgregarUsuarioForm : Form
    {
        public string NuevoCorreo { get; private set; }
        public string NuevaContraseña { get; private set; }
        public string NuevoRol { get; private set; }

        public AgregarUsuarioForm()
        {
            InitializeComponent();
            // Inicializa ComboBox con roles
            comboBoxRol.Items.Add("Empleado");
            comboBoxRol.Items.Add("Administrador");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Obtener valores de los campos
            NuevoCorreo = txtCorreo.Text;
            NuevaContraseña = txtContraseña.Text;
            NuevoRol = comboBoxRol.SelectedItem?.ToString();

            // Validar que todos los campos estén llenos
            if (string.IsNullOrEmpty(NuevoCorreo) || string.IsNullOrEmpty(NuevaContraseña) || string.IsNullOrEmpty(NuevoRol))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
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
    }
}