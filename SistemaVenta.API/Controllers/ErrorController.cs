using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaVenta.DTO.Response;

namespace SistemaVenta.API.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ControllerBase
{
    private readonly ILogger<ErrorController> _logger;

    public ErrorController(ILogger<ErrorController> logger)
    {
        _logger = logger;
    }
    
    [Route("/error")]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
    public IActionResult HandleError()
    {
        var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;
        _logger.LogError(exceptionHandlerFeature.Error, "Error trying to resolve request to endpoint {Endpoint} with values {RouteValues}", 
            exceptionHandlerFeature.Endpoint, 
            exceptionHandlerFeature.RouteValues);
        return StatusCode(StatusCodes.Status500InternalServerError,
            Response<string>.CreateErrorResponse(new[] {"An error occurred while processing your request."}));
    }
}