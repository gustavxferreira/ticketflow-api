using Microsoft.EntityFrameworkCore;
using TicketFlowApi.Models;
using TicketFlowApi.Enums;

namespace TicketFlowApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

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

            modelBuilder.Entity<User>().HasData(
                           new User
                           {
                               Id = 1,
                               Username = "Joe Doe",
                               Email = "joedoe@example.com",
                               Password = "password",
                               Role = "admin",
                               CreatedAt = DateTime.UtcNow,
                               UpdatedAt = DateTime.UtcNow
                           },
                           new User
                           {
                               Id = 2,
                               Username = "Jane Doe",
                               Email = "janedoe@example.com",
                               Password = "password",
                               Role = "normal",
                               CreatedAt = DateTime.UtcNow,
                               UpdatedAt = DateTime.UtcNow
                           },
                           new User
                           {
                               Id = 3,
                               Username = "Thaysa Doe",
                               Email = "thaysadoe@example.com",
                               Password = "password",
                               Role = "normal",
                               CreatedAt = DateTime.UtcNow,
                               UpdatedAt = DateTime.UtcNow
                           }
                       );

            modelBuilder.Entity<Area>().HasData(
                new Area { Id = 1, Name = "Suporte", Description = "Área de suporte técnico", CreatedAt = DateTime.UtcNow },
                new Area { Id = 2, Name = "Financeiro", Description = "Área financeira", CreatedAt = DateTime.UtcNow },
                new Area { Id = 3, Name = "RH", Description = "Recursos Humanos", CreatedAt = DateTime.UtcNow }
            );


            modelBuilder.Entity<CallCategory>().HasData(
                new CallCategory { Id = 1, AreaId = 1, Name = "Hardware", Description = "Problemas de hardware", CreatedAt = DateTime.UtcNow },
                new CallCategory { Id = 2, AreaId = 1, Name = "Software", Description = "Problemas de software", CreatedAt = DateTime.UtcNow },
                new CallCategory { Id = 3, AreaId = 1, Name = "Rede", Description = "Problemas de rede", CreatedAt = DateTime.UtcNow },

                new CallCategory { Id = 4, AreaId = 2, Name = "Contas a pagar", Description = "Gestão de pagamentos", CreatedAt = DateTime.UtcNow },
                new CallCategory { Id = 5, AreaId = 2, Name = "Contas a receber", Description = "Gestão de recebimentos", CreatedAt = DateTime.UtcNow },
                new CallCategory { Id = 6, AreaId = 2, Name = "Relatórios", Description = "Relatórios financeiros", CreatedAt = DateTime.UtcNow },

                new CallCategory { Id = 7, AreaId = 3, Name = "Recrutamento", Description = "Processo seletivo", CreatedAt = DateTime.UtcNow },
                new CallCategory { Id = 8, AreaId = 3, Name = "Folha de pagamento", Description = "Pagamentos de funcionários", CreatedAt = DateTime.UtcNow },
                new CallCategory { Id = 9, AreaId = 3, Name = "Treinamento", Description = "Capacitação e treinamentos", CreatedAt = DateTime.UtcNow }
            );

            modelBuilder.Entity<CallSubCategory>().HasData(

                new CallSubCategory { Id = 1, CategoryId = 1, Name = "Notebook", Description = "Problemas com notebooks", CreatedAt = DateTime.UtcNow },
                new CallSubCategory { Id = 2, CategoryId = 1, Name = "Desktop", Description = "Problemas com desktops", CreatedAt = DateTime.UtcNow },
                new CallSubCategory { Id = 3, CategoryId = 1, Name = "Impressora", Description = "Problemas com impressoras", CreatedAt = DateTime.UtcNow },

                new CallSubCategory { Id = 4, CategoryId = 2, Name = "ERP", Description = "Problemas com ERP", CreatedAt = DateTime.UtcNow },
                new CallSubCategory { Id = 5, CategoryId = 2, Name = "Sistema interno", Description = "Problemas com sistemas internos", CreatedAt = DateTime.UtcNow },
                new CallSubCategory { Id = 6, CategoryId = 2, Name = "Aplicativo", Description = "Problemas com aplicativos", CreatedAt = DateTime.UtcNow },

                new CallSubCategory { Id = 7, CategoryId = 3, Name = "Wi-Fi", Description = "Problemas com Wi-Fi", CreatedAt = DateTime.UtcNow },
                new CallSubCategory { Id = 8, CategoryId = 3, Name = "VPN", Description = "Problemas com VPN", CreatedAt = DateTime.UtcNow },
                new CallSubCategory { Id = 9, CategoryId = 3, Name = "Firewall", Description = "Problemas com firewall", CreatedAt = DateTime.UtcNow },


                new CallSubCategory { Id = 10, CategoryId = 4, Name = "Faturas", Description = "Emissão de faturas", CreatedAt = DateTime.UtcNow },
                new CallSubCategory { Id = 11, CategoryId = 4, Name = "Pagamentos agendados", Description = "Gestão de pagamentos agendados", CreatedAt = DateTime.UtcNow },
                new CallSubCategory { Id = 12, CategoryId = 4, Name = "Despesas", Description = "Controle de despesas", CreatedAt = DateTime.UtcNow },

                new CallSubCategory { Id = 13, CategoryId = 5, Name = "Recebimentos", Description = "Controle de recebimentos", CreatedAt = DateTime.UtcNow },
                new CallSubCategory { Id = 14, CategoryId = 5, Name = "Cobrança", Description = "Cobrança de clientes", CreatedAt = DateTime.UtcNow },
                new CallSubCategory { Id = 15, CategoryId = 5, Name = "Notas fiscais", Description = "Controle de NF", CreatedAt = DateTime.UtcNow },

                new CallSubCategory { Id = 16, CategoryId = 6, Name = "Balancete", Description = "Criação de balancetes", CreatedAt = DateTime.UtcNow },
                new CallSubCategory { Id = 17, CategoryId = 6, Name = "Fluxo de caixa", Description = "Controle de fluxo de caixa", CreatedAt = DateTime.UtcNow },
                new CallSubCategory { Id = 18, CategoryId = 6, Name = "Relatórios mensais", Description = "Relatórios financeiros", CreatedAt = DateTime.UtcNow },


                new CallSubCategory { Id = 19, CategoryId = 7, Name = "Entrevista", Description = "Entrevistas de candidatos", CreatedAt = DateTime.UtcNow },
                new CallSubCategory { Id = 20, CategoryId = 7, Name = "Teste técnico", Description = "Testes de candidatos", CreatedAt = DateTime.UtcNow },
                new CallSubCategory { Id = 21, CategoryId = 7, Name = "Dinâmica de grupo", Description = "Dinâmicas de grupo", CreatedAt = DateTime.UtcNow },

                new CallSubCategory { Id = 22, CategoryId = 8, Name = "Salários", Description = "Controle de salários", CreatedAt = DateTime.UtcNow },
                new CallSubCategory { Id = 23, CategoryId = 8, Name = "Benefícios", Description = "Gestão de benefícios", CreatedAt = DateTime.UtcNow },
                new CallSubCategory { Id = 24, CategoryId = 8, Name = "Férias", Description = "Controle de férias", CreatedAt = DateTime.UtcNow },

                new CallSubCategory { Id = 25, CategoryId = 9, Name = "Cursos internos", Description = "Treinamentos internos", CreatedAt = DateTime.UtcNow },
                new CallSubCategory { Id = 26, CategoryId = 9, Name = "Workshops", Description = "Workshops de capacitação", CreatedAt = DateTime.UtcNow },
                new CallSubCategory { Id = 27, CategoryId = 9, Name = "Webinars", Description = "Webinars de treinamento", CreatedAt = DateTime.UtcNow }
            );
        }
    }
}
