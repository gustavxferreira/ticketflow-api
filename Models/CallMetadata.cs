using System;
using TicketFlowApi.Enums;

namespace TicketFlowApi.Models
{
    public class CallMetadata
    {
        public int Id { get; set; }
        
        public int CalledId { get; set; }
        
        public Called? Called { get; set; }

        public int AreaId { get; set; }
        
        public Area? Area { get; set; }

        public int CategoryId { get; set; }
        
        public CallCategory? Category { get; set; }

        public int SubcategoryId { get; set; }
        
        public CallSubCategory? Subcategory { get; set; }

        public string? ReasonForClosing { get; set; }
        
        public string? SuggestionAI { get; set; }
        
        public string? EvidencePath { get; set; }

        public Step Step { get; set; } = Step.Open;
        
        public Priority Priority { get; set; }

        public int? AssignedTo { get; set; }
        
        public User? AssignedUser { get; set; }

        public DateTime DateOpen { get; set; } = DateTime.UtcNow;
        
        public DateTime? DateClosed { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedAt { get; set; }
    }
}
