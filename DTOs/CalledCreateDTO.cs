using System.Text.Json.Serialization;
using TicketFlowApi.Enums;

public class CalledCreateDTO
{
    [JsonPropertyName("user_email")]
    public string UserEmail { get; set; } = string.Empty;

    [JsonPropertyName("subject")]
    public string Subject { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("area_id")]
    public int AreaId { get; set; }

    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }

    [JsonPropertyName("sub_category_id")]
    public int SubCategoryId { get; set; }

    [JsonPropertyName("step")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Step Step { get; set; }

    [JsonPropertyName("priority")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Priority Priority { get; set; }

    [JsonPropertyName("evidence_path")]
    public string? EvidencePath { get; set; }
}
