using TicketFlowApi.Enums;

namespace TicketFlowApi.DTOs;

public class PriorityDTO
{
    public int Code { get; set; }
    public string Description { get; set; } = string.Empty;

    public static PriorityDTO FromEnum(Priority priority)
    {
        return new PriorityDTO
        {
            Code = (int)priority,
            Description = priority.GetDescription()
        };
    }
}
