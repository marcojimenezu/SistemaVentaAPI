using Microsoft.AspNetCore.Mvc;
using SistemaVenta.API.Utilidad;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DTO;

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
            var rsp = new Response<List<ProductoDTO>>
            {
                status = true,
                value = await _productoServicio.Lista()
            };

            return Ok(rsp);
        }

        [HttpPost]
        [Route("Guardar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Guardar([FromBody] ProductoDTO producto)
        {
            var rsp = new Response<ProductoDTO>
            {
                status = true,
                value = await _productoServicio.Crear(producto)
            };

            return Ok(rsp);
        }

        [HttpPut]
        [Route("Editar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Editar([FromBody] ProductoDTO producto)
        {
            var rsp = new Response<bool>
            {
                status = true,
                value = await _productoServicio.Editar(producto)
            };

            return Ok(rsp);
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Eliminar(int id)
        {
            var rsp = new Response<bool>
            {
                status = true,
                value = await _productoServicio.Eliminar(id)
            };

            return Ok(rsp);
        }
    }
}