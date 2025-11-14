using Microsoft.AspNetCore.Mvc;
using TicketFlowApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using TicketFlowApi.DTOs.Response;

namespace TicketFlowApi.Controllers;

[ApiController]
[Route("api")]
[Authorize]
public class CalledController : ControllerBase
{
    private readonly ILogger<CalledController> _logger;
    private readonly ICalledService _calledService;
    private readonly IUserService _userService;

    public CalledController(ILogger<CalledController> logger, ICalledService calledService, IUserService userService)
    {
        _logger = logger;
        _calledService = calledService;
        _userService = userService;
    }

    [HttpPost("chamados")]
    public async Task<IActionResult> CreateCalled([FromBody] CalledCreateDTO dto)
    {
        int id = await _calledService.CreateCalledAsync(dto);

        return Created("", new { message = "Chamado criado com sucesso", id = id });
    }

    [HttpGet("chamados/{id}")]
    public async Task<IActionResult> GetCalledById(int id)
    {
        int userId = _userService.GetAuthId();

        var called = await _calledService.CalledById(id, userId);

        if (called == null)
        {
            return NotFound();
        }

        return Ok(called);
    }

    [HttpGet("meus-chamados")]
    public async Task<List<CalledsList>> Calleds()
    {
        int userId = _userService.GetAuthId();

        List<CalledsList> calleds = await _calledService.GetMyCalleds(userId);

        return calleds;
    }
}
