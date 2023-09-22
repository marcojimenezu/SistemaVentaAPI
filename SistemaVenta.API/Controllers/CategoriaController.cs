using Microsoft.AspNetCore.Mvc;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DTO;
using SistemaVenta.DTO.Response;

namespace SistemaVenta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaServicio;

        public CategoriaController(ICategoriaService categoriaServicio)
        {
            _categoriaServicio = categoriaServicio;
        }

        [HttpGet]
        [Route("Lista")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Lista()
        {
            var rsp = Response<List<CategoriaDTO>>.CreateSuccessResponse(await _categoriaServicio.Lista());
            return Ok(rsp);
        }
    }
}