using TicketFlowApi.Enums;

namespace TicketFlowApi.DTOs.Response;

public class CalledDetailsDto
    {
        public string AreaName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string SubcategoryName { get; set; } = string.Empty;
        public string SuggestionAI { get; set; } = string.Empty;
        public string CalledSubject { get; set; } = string.Empty;
        public string CalledDescription { get; set; } = string.Empty;
        public DateTime DateOpen { get; set; }
        public DateTime? DateClosed { get; set; }
        public int? AssignedTo { get; set; }
        public string? ReasonForClosing { get; set; }
        public string? Step { get; set; }
    }