using Business.Abstract;
using Entity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IVentaService _service;
        public FacturaController(IVentaService service)
        {
            _service = service;
        }

        [HttpGet("findFacturasByPersona")]
        public ActionResult FindFacturasByPersona(Guid Persona)
        {
            return Ok(_service.FindById(Persona));
        }

        [HttpPost("storeFactura")]
        public IActionResult StoreFactura(FacturaModel Factura)
        {
            return Ok(_service.Store(Factura));
        }
    }
}
