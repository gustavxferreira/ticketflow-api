namespace TicketFlowApi.DTOs.Response;

public class UserAuthenticatedDTO
{
    public int Id { get; set; }
    public string Email { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    public string Role { get; set; } = String.Empty;
    public string Token { get; set; } = String.Empty;
}