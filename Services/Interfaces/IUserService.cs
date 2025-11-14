using TicketFlowApi.DTOs;
using TicketFlowApi.DTOs.Response;

namespace TicketFlowApi.Services.Interfaces;

public interface IUserService
{
    Task<UserAuthenticatedDTO?> auth(UserAuthDTO user);
    int GetAuthId();
}
