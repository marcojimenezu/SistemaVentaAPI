using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DTO;
using SistemaVenta.DTO.Response;

namespace SistemaVenta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoServicio;

        public ProductoController(IProductoService productoServicio)
        {
            _productoServicio = productoServicio;
        }

        [HttpGet]
        [Route("Lista")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Lista()
        {
            var rsp = Response<List<ProductoDTO>>.CreateSuccessResponse(await _productoServicio.Lista());
            return Ok(rsp);
        }

        [HttpPost]
        [Route("Guardar")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Guardar([FromBody] ProductoDTO producto)
        {
            var rsp = Response<ProductoDTO>.CreateSuccessResponse(await _productoServicio.Crear(producto));
            return Ok(rsp);
        }

        [HttpPut]
        [Route("Editar")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Editar([FromBody] ProductoDTO producto)
        {
            var rsp = Response<bool>.CreateSuccessResponse(await _productoServicio.Editar(producto));
            return Ok(rsp);
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Eliminar(int id)
        {
            var rsp = Response<bool>.CreateSuccessResponse(await _productoServicio.Eliminar(id));
            return Ok(rsp);
        }
    }
}