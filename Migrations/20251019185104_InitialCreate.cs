using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

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
                    EvidencePath = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Moment = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogsCalled", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogsCalled_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CallSubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
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
                    ReasonForClosing = table.Column<string>(type: "text", nullable: false),
                    EvidencePath = table.Column<string>(type: "text", nullable: false),
                    Step = table.Column<int>(type: "integer", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    AssignedTo = table.Column<int>(type: "integer", nullable: true),
                    AssignedUserId = table.Column<int>(type: "integer", nullable: false),
                    DateOpen = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateClosed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
