using Microsoft.AspNetCore.Mvc;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DTO;
using SistemaVenta.DTO.Response;

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
            var rsp = Response<List<RolDTO>>.CreateSuccessResponse(await _rolServicio.Lista());
            return Ok(rsp);
        }
    }
}