using TicketFlowApi.Enums;

namespace TicketFlowApi.DTOs;

public class StepDTO
{
    public int Code { get; set; }
    public string Description { get; set; } = string.Empty;

    public static StepDTO FromEnum(Step step)
    {
        return new StepDTO
        {
            Code = (int) step,
            Description = step.GetDescription()
        };
    }
}
