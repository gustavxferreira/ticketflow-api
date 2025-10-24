using System;
using System.Collections.Generic;

namespace TicketFlowApi.Models
{
    public class CallCategory
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public Area? Area { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<CallSubCategory>? Subcategories { get; set; } 
    }
}
