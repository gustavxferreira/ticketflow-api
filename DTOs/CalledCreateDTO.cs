namespace TicketFlowApi.DTOs;

using System.Text.Json.Serialization;
using TicketFlowApi.Enums;

public class CalledCreateDTO
{
    public string UserEmail { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int AreaId { get; set; }
    public int CategoryId { get; set; }
    public int SubCategoryId { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Step Step { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Priority Priority { get; set; }
    public string? EvidencePath { get; set; }
}