using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CinemaLibrary.Migrations
{
    public partial class SeemsLikeFinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_CashBox_CashBoxNumber",
                table: "Ticket");

            migrationBuilder.DropTable(
                name: "CashBox");

            migrationBuilder.DropTable(
                name: "PriceFormer");

            migrationBuilder.DropColumn(
                name: "Reservation",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "TicketNumber",
                table: "Ticket",
                newName: "SeanceID");

            migrationBuilder.RenameColumn(
                name: "CashBoxNumber",
                table: "Ticket",
                newName: "PersonalID");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_CashBoxNumber",
                table: "Ticket",
                newName: "IX_Ticket_PersonalID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_SeanceID",
                table: "Ticket",
                column: "SeanceID");

            migrationBuilder.CreateIndex(
                name: "IX_HallSeat_SeanceID",
                table: "HallSeat",
                column: "SeanceID");

            migrationBuilder.CreateIndex(
                name: "IX_HallSeat_SeanceID1",
                table: "HallSeat",
                column: "SeanceID1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Personal_PersonalID",
                table: "Ticket",
                column: "PersonalID",
                principalTable: "Personal",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Seance_SeanceID",
                table: "Ticket",
                column: "SeanceID",
                principalTable: "Seance",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HallSeat_Seance_SeanceID",
                table: "HallSeat");

            migrationBuilder.DropForeignKey(
                name: "FK_HallSeat_Seance_SeanceID1",
                table: "HallSeat");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Personal_PersonalID",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Seance_SeanceID",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_SeanceID",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_HallSeat_SeanceID",
                table: "HallSeat");

            migrationBuilder.DropIndex(
                name: "IX_HallSeat_SeanceID1",
                table: "HallSeat");

            migrationBuilder.DropColumn(
                name: "SeanceID",
                table: "HallSeat");

            migrationBuilder.DropColumn(
                name: "SeanceID1",
                table: "HallSeat");

            migrationBuilder.RenameColumn(
                name: "SeanceID",
                table: "Ticket",
                newName: "TicketNumber");

            migrationBuilder.RenameColumn(
                name: "PersonalID",
                table: "Ticket",
                newName: "CashBoxNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_PersonalID",
                table: "Ticket",
                newName: "IX_Ticket_CashBoxNumber");

            migrationBuilder.AddColumn<bool>(
                name: "Reservation",
                table: "Ticket",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CashBox",
                columns: table => new
                {
                    CashBoxNumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonalID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashBox", x => x.CashBoxNumber);
                    table.ForeignKey(
                        name: "FK_CashBox_Personal_PersonalID",
                        column: x => x.PersonalID,
                        principalTable: "Personal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PriceFormer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Discount = table.Column<string>(type: "text", nullable: false),
                    PriceTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    PriceWeekend = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceFormer", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashBox_PersonalID",
                table: "CashBox",
                column: "PersonalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_CashBox_CashBoxNumber",
                table: "Ticket",
                column: "CashBoxNumber",
                principalTable: "CashBox",
                principalColumn: "CashBoxNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
