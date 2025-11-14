using System.ComponentModel;

namespace TicketFlowApi.Enums
{
    public enum Priority
    {   
        [Description("Baixa")]
        Low = 0,
        
        [Description("Média")]
        Mid = 1,
        
        [Description("Alta")]
        High = 2
    }
}
