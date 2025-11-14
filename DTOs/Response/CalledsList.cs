using TicketFlowApi.Enums;

namespace TicketFlowApi.DTOs.Response;

public class CalledsList
    {
        public string AreaName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string SubcategoryName { get; set; } = string.Empty;
        public string CalledSubject { get; set; } = string.Empty;
        public DateTime DateOpen { get; set; }
        public DateTime? DateClosed { get; set; }
        public string? Step { get; set; }
    }