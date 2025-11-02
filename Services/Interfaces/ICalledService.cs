using TicketFlowApi.DTOs;

namespace TicketFlowApi.Services.Interfaces;
public interface ICalledService
{
    Task CreateCalledAsync(CalledCreateDTO dto);
}
