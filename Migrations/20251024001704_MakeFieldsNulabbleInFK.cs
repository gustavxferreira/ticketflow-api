using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketFlowApi.Migrations
{
    /// <inheritdoc />
    public partial class MakeFieldsNulabbleInFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogsCalled_Users_UserId",
                table: "LogsCalled");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "LogsCalled",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_LogsCalled_Users_UserId",
                table: "LogsCalled",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogsCalled_Users_UserId",
                table: "LogsCalled");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "LogsCalled",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LogsCalled_Users_UserId",
                table: "LogsCalled",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
