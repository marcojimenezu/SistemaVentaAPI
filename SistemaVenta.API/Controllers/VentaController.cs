using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DTO;
using SistemaVenta.DTO.Response;

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
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Registrar([FromBody] VentaDTO venta)
        {
            var rsp = Response<VentaDTO>.CreateSuccessResponse(await _ventaServicio.Registrar(venta));
            return Ok(rsp);
        }

        [HttpGet]
        [Route("Historial")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Historial(string buscarPor, string? numeroVenta, string? fechaInicio,
            string? fechaFin)
        {
            numeroVenta ??= string.Empty;
            fechaInicio ??= string.Empty;
            fechaFin ??= string.Empty;
            var rsp = Response<List<VentaDTO>>.CreateSuccessResponse(
                await _ventaServicio.Historial(buscarPor, numeroVenta, fechaInicio, fechaFin));
            return Ok(rsp);
        }

        [HttpGet]
        [Route("Reporte")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Reporte(string? fechaInicio, string? fechaFin)
        {
            var rsp = Response<List<ReporteDTO>>.CreateSuccessResponse(await _ventaServicio.Reporte(fechaInicio, fechaFin));
            return Ok(rsp);
        }
    }
}