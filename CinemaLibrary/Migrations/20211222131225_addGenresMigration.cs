using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CinemaLibrary.Migrations
{
    public partial class addGenresMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HallSeat_HallRow_HallRowID",
                table: "HallSeat");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Film");

            migrationBuilder.AlterColumn<int>(
                name: "HallRowID",
                table: "HallSeat",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Genre = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FilmGenres",
                columns: table => new
                {
                    FilmsID = table.Column<int>(type: "integer", nullable: false),
                    GenreID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGenres", x => new { x.FilmsID, x.GenreID });
                    table.ForeignKey(
                        name: "FK_FilmGenres_Film_FilmsID",
                        column: x => x.FilmsID,
                        principalTable: "Film",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmGenres_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenres_GenreID",
                table: "FilmGenres",
                column: "GenreID");

            migrationBuilder.AddForeignKey(
                name: "FK_HallSeat_HallRow_HallRowID",
                table: "HallSeat",
                column: "HallRowID",
                principalTable: "HallRow",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HallSeat_HallRow_HallRowID",
                table: "HallSeat");

            migrationBuilder.DropTable(
                name: "FilmGenres");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.AlterColumn<int>(
                name: "HallRowID",
                table: "HallSeat",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<List<string>>(
                name: "Genre",
                table: "Film",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_HallSeat_HallRow_HallRowID",
                table: "HallSeat",
                column: "HallRowID",
                principalTable: "HallRow",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
