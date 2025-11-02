namespace TicketFlowApi.DTOs.Response;

public class CategoryDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string? Description { get; set; }
    // public DateTime CreatedAt { get; set; }

    // public int AreaId { get; set; }
    // public string AreaName { get; set; } = String.Empty;

    public List<SubcategoryDTO>? Subcategories { get; set; }
}

