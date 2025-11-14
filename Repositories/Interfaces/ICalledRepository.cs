using TicketFlowApi.DTOs.Response;
using TicketFlowApi.Models;

namespace TicketFlowApi.Repositories.Interfaces;

public interface ICalledRepository
{
    Task<CalledDetailsDto?> FindCalled(int Id, int UserId);
    Task<List<CalledsList>> GetMyCalleds(int userId);
}
