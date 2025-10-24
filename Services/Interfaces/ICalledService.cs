using TicketFlowApi.DTOs;

namespace TicketFlowApi.Services.Interfaces;
public interface ICalledService
{
    // Task<bool> ValidateCategoryAsync(int categoryId);
    Task CreateCalledAsync(CalledCreateDTO dto);
}
