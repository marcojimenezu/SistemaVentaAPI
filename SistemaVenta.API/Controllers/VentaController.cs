using Microsoft.AspNetCore.Mvc;
using SistemaVenta.API.Utilidad;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DTO;

namespace SistemaVenta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _ventaServicio;

        public VentaController(IVentaService ventaServicio)
        {
            _ventaServicio = ventaServicio;
        }

        [HttpPost]
        [Route("Registrar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Registrar([FromBody] VentaDTO venta)
        {
            var rsp = new Response<VentaDTO>
            {
                status = true,
                value = await _ventaServicio.Registrar(venta)
            };

            return Ok(rsp);
        }

        [HttpGet]
        [Route("Historial")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Historial(string buscarPor, string? numeroVenta, string? fechaInicio,
            string? fechaFin)
        {
            var rsp = new Response<List<VentaDTO>>();
            numeroVenta ??= string.Empty;
            fechaInicio ??= string.Empty;
            fechaFin ??= string.Empty;
            rsp.status = true;
            rsp.value = await _ventaServicio.Historial(buscarPor, numeroVenta, fechaInicio, fechaFin);

            return Ok(rsp);
        }

        [HttpGet]
        [Route("Reporte")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Reporte(string? fechaInicio, string? fechaFin)
        {
            var rsp = new Response<List<ReporteDTO>>
            {
                status = true,
                value = await _ventaServicio.Reporte(fechaInicio, fechaFin)
            };

            return Ok(rsp);
        }
    }
}