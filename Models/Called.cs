using System;
using System.Collections.Generic;

namespace TicketFlowApi.Models
{
    public class Called
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        // public User User { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? EvidencePath { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public CallMetadata? CallMetadata { get; set; }
    }
}
