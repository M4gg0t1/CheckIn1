using System;
using System.Windows.Forms;
using CheckIn.Data; // Asegúrate de que esta referencia sea correcta
using CheckIn.Models; // Importa el espacio de nombres donde se encuentra Usuario

namespace CheckIn.Forms
{
    public partial class EliminarUsuarioForm : Form
    {
        public int UsuarioIdAEliminar { get; private set; }

        public EliminarUsuarioForm()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            var dbHelper = new DatabaseHelper();
            var usuarios = dbHelper.ObtenerUsuarios(); // Asegúrate de que este método devuelva una lista de usuarios

            foreach (var usuario in usuarios)
            {
                comboBoxUsuarios.Items.Add(usuario); // Esto ahora mostrará el correo gracias a ToString()
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (comboBoxUsuarios.SelectedItem != null)
            {
                UsuarioIdAEliminar = ((Usuario)comboBoxUsuarios.SelectedItem).Id; // Asegúrate de que esto sea correcto
                this.DialogResult = DialogResult.OK; // Establecer resultado del diálogo a OK
                this.Close(); // Cerrar el formulario
            }
            else
            {
                MessageBox.Show("Debes seleccionar un usuario para eliminar.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Establecer resultado del diálogo a Cancel
            this.Close(); // Cerrar el formulario
        }

       
    }
}