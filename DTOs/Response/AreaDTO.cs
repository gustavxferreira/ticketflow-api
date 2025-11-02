namespace TicketFlowApi.DTOs.Response;
public class AreaDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public List<CategoryDTO>? Categories { get; set; } 
}