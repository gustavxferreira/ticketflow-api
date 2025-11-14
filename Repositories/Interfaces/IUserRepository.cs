using TicketFlowApi.DTOs.Response;

namespace TicketFlowApi.Repositories.Interfaces;

public interface IUserRepository
{
    Task<UserAuthenticatedDTO?> FindUser(string email, string password);
}
