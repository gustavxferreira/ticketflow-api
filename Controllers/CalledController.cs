using Microsoft.AspNetCore.Mvc;
using TicketFlowApi.DTOs;
using TicketFlowApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace TicketFlowApi.Controllers;

[ApiController]
[Route("api")]
[Authorize]
public class CalledController : ControllerBase
{
    private readonly ILogger<CalledController> _logger;
    private readonly ICalledService _calledService;

    public CalledController(ILogger<CalledController> logger, ICalledService calledService)
    {
        _logger = logger;
        _calledService = calledService;
    }

    [HttpGet("chamados")]
    public String CalledList()
    {
        return "listar chamados";
    }

    [AllowAnonymous]
    [HttpPost("chamados")]
    public async Task<IActionResult> CreateCalled([FromBody] CalledCreateDTO dto)
    {
        await _calledService.CreateCalledAsync(dto);

        return Created("", new { message = "Chamado criado com sucesso" });
    }

    [HttpGet("chamado/{id}")]
    public string GetCalledById(int id)
    {
        return $"Chamado com ID: {id}";
    }
}
