namespace TicketFlowApi.Services.Interfaces;

public interface IAIService
{
    Task<String> Prompt(String prompt);
}
