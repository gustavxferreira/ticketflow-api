using System.Security.Claims;
using TicketFlowApi.Services.Interfaces;

public class UserContextService : IUserContextService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContextService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int AuthId()
    {
        var user = _httpContextAccessor.HttpContext?.User;

        var idString = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if (!int.TryParse(idString, out int id))
        {
            throw new Exception("Usuário não autenticado ou Id inválido");
        }

        return id;
    }
}
