using System;

namespace TicketFlowApi.Models
{
    public class CallSubCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public CallCategory? Category { get; set; } 

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
