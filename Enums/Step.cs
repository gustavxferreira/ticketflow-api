using System.ComponentModel;

namespace TicketFlowApi.Enums
{
    public enum Step
    {   
        [Description("Em aberto")]
        Open = 0,
        [Description("Em análise")]
        InAnalysis = 1,
        [Description("Em desenvolvimento")]
        InDevelopment = 2,
        [Description("Em testes")]
        InTests = 3,
        [Description("Em pausa")]
        Paused = 4,
        [Description("Encerrado")]
        Closed = 5
    }
}
