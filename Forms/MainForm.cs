using System;
using System.Linq;
using System.Windows.Forms;
using CheckIn.Services;
using CheckIn.Models;
using CheckIn.Data;

namespace CheckIn.Forms
{
    public partial class MainForm : Form
    {
        private AsistenciaService asistenciaService;
        private DatabaseHelper dbHelper;
        private int usuarioId;
        private string usuarioRol; // Variable para almacenar el rol del usuario

        public MainForm(int idUsuario)
        {
            InitializeComponent(); // Esto llama al método generado automáticamente.
            asistenciaService = new AsistenciaService();
            dbHelper = new DatabaseHelper();
            usuarioId = idUsuario;

            // Obtener el rol del usuario
            var usuario = dbHelper.ObtenerUsuarios().FirstOrDefault(u => u.Id == idUsuario);
            if (usuario != null)
            {
                usuarioRol = usuario.Rol;

                // Habilitar o deshabilitar botones según el rol del usuario
                if (usuarioRol != "Administrador")
                {
                    btnAgregarUsuario.Enabled = false;
                    btnModificarUsuario.Enabled = false;
                    btnEliminarUsuario.Enabled = false;
                }
            }

            // Aquí puedes cargar los usuarios en un DataGridView o ComboBox si es necesario.
        }

        private void btnMarcarEntrada_Click(object sender, EventArgs e)
        {
            try
            {
                asistenciaService.MarcarEntrada(usuarioId);
                MessageBox.Show($"Entrada marcada: {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al marcar entrada: {ex.Message}");
            }
        }

        private void btnMarcarSalida_Click(object sender, EventArgs e)
        {
            try
            {
                asistenciaService.MarcarSalida(usuarioId);
                MessageBox.Show($"Salida marcada: {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al marcar salida: {ex.Message}");
            }
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            var asistencias = asistenciaService.ObtenerTodasLasAsistencias(usuarioId);

            if (asistencias.Count == 0)
            {
                MessageBox.Show("No hay registros de asistencia.");
                return;
            }

            string reportesText = "Reportes de Asistencia:\n\n";
            foreach (var asistencia in asistencias)
            {
                reportesText += $"Fecha: {asistencia.Fecha.ToShortDateString()}, " +
                                $"Entrada: {(asistencia.HoraEntrada.HasValue ? asistencia.HoraEntrada.Value.ToString(@"hh\:mm") : "No registrada")}, " +
                                $"Salida: {(asistencia.HoraSalida.HasValue ? asistencia.HoraSalida.Value.ToString(@"hh\:mm") : "No registrada")}\n";
            }

            MessageBox.Show(reportesText);
        }

        // Método para agregar un usuario
        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            using (var agregarUsuarioForm = new AgregarUsuarioForm())
            {
                if (agregarUsuarioForm.ShowDialog() == DialogResult.OK)
                {
                    Usuario nuevoUsuario = new Usuario
                    {
                        Correo = agregarUsuarioForm.NuevoCorreo,
                        Contraseña = agregarUsuarioForm.NuevaContraseña,
                        Rol = agregarUsuarioForm.NuevoRol ?? "Empleado" // Asigna rol por defecto si no se selecciona.
                    };

                    dbHelper.AgregarUsuario(nuevoUsuario); // Agregar nuevo usuario a la base de datos.
                    MessageBox.Show("Usuario agregado.");
                }
            }
        }

        // Método para modificar un usuario
        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            using (var modificarUsuarioForm = new ModificarUsuarioForm())
            {
                if (modificarUsuarioForm.ShowDialog() == DialogResult.OK)
                {
                    Usuario modificarUsuario = new Usuario
                    {
                        Id = 1, // Debes seleccionar el ID del usuario a modificar
                        Correo = modificarUsuarioForm.NuevoCorreo,
                        Contraseña = modificarUsuarioForm.NuevaContraseña,
                        Rol = modificarUsuarioForm.NuevoRol ?? "Empleado" // Asigna rol por defecto si no se selecciona.
                    };

                    dbHelper.ModificarUsuario(modificarUsuario); // Modificar el usuario en la base de datos.
                    MessageBox.Show("Usuario modificado.");
                }
            }
        }

        // Método para eliminar un usuario
        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            using (var eliminarUsuarioForm = new EliminarUsuarioForm())
            {
                if (eliminarUsuarioForm.ShowDialog() == DialogResult.OK)
                {
                    int idAEliminar = eliminarUsuarioForm.UsuarioIdAEliminar;

                    try
                    {
                        // Primero elimina las asistencias relacionadas
                        dbHelper.EliminarAsistenciasPorUsuario(idAEliminar); // Asegúrate que este método esté bien definido

                        // Luego elimina el usuario
                        dbHelper.EliminarUsuario(idAEliminar);
                        MessageBox.Show("Usuario eliminado.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar usuario: {ex.Message}");
                    }
                }
            }
        }
    }
}