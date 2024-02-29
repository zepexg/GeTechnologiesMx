using Business.Abstract;
using Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorioController : ControllerBase
    {
        private readonly IDirectorioService _service;
        public DirectorioController(IDirectorioService service) {
            _service = service;
        }

        [HttpGet("findPersonas")]
        public IActionResult FindPersonas()
        {
            return Ok(_service.FindPersonas());
        }

        [HttpGet("findPersonaByIdentificacion")]
        public IActionResult FindPersonaByIdentificacion(string Identificacion)
        {
            return Ok(_service.FindById(Identificacion));
        }

        [HttpPost("storePersona")]
        public IActionResult StorePersona(PersonaModel Persona)
        {
            return Ok(_service.Store(Persona));
        }

        [HttpDelete("deletePersonaByIdentificacion")]
        public IActionResult DeletePersonaByIdentificacion(string Identificacion)
        {
            _service.DeletePersonaByIdentificacion(Identificacion);
            return Ok();
        }
    }
}
