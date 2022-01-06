using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaLibrary.Migrations
{
    public partial class AddUniqueMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Client_Email",
                table: "Client",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Client_Email",
                table: "Client");
        }
    }
}
