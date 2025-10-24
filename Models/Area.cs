using System;
using System.Collections.Generic;

namespace TicketFlowApi.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<CallCategory>? Categories { get; set; } 
    }
}
