using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SistemaVenta.API.Utilidad;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DTO;

namespace SistemaVenta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioServicio;

        public UsuarioController(IUsuarioService usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        [HttpGet]
        [Route("Lista")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<UsuarioDTO>>
            {
                status = true,
                value = await _usuarioServicio.Lista()
            };

            return Ok(rsp);
        }


        [HttpPost]
        [Route("IniciarSesion")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IniciarSesion([FromBody] LoginDTO login)
        {
            var rsp = new Response<SesionDTO>
            {
                status = true,
                value = await _usuarioServicio.ValidarCredenciales(login.Correo, login.Clave)
            };

            return Ok(rsp);
        }

        [HttpPost]
        [Route("Guardar")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Guardar([FromBody] UsuarioDTO usuario)
        {
            var rsp = new Response<UsuarioDTO>
            {
                status = true,
                value = await _usuarioServicio.Crear(usuario)
            };

            return Ok(rsp);
        }

        [HttpPut]
        [Route("Editar")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Editar([FromBody] UsuarioDTO usuario)
        {
            var rsp = new Response<bool>
            {
                status = true,
                value = await _usuarioServicio.Editar(usuario)
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
                value = await _usuarioServicio.Eliminar(id)
            };

            return Ok(rsp);
        }
    }
}
