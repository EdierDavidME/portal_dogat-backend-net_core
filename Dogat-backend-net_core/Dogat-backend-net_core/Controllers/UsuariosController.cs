using Dogat_backend_net_core.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Dogat_backend_net_core.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosAdapter usuarios;

        public UsuariosController(IUsuariosAdapter usuarios)
        {
            this.usuarios = usuarios;
        }

        [HttpPost("autenticacionusuario")]
        public IActionResult AutenticacionUsuario([FromBody]List<string> credenciales)
        {
            Usuarios result = new Usuarios();

            if (credenciales.Count() < 2)
                return BadRequest("Cantidad de datos insuficientes");

            result = this.usuarios.AutenticacionUsuario(credenciales[0], credenciales[1]);

            if(result.id == -1)
                return BadRequest("Fallo en servicio de consulta");

            return Ok(result);
        }

        [HttpPost("nuevousuario")]
        public IActionResult NuevoUsuario([FromBody]Usuarios usuario)
        {
            int Id = this.usuarios.NuevoUsuario(usuario);

            if(Id > 0)
                return Ok(Id);
            else
                if(Id == -1)
                    return BadRequest("Fallo en servicio de consulta");
                else
                    return BadRequest("No se pudo completar el registro");
        }

        [HttpPut("modificarusuario")]
        public IActionResult ModificarUsuario([FromBody]Usuarios usuario)
        {
            if (this.usuarios.ModificarUsuario(usuario))
                return Ok(true);
            else
                return BadRequest("Error al tratar de modificar el usuario");
        }
    }
}
