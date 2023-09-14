using Microsoft.AspNetCore.Mvc;
using SistemaVenta.API.Utilidad;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DTO;

namespace SistemaVenta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolServicio;

        public RolController(IRolService rolServicio)
        {
            _rolServicio = rolServicio;
        }

        [HttpGet]
        [Route("Lista")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<RolDTO>>
            {
                status = true,
                value = await _rolServicio.Lista()
            };

            return Ok(rsp);
        }
    }
}