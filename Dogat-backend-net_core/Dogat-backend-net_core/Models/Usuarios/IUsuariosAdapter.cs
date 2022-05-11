namespace Dogat_backend_net_core.Models.Usuarios
{
    public interface IUsuariosAdapter
    {
        Models.Usuarios.Usuarios AutenticacionUsuario(string user, string contrasena);
        int NuevoUsuario(Models.Usuarios.Usuarios usuario);
        bool ModificarUsuario(Models.Usuarios.Usuarios usuario);
    }
}
