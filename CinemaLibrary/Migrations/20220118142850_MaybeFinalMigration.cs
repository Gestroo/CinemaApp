using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaLibrary.Migrations
{
    public partial class MaybeFinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HallSeat_Seance_SeanceID",
                table: "HallSeat");

            migrationBuilder.DropForeignKey(
                name: "FK_HallSeat_Seance_SeanceID1",
                table: "HallSeat");

            migrationBuilder.DropIndex(
                name: "IX_HallSeat_SeanceID",
                table: "HallSeat");

            migrationBuilder.DropIndex(
                name: "IX_HallSeat_SeanceID1",
                table: "HallSeat");

            migrationBuilder.DropIndex(
                name: "IX_Client_Email",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "SeanceID",
                table: "HallSeat");

            migrationBuilder.DropColumn(
                name: "SeanceID1",
                table: "HallSeat");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Client");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Personal",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Personal",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Personal",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Client",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Client",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Client",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "SeanceBoughtSeats",
                columns: table => new
                {
                    BoughtSeancesID = table.Column<int>(type: "integer", nullable: false),
                    BoughtSeatsID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeanceBoughtSeats", x => new { x.BoughtSeancesID, x.BoughtSeatsID });
                    table.ForeignKey(
                        name: "FK_SeanceBoughtSeats_HallSeat_BoughtSeatsID",
                        column: x => x.BoughtSeatsID,
                        principalTable: "HallSeat",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeanceBoughtSeats_Seance_BoughtSeancesID",
                        column: x => x.BoughtSeancesID,
                        principalTable: "Seance",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeanceReservedSeats",
                columns: table => new
                {
                    ReservedSeancesID = table.Column<int>(type: "integer", nullable: false),
                    ReservedSeatsID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeanceReservedSeats", x => new { x.ReservedSeancesID, x.ReservedSeatsID });
                    table.ForeignKey(
                        name: "FK_SeanceReservedSeats_HallSeat_ReservedSeatsID",
                        column: x => x.ReservedSeatsID,
                        principalTable: "HallSeat",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeanceReservedSeats_Seance_ReservedSeancesID",
                        column: x => x.ReservedSeancesID,
                        principalTable: "Seance",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeanceBoughtSeats_BoughtSeatsID",
                table: "SeanceBoughtSeats",
                column: "BoughtSeatsID");

            migrationBuilder.CreateIndex(
                name: "IX_SeanceReservedSeats_ReservedSeatsID",
                table: "SeanceReservedSeats",
                column: "ReservedSeatsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeanceBoughtSeats");

            migrationBuilder.DropTable(
                name: "SeanceReservedSeats");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Personal");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Personal",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Personal",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeanceID",
                table: "HallSeat",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeanceID1",
                table: "HallSeat",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Client",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Client",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Client",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Client",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Client",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Client",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_HallSeat_SeanceID",
                table: "HallSeat",
                column: "SeanceID");

            migrationBuilder.CreateIndex(
                name: "IX_HallSeat_SeanceID1",
                table: "HallSeat",
                column: "SeanceID1");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Email",
                table: "Client",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HallSeat_Seance_SeanceID",
                table: "HallSeat",
                column: "SeanceID",
                principalTable: "Seance",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HallSeat_Seance_SeanceID1",
                table: "HallSeat",
                column: "SeanceID1",
                principalTable: "Seance",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
