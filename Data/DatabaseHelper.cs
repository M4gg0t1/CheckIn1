using System;
using System.Collections.Generic;
using System.Data.SqlClient; // Asegúrate de que estás usando el espacio de nombres correcto
using CheckIn.Models;

namespace CheckIn.Data
{
    public class DatabaseHelper
    {
        private string connectionString = "Data Source=.;Initial Catalog=ControlAsistenciaDB;Integrated Security=True";

        // Obtener todos los usuarios
        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Usuarios";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(new Usuario
                            {
                                Id = (int)reader["Id"],
                                Correo = reader["Correo"].ToString(),
                                Contraseña = reader["Contraseña"].ToString(), // Considera cifrar la contraseña
                                Rol = reader["Rol"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores (puedes registrar el error o mostrar un mensaje)
                throw new Exception("Error al obtener usuarios: " + ex.Message);
            }

            return usuarios;
        }

        // Agregar un nuevo usuario
        public void AgregarUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Usuarios (Correo, Contraseña, Rol) VALUES (@correo, @contraseña, @rol)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@correo", usuario.Correo);
                        command.Parameters.AddWithValue("@contraseña", usuario.Contraseña); // Considera cifrar la contraseña
                        command.Parameters.AddWithValue("@rol", usuario.Rol);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar usuario: " + ex.Message);
            }
        }

        // Modificar un usuario existente
        public void ModificarUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Usuarios SET Correo = @correo, Contraseña = @contraseña, Rol = @rol WHERE Id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", usuario.Id);
                        command.Parameters.AddWithValue("@correo", usuario.Correo);
                        command.Parameters.AddWithValue("@contraseña", usuario.Contraseña); // Considera cifrar la contraseña
                        command.Parameters.AddWithValue("@rol", usuario.Rol);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar usuario: " + ex.Message);
            }
        }

        // Eliminar un usuario por ID
        public void EliminarUsuario(int usuarioId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Usuarios WHERE Id = @usuarioId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@usuarioId", usuarioId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar usuario: " + ex.Message);
            }
        }

        // Eliminar asistencias por ID de usuario
        public void EliminarAsistenciasPorUsuario(int usuarioId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Asegúrate de que 'UsuarioId' es el nombre correcto de la columna
                var command = new SqlCommand("DELETE FROM Asistencia WHERE UsuarioId = @usuarioId", connection);
                command.Parameters.AddWithValue("@usuarioId", usuarioId);
                command.ExecuteNonQuery();
            }
        }

        // Métodos adicionales para registrar asistencia se pueden agregar aquí.
    }
} 
