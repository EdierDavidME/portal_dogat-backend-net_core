using System.Data;
using Dogat_backend_net_core.Utilities.Data;

namespace Dogat_backend_net_core.Adapters.Usuarios
{
    public class UsuariosParser : Parser
    {
        public static Models.Usuarios.Usuarios Parse(ref Models.Usuarios.Usuarios usuario, IDataReader reader)
        {
            usuario.id = GetDataValue<int>(reader, "Id");
            usuario.cedula_Nit = GetDataValue<string>(reader, "Cedula_Nit");
            usuario.nombre = GetDataValue<string>(reader, "Nombre");
            usuario.correo = GetDataValue<string>(reader, "Correo");
            usuario.planActivoId = GetDataValue<int>(reader, "PlanActivoId");
            usuario.fechaVencimiento = GetDataValue<DateTime>(reader, "FechaVencimiento");
            usuario.publicacionesRestantes = GetDataValue<int>(reader, "PublicacionesRestantes");
            usuario.rol = GetDataValue<int>(reader, "Rol");

            return usuario;
        }
    }
}
