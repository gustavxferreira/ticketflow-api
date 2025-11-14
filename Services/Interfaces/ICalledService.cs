using TicketFlowApi.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace TicketFlowApi.Services.Interfaces;

public interface ICalledService
{
    Task<int>  CreateCalledAsync(CalledCreateDTO dto);
    Task<CalledDetailsDto?> CalledById(int id, int userId);
    Task<List<CalledsList>> GetMyCalleds(int userId);
}
