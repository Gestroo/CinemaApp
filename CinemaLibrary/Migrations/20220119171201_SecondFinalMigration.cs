using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaLibrary.Migrations
{
    public partial class SecondFinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Personal",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "MiddleName", "PhoneNumber" },
                values: new object[] { "Романович", "+79513538360" });

            migrationBuilder.UpdateData(
                table: "Personal",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "MiddleName", "PhoneNumber" },
                values: new object[] { "Григорьевна", "+79229334455" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Personal",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "MiddleName", "PhoneNumber" },
                values: new object[] { "+79513538360", "Романович" });

            migrationBuilder.UpdateData(
                table: "Personal",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "MiddleName", "PhoneNumber" },
                values: new object[] { "+79229334455", "Григорьевна" });
        }
    }
}
