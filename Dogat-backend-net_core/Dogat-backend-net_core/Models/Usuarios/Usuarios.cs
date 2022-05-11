namespace Dogat_backend_net_core.Models.Usuarios
{
    public class Usuarios
    {
		public int id { get; set; }
		public string cedula_Nit { get; set; }
		public string nombre { get; set; }
		public string correo { get; set; }
		public string contrasena { get; set; }
		public int planActivoId { get; set; }
		public DateTime fechaVencimiento { get; set; }
		public int publicacionesRestantes { get; set; }
		public int rol { get; set; } // 1: Admin, 2: Cliente
	}
}
