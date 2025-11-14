using TicketFlowApi.Models;
using TicketFlowApi.Enums;

namespace TicketFlowApi.Data
{
    public static class DbSeeder
    {
        public static void SeedCalleds(AppDbContext context)
        {
            if (context.Calleds.Any()) return; 

            
            var janeCalleds = new List<Called>();
            for (int i = 1; i <= 3; i++)
            {
                var called = new Called
                {
                    UserId = 2,
                    Subject = $"Chamado {i} de Jane",
                    Description = $"Descrição do chamado {i} de Jane",
                    CreatedAt = DateTime.UtcNow
                };
                janeCalleds.Add(called);
            }
            context.Calleds.AddRange(janeCalleds);
            context.SaveChanges();

            
            int metaId = 1;
            foreach (var called in janeCalleds)
            {
                var meta = new CallMetadata
                {
                    CalledId = called.Id,
                    AreaId = 1,
                    CategoryId = 1,
                    SubcategoryId = 1,
                    Step = Step.Open,
                    Priority = Priority.Low,
                    DateOpen = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                };
                context.CallMetadata.Add(meta);
                metaId++;
            }

            
            var thaysaCalleds = new List<Called>();
            for (int i = 1; i <= 3; i++)
            {
                var called = new Called
                {
                    UserId = 3,
                    Subject = $"Chamado {i} de Thaysa",
                    Description = $"Descrição do chamado {i} de Thaysa",
                    CreatedAt = DateTime.UtcNow
                };
                thaysaCalleds.Add(called);
            }
            context.Calleds.AddRange(thaysaCalleds);
            context.SaveChanges();

            foreach (var called in thaysaCalleds)
            {
                var meta = new CallMetadata
                {
                    CalledId = called.Id,
                    AreaId = 2,
                    CategoryId = 4,
                    SubcategoryId = 10,
                    Step = Step.Open,
                    Priority = Priority.Mid,
                    DateOpen = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                };
                context.CallMetadata.Add(meta);
            }

            context.SaveChanges();
        }
    }
}
