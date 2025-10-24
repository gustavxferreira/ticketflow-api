using System;
using TicketFlowApi.Enums;

namespace TicketFlowApi.Models
{
    public class LogsCalled
    {
        public int Id { get; set; }
        public Step MovedFrom { get; set; }
        public Step MovedTo { get; set; }

        public int ByUser { get; set; }
        public User? User { get; set; }

        public DateTime Moment { get; set; } = DateTime.UtcNow;
    }
}
