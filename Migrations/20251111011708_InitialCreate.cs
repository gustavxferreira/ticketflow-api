using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketFlowApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:priority", "low,mid,high")
                .Annotation("Npgsql:Enum:step", "open,in_analysis,in_development,in_tests,paused,closed");

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CallCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AreaId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CallCategories_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Calleds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    EvidencePath = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calleds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calleds_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogsCalled",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MovedFrom = table.Column<int>(type: "integer", nullable: false),
                    MovedTo = table.Column<int>(type: "integer", nullable: false),
                    ByUser = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    Moment = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogsCalled", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogsCalled_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CallSubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallSubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CallSubCategories_CallCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CallCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CallMetadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CalledId = table.Column<int>(type: "integer", nullable: false),
                    AreaId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    SubcategoryId = table.Column<int>(type: "integer", nullable: false),
                    ReasonForClosing = table.Column<string>(type: "text", nullable: true),
                    SuggestionAI = table.Column<string>(type: "text", nullable: true),
                    EvidencePath = table.Column<string>(type: "text", nullable: true),
                    Step = table.Column<int>(type: "integer", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    AssignedTo = table.Column<int>(type: "integer", nullable: true),
                    AssignedUserId = table.Column<int>(type: "integer", nullable: true),
                    DateOpen = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateClosed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallMetadata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CallMetadata_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallMetadata_CallCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CallCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallMetadata_CallSubCategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "CallSubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallMetadata_Calleds_CalledId",
                        column: x => x.CalledId,
                        principalTable: "Calleds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallMetadata_Users_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(1496), "Área de suporte técnico", "Suporte" },
                    { 2, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(1522), "Área financeira", "Financeiro" },
                    { 3, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(1546), "Recursos Humanos", "RH" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "Role", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(978), "joedoe@example.com", "password", "admin", new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(992), "Joe Doe" },
                    { 2, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(1062), "janedoe@example.com", "password", "normal", new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(1076), "Jane Doe" },
                    { 3, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(1124), "thaysadoe@example.com", "password", "normal", new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(1137), "Thaysa Doe" }
                });

            migrationBuilder.InsertData(
                table: "CallCategories",
                columns: new[] { "Id", "AreaId", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(1618), "Problemas de hardware", "Hardware" },
                    { 2, 1, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(1642), "Problemas de software", "Software" },
                    { 3, 1, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(1666), "Problemas de rede", "Rede" },
                    { 4, 2, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(1690), "Gestão de pagamentos", "Contas a pagar" },
                    { 5, 2, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(1713), "Gestão de recebimentos", "Contas a receber" },
                    { 6, 2, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(1739), "Relatórios financeiros", "Relatórios" },
                    { 7, 3, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(1762), "Processo seletivo", "Recrutamento" },
                    { 8, 3, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(1786), "Pagamentos de funcionários", "Folha de pagamento" },
                    { 9, 3, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(1809), "Capacitação e treinamentos", "Treinamento" }
                });

            migrationBuilder.InsertData(
                table: "CallSubCategories",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(1997), "Problemas com notebooks", "Notebook" },
                    { 2, 1, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2021), "Problemas com desktops", "Desktop" },
                    { 3, 1, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2046), "Problemas com impressoras", "Impressora" },
                    { 4, 2, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2070), "Problemas com ERP", "ERP" },
                    { 5, 2, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2094), "Problemas com sistemas internos", "Sistema interno" },
                    { 6, 2, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2118), "Problemas com aplicativos", "Aplicativo" },
                    { 7, 3, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2141), "Problemas com Wi-Fi", "Wi-Fi" },
                    { 8, 3, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2163), "Problemas com VPN", "VPN" },
                    { 9, 3, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2184), "Problemas com firewall", "Firewall" },
                    { 10, 4, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2209), "Emissão de faturas", "Faturas" },
                    { 11, 4, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2232), "Gestão de pagamentos agendados", "Pagamentos agendados" },
                    { 12, 4, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2255), "Controle de despesas", "Despesas" },
                    { 13, 5, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2280), "Controle de recebimentos", "Recebimentos" },
                    { 14, 5, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2304), "Cobrança de clientes", "Cobrança" },
                    { 15, 5, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2324), "Controle de NF", "Notas fiscais" },
                    { 16, 6, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2349), "Criação de balancetes", "Balancete" },
                    { 17, 6, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2373), "Controle de fluxo de caixa", "Fluxo de caixa" },
                    { 18, 6, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2398), "Relatórios financeiros", "Relatórios mensais" },
                    { 19, 7, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2422), "Entrevistas de candidatos", "Entrevista" },
                    { 20, 7, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2445), "Testes de candidatos", "Teste técnico" },
                    { 21, 7, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2468), "Dinâmicas de grupo", "Dinâmica de grupo" },
                    { 22, 8, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2492), "Controle de salários", "Salários" },
                    { 23, 8, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2515), "Gestão de benefícios", "Benefícios" },
                    { 24, 8, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2539), "Controle de férias", "Férias" },
                    { 25, 9, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2563), "Treinamentos internos", "Cursos internos" },
                    { 26, 9, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2586), "Workshops de capacitação", "Workshops" },
                    { 27, 9, new DateTime(2025, 11, 11, 1, 17, 8, 22, DateTimeKind.Utc).AddTicks(2610), "Webinars de treinamento", "Webinars" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CallCategories_AreaId",
                table: "CallCategories",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Calleds_UserId",
                table: "Calleds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CallMetadata_AreaId",
                table: "CallMetadata",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_CallMetadata_AssignedUserId",
                table: "CallMetadata",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CallMetadata_CalledId",
                table: "CallMetadata",
                column: "CalledId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CallMetadata_CategoryId",
                table: "CallMetadata",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CallMetadata_SubcategoryId",
                table: "CallMetadata",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CallSubCategories_CategoryId",
                table: "CallSubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LogsCalled_UserId",
                table: "LogsCalled",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallMetadata");

            migrationBuilder.DropTable(
                name: "LogsCalled");

            migrationBuilder.DropTable(
                name: "CallSubCategories");

            migrationBuilder.DropTable(
                name: "Calleds");

            migrationBuilder.DropTable(
                name: "CallCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}
