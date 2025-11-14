using TicketFlowApi.Services.Interfaces;
using TicketFlowApi.DTOs;
using TicketFlowApi.DTOs.Response;
using TicketFlowApi.Repositories.Interfaces;

namespace TicketFlowApi.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserContextService _userContextService;

    public UserService(IUserRepository userRepository, IUserContextService userContextService)
    {
        _userRepository = userRepository;
        _userContextService = userContextService;
    }

    public async Task<UserAuthenticatedDTO?> auth(UserAuthDTO user)
    {
        UserAuthenticatedDTO? userAuthenticated = await _userRepository.FindUser(user.Email, user.Password);

        return userAuthenticated;
    }
    
    public int GetAuthId()
    {
        return _userContextService.AuthId();
    }
}
