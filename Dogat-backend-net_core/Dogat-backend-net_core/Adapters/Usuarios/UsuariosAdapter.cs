using Dogat_backend_net_core.Models;
using Dogat_backend_net_core.Models.Usuarios;
using Dogat_backend_net_core.Utilities.Conection;
using Dogat_backend_net_core.Utilities.Data;

namespace Dogat_backend_net_core.Adapters.Usuarios
{
    public class UsuariosAdapter: IUsuariosAdapter
    {
        public Models.Usuarios.Usuarios AutenticacionUsuario(string user, string contrasena)
        {
            Models.Usuarios.Usuarios usuario = new Models.Usuarios.Usuarios();

            string strQuery =  string.Format("SELECT TOP 1 *FROM Usuarios WHERE (Cedula_Nit = '{0}' OR Correo = '{0}') AND Contrasena = '{1}';", user, contrasena);
            ConectionManager objConnection = new ConectionManager();
            try
            {

                using (var objDataReader = objConnection.GetDataReader(strQuery))
                {
                    while (objDataReader.Read())
                    {
                        UsuariosParser.Parse(ref usuario, objDataReader);
                    }
                }
            } catch (Exception ex) {
                objConnection.Close();
                usuario.id = -1;
            };

            objConnection.Close();

            return usuario;
        }

        public int NuevoUsuario(Models.Usuarios.Usuarios usuario)
        {
            int Id = 0;

            string strQuery = string.Format(String.Concat("INSERT INTO Usuarios (Cedula_Nit, Nombre, Correo, Contrasena, PublicacionesRestantes, Rol) ",
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', {5}); SELECT SCOPE_IDENTITY() AS Id;"),
                usuario.cedula_Nit, usuario.nombre, usuario.correo, usuario.contrasena, usuario.publicacionesRestantes, usuario.rol);

            ConectionManager objConnection = new ConectionManager();

            try
            {

                using (var objDataReader = objConnection.GetDataReader(strQuery))
                {
                    while (objDataReader.Read())
                    {
                        Id = Parser.GetDataValue<int>(objDataReader, "Id");
                    }
                }
            }
            catch (Exception ex) {
                objConnection.Close();
                return -1;
            }

            objConnection.Close();

            return Id;
        }

        public bool ModificarUsuario(Models.Usuarios.Usuarios usuario)
        {
            string strQuery = string.Format(String.Concat("UPDATE Usuarios SET " +
                "Cedula_Nit = '{0}', Nombre = '{1}', Correo = '{2}', Contrasena = '{3}' WHERE Id = {4}"),
                usuario.cedula_Nit, usuario.nombre, usuario.correo, usuario.contrasena, usuario.id);

            ConectionManager objConnection = new ConectionManager();

            try
            {
                objConnection.ExecuteTransaction(strQuery);
            }
            catch (Exception ex)
            {
                objConnection.Close();

                return false;
            }

            objConnection.Close();

            return true;
        }

        public bool ActualizarPlan(int usuarioId, int planId)
        {
            Planes plan = new Planes();

            string strQueryPlan = string.Format("SELECT *From Planes WHERE Id = {0}", planId);

            //ConectionManager objConnection = new ConectionManager();
            //try
            //{

            //    using (var objDataReader = objConnection.GetDataReader(strQueryPlan))
            //    {
            //        while (objDataReader.Read())
            //        {
            //            UsuariosParser.Parse(ref usuario, objDataReader);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objConnection.Close();
            //    usuario.Id = -1;
            //};





            //string strQuery = string.Format(String.Concat("UPDATE Usuarios SET " +
            //    "PlanActivoId = {0}, FechaVencimiento = {1}, PublicacionesRestantes = {2} WHERE Id = {3}"),
            //    usuario.PlanActivoId, Parser.DateTimeToString(usuario.FechaVencimiento), usuario.PublicacionesRestantes, usuario.Id);

            //ConectionManager objConnection = new ConectionManager();

            //try
            //{
            //    objConnection.ExecuteTransaction(strQuery);
            //}
            //catch (Exception ex)
            //{
            //    objConnection.Close();

            //    return false;
            //}

            //objConnection.Close();

            return true;
        }
    }
}
