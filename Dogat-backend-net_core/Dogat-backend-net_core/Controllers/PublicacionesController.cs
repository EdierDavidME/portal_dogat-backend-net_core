using Dogat_backend_net_core.Adapters;
using Dogat_backend_net_core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dogat_backend_net_core.Controllers
{
    [Route("api/publicaciones")]
    [ApiController]
    public class PublicacionesController : ControllerBase
    {
        private readonly IPublicacionesAdapter publicaciones;
        public PublicacionesController(IPublicacionesAdapter publicaciones)
        {
            this.publicaciones = publicaciones;
        }

        [HttpGet("getpaises")]
        public IActionResult GetPaises()
        {
            List<Paises> listPaises = this.publicaciones.GetPaises();
            return Ok(listPaises);
        }
    }
}
