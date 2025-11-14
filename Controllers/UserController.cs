using Microsoft.AspNetCore.Mvc;
using TicketFlowApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using TicketFlowApi.DTOs;
using TicketFlowApi.DTOs.Response;
using System.Security.Claims;

namespace TicketFlowApi.Controllers;

[ApiController]
[Route("api")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("auth")]
    public async Task<IActionResult> auth([FromBody] UserAuthDTO userAuthDTO)
    {
        UserAuthenticatedDTO? userAuthenticatedDTO = await _userService.auth(userAuthDTO);
        
        if(userAuthenticatedDTO == null) {
            return Unauthorized(new
            {
                message = "Usuário ou senha inválidos!"
            });
        }
        
        return Ok(new
        {
            message = "Usuário autenticado com sucesso!",
            token = userAuthenticatedDTO!.Token
        });
    }

    [HttpGet("me")]
    public IActionResult Me()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        var role = User.FindFirst(ClaimTypes.Role)?.Value;

        return Ok(new
        {
            message = "Oi, estou autenticado!",
            userId,
            email,
            role
        });
    }
    
    [HttpGet("chamado/{id}")]
    public string GetCalledById(int id)
    {
        return $"Chamado com ID: {id}";
    }
}
