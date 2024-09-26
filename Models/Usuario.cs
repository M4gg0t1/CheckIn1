namespace CheckIn.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; } // Por ejemplo: "Empleado" o "Administrador"

        // Sobrescribir ToString para mostrar el correo en el ComboBox
        public override string ToString()
        {
            return Correo; // Aquí puedes cambiar a cualquier otro campo que desees mostrar
        }
    }
}