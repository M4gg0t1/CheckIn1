using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CheckIn.Models;

namespace CheckIn.Services
{
    public class AsistenciaService
    {
        private string connectionString = "Data Source=.;Initial Catalog=ControlAsistenciaDB;Integrated Security=True";

        // Método para marcar entrada
        public void MarcarEntrada(int usuarioId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Asistencia (UsuarioId, Fecha, HoraEntrada) VALUES (@usuarioId, @fecha, @hora)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuarioId", usuarioId);
                command.Parameters.AddWithValue("@fecha", DateTime.Now.Date);
                command.Parameters.AddWithValue("@hora", DateTime.Now.TimeOfDay);
                command.ExecuteNonQuery();
            }
        }

        // Método para marcar salida
        public void MarcarSalida(int usuarioId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Asistencia SET HoraSalida = @hora WHERE UsuarioId = @usuarioId AND Fecha = @fecha AND HoraSalida IS NULL";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuarioId", usuarioId);
                command.Parameters.AddWithValue("@fecha", DateTime.Now.Date);
                command.Parameters.AddWithValue("@hora", DateTime.Now.TimeOfDay);
                command.ExecuteNonQuery();
            }
        }

        // Método para obtener reportes mensuales
        public List<Asistencia> ObtenerReportesMensuales(int usuarioId, int mes, int año)
        {
            List<Asistencia> asistencias = new List<Asistencia>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Asistencia WHERE UsuarioId = @usuarioId AND MONTH(Fecha) = @mes AND YEAR(Fecha) = @año";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuarioId", usuarioId);
                command.Parameters.AddWithValue("@mes", mes);
                command.Parameters.AddWithValue("@año", año);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        asistencias.Add(new Asistencia
                        {
                            Id = (int)reader["Id"],
                            UsuarioId = (int)reader["UsuarioId"],
                            Fecha = (DateTime)reader["Fecha"],
                            HoraEntrada = reader["HoraEntrada"] as TimeSpan?,
                            HoraSalida = reader["HoraSalida"] as TimeSpan?
                        });
                    }
                }
            }

            return asistencias;
        }

        // Método para obtener todas las asistencias de un usuario
        public List<Asistencia> ObtenerTodasLasAsistencias(int usuarioId)
        {
            List<Asistencia> asistencias = new List<Asistencia>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Asistencia WHERE UsuarioId = @usuarioId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuarioId", usuarioId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        asistencias.Add(new Asistencia
                        {
                            Id = (int)reader["Id"],
                            UsuarioId = (int)reader["UsuarioId"],
                            Fecha = (DateTime)reader["Fecha"],
                            HoraEntrada = reader["HoraEntrada"] as TimeSpan?,
                            HoraSalida = reader["HoraSalida"] as TimeSpan?
                        });
                    }
                }
            }

            return asistencias;
        }
    }
}