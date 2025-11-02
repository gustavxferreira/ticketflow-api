using Microsoft.AspNetCore.Mvc;
using TicketFlowApi.DTOs;
using TicketFlowApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using TicketFlowApi.Models;
using TicketFlowApi.DTOs.Response;

namespace TicketFlowApi.Controllers;

[ApiController]
[Route("api")]
[Authorize]
public class CategoriesController : ControllerBase
{
    private readonly ILogger<CalledController> _logger;
    private readonly ICategoriesService _categoriesService;

    public CategoriesController(ILogger<CalledController> logger, ICategoriesService categoriesService)
    {
        _logger = logger;
        _categoriesService = categoriesService;
    }

    [AllowAnonymous]
    [HttpGet("categorias")]
    public async Task<ActionResult<List<AreaDTO>>> GetCategories()
    {
        return await _categoriesService.GetAreasWithCategoriesAsync();
    }
}
