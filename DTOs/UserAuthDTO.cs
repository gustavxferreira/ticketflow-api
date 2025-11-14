using System.Text.Json.Serialization;

namespace TicketFlowApi.DTOs;

public class UserAuthDTO
{
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
}
