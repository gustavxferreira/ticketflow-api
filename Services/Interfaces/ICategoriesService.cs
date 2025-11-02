using TicketFlowApi.DTOs.Response;

namespace TicketFlowApi.Services.Interfaces;
public interface ICategoriesService
{
    Task<List<AreaDTO>> GetAreasWithCategoriesAsync();
}
