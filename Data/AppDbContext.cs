using Microsoft.EntityFrameworkCore;
using TicketFlowApi.Models;
using TicketFlowApi.Enums;

namespace TicketFlowApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Called> Calleds { get; set; }
        public DbSet<CallMetadata> CallMetadata { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<CallCategory> CallCategories { get; set; }
        public DbSet<CallSubCategory> CallSubCategories { get; set; }
        public DbSet<LogsCalled> LogsCalled { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<Priority>();
            modelBuilder.HasPostgresEnum<Step>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
