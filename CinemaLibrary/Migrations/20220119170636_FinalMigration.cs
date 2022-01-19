using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CinemaLibrary.Migrations
{
    public partial class FinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CinemaHall",
                columns: table => new
                {
                    HallNumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HallName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaHall", x => x.HallNumber);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    Restriction = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DateStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateFinish = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonalRole = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeanceTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HallRow",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RowNumber = table.Column<int>(type: "integer", nullable: false),
                    CinemaHallID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallRow", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HallRow_CinemaHall_CinemaHallID",
                        column: x => x.CinemaHallID,
                        principalTable: "CinemaHall",
                        principalColumn: "HallNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ClientID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Booking_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seance",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CinemaHallHallNumber = table.Column<int>(type: "integer", nullable: true),
                    FilmID = table.Column<int>(type: "integer", nullable: true),
                    SeanceDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Cost = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seance", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Seance_CinemaHall_CinemaHallHallNumber",
                        column: x => x.CinemaHallHallNumber,
                        principalTable: "CinemaHall",
                        principalColumn: "HallNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seance_Film_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Film",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilmGenre",
                columns: table => new
                {
                    FilmsID = table.Column<int>(type: "integer", nullable: false),
                    GenreID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGenre", x => new { x.FilmsID, x.GenreID });
                    table.ForeignKey(
                        name: "FK_FilmGenre_Film_FilmsID",
                        column: x => x.FilmsID,
                        principalTable: "Film",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmGenre_Genre_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    RoleID = table.Column<int>(type: "integer", nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Personal_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CinemaHallTime",
                columns: table => new
                {
                    HallsHallNumber = table.Column<int>(type: "integer", nullable: false),
                    SeanceTimesID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaHallTime", x => new { x.HallsHallNumber, x.SeanceTimesID });
                    table.ForeignKey(
                        name: "FK_CinemaHallTime_CinemaHall_HallsHallNumber",
                        column: x => x.HallsHallNumber,
                        principalTable: "CinemaHall",
                        principalColumn: "HallNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CinemaHallTime_Time_SeanceTimesID",
                        column: x => x.SeanceTimesID,
                        principalTable: "Time",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HallSeat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeatNumber = table.Column<int>(type: "integer", nullable: false),
                    HallRowID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallSeat", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HallSeat_HallRow_HallRowID",
                        column: x => x.HallRowID,
                        principalTable: "HallRow",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RowID = table.Column<int>(type: "integer", nullable: true),
                    SeatID = table.Column<int>(type: "integer", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    SeanceID = table.Column<int>(type: "integer", nullable: false),
                    PersonalID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ticket_HallRow_RowID",
                        column: x => x.RowID,
                        principalTable: "HallRow",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_HallSeat_SeatID",
                        column: x => x.SeatID,
                        principalTable: "HallSeat",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Personal_PersonalID",
                        column: x => x.PersonalID,
                        principalTable: "Personal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Seance_SeanceID",
                        column: x => x.SeanceID,
                        principalTable: "Seance",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TicketID = table.Column<int>(type: "integer", nullable: true),
                    BookingID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reservation_Booking_BookingID",
                        column: x => x.BookingID,
                        principalTable: "Booking",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_Ticket_TicketID",
                        column: x => x.TicketID,
                        principalTable: "Ticket",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CinemaHall",
                columns: new[] { "HallNumber", "HallName" },
                values: new object[,]
                {
                    { 1, "Зал 1" },
                    { 2, "Зал 2" },
                    { 3, "Зал 3" },
                    { 4, "Зал 4" },
                    { 5, "Зал 5" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "ID", "Description", "Title" },
                values: new object[,]
                {
                    { 10, null, "Аниме" },
                    { 9, null, "Вестерн" },
                    { 8, null, "Мелодрама" },
                    { 7, null, "Драма" },
                    { 6, null, "Фэнтези" },
                    { 11, null, "Триллер" },
                    { 4, null, "Комедия" },
                    { 3, null, "Мультфильм" },
                    { 2, null, "Ужасы" },
                    { 1, null, "Боевик" },
                    { 5, null, "Фантастика" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "ID", "PersonalRole" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "cashier" }
                });

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "ID", "SeanceTime" },
                values: new object[,]
                {
                    { 17, new DateTime(1, 1, 1, 20, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateTime(1, 1, 1, 23, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateTime(1, 1, 1, 9, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateTime(1, 1, 1, 11, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 21, new DateTime(1, 1, 1, 13, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 25, new DateTime(1, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 23, new DateTime(1, 1, 1, 8, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 24, new DateTime(1, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 26, new DateTime(1, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, new DateTime(1, 1, 1, 17, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(1, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, new DateTime(1, 1, 1, 21, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(1, 1, 1, 15, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(1, 1, 1, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(1, 1, 1, 21, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(1, 1, 1, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(1, 1, 1, 16, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(1, 1, 1, 13, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(1, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(1, 1, 1, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(1, 1, 1, 23, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 28, new DateTime(1, 1, 1, 19, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1, 1, 1, 18, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1, 1, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 11, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(1, 1, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, new DateTime(1, 1, 1, 22, 20, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "HallRow",
                columns: new[] { "ID", "CinemaHallID", "RowNumber" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 30, 5, 6 },
                    { 29, 5, 5 },
                    { 28, 5, 4 },
                    { 27, 5, 3 },
                    { 26, 5, 2 },
                    { 25, 5, 1 },
                    { 24, 4, 6 },
                    { 23, 4, 5 },
                    { 22, 4, 4 },
                    { 21, 4, 3 },
                    { 20, 4, 2 },
                    { 19, 4, 1 },
                    { 18, 3, 6 },
                    { 17, 3, 5 },
                    { 16, 3, 4 },
                    { 15, 3, 3 },
                    { 14, 3, 2 },
                    { 13, 3, 1 },
                    { 12, 2, 6 },
                    { 11, 2, 5 },
                    { 10, 2, 4 },
                    { 9, 2, 3 },
                    { 8, 2, 2 },
                    { 7, 2, 1 },
                    { 6, 1, 6 },
                    { 5, 1, 5 },
                    { 4, 1, 4 },
                    { 3, 1, 3 },
                    { 2, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Personal",
                columns: new[] { "ID", "FirstName", "LastName", "Login", "MiddleName", "Password", "PhoneNumber", "RoleID" },
                values: new object[,]
                {
                    { 1, "Дмитрий", "Широков", "admin", "+79513538360", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", "Романович", 1 },
                    { 2, "Зинаида", "Ромашкова", "cashier1", "+79229334455", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", "Григорьевна", 2 }
                });

            migrationBuilder.InsertData(
                table: "HallSeat",
                columns: new[] { "ID", "HallRowID", "SeatNumber" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 196, 21, 6 },
                    { 195, 21, 5 },
                    { 194, 21, 4 },
                    { 193, 21, 3 },
                    { 192, 21, 2 },
                    { 191, 21, 1 },
                    { 197, 21, 7 },
                    { 190, 20, 9 },
                    { 188, 20, 7 },
                    { 187, 20, 6 },
                    { 186, 20, 5 },
                    { 185, 20, 4 },
                    { 184, 20, 3 },
                    { 183, 20, 2 },
                    { 189, 20, 8 },
                    { 182, 20, 1 },
                    { 198, 21, 8 },
                    { 200, 21, 10 },
                    { 214, 23, 5 },
                    { 213, 23, 4 },
                    { 212, 23, 3 },
                    { 211, 23, 2 },
                    { 210, 23, 1 },
                    { 209, 22, 9 },
                    { 199, 21, 9 },
                    { 208, 22, 8 },
                    { 206, 22, 6 },
                    { 205, 22, 5 },
                    { 204, 22, 4 },
                    { 203, 22, 3 },
                    { 202, 22, 2 },
                    { 201, 22, 1 },
                    { 207, 22, 7 },
                    { 215, 23, 6 },
                    { 181, 19, 10 },
                    { 179, 19, 8 },
                    { 160, 17, 8 },
                    { 159, 17, 7 },
                    { 158, 17, 6 },
                    { 157, 17, 5 },
                    { 156, 17, 4 },
                    { 155, 17, 3 },
                    { 161, 17, 9 },
                    { 154, 17, 2 },
                    { 152, 16, 10 },
                    { 151, 16, 9 },
                    { 150, 16, 8 },
                    { 149, 16, 7 },
                    { 148, 16, 6 },
                    { 147, 16, 5 },
                    { 153, 17, 1 },
                    { 180, 19, 9 },
                    { 162, 18, 1 },
                    { 164, 18, 3 },
                    { 178, 19, 7 },
                    { 177, 19, 6 },
                    { 176, 19, 5 },
                    { 175, 19, 4 },
                    { 174, 19, 3 },
                    { 173, 19, 2 },
                    { 163, 18, 2 },
                    { 172, 19, 1 },
                    { 170, 18, 9 },
                    { 169, 18, 8 },
                    { 168, 18, 7 },
                    { 167, 18, 6 },
                    { 166, 18, 5 },
                    { 165, 18, 4 },
                    { 171, 18, 10 },
                    { 146, 16, 4 },
                    { 216, 23, 7 },
                    { 218, 23, 9 },
                    { 268, 28, 10 },
                    { 267, 28, 9 },
                    { 266, 28, 8 },
                    { 265, 28, 7 },
                    { 264, 28, 6 },
                    { 263, 28, 5 },
                    { 269, 29, 1 },
                    { 262, 28, 4 },
                    { 260, 28, 2 },
                    { 259, 28, 1 },
                    { 258, 27, 10 },
                    { 257, 27, 9 },
                    { 256, 27, 8 },
                    { 255, 27, 7 },
                    { 261, 28, 3 },
                    { 254, 27, 6 },
                    { 270, 29, 2 },
                    { 272, 29, 4 },
                    { 286, 30, 8 },
                    { 285, 30, 7 },
                    { 284, 30, 6 },
                    { 283, 30, 5 },
                    { 282, 30, 4 },
                    { 281, 30, 3 },
                    { 271, 29, 3 },
                    { 280, 30, 2 },
                    { 278, 29, 10 },
                    { 277, 29, 9 },
                    { 276, 29, 8 },
                    { 275, 29, 7 },
                    { 274, 29, 6 },
                    { 273, 29, 5 },
                    { 279, 30, 1 },
                    { 217, 23, 8 },
                    { 253, 27, 5 },
                    { 251, 27, 3 },
                    { 232, 25, 4 },
                    { 231, 25, 3 },
                    { 230, 25, 2 },
                    { 229, 25, 1 },
                    { 228, 24, 9 },
                    { 227, 24, 8 },
                    { 233, 25, 5 },
                    { 226, 24, 7 },
                    { 224, 24, 5 },
                    { 223, 24, 4 },
                    { 222, 24, 3 },
                    { 221, 24, 2 },
                    { 220, 24, 1 },
                    { 219, 23, 10 },
                    { 225, 24, 6 },
                    { 252, 27, 4 },
                    { 234, 25, 6 },
                    { 236, 25, 8 },
                    { 250, 27, 2 },
                    { 249, 27, 1 },
                    { 248, 26, 10 },
                    { 247, 26, 9 },
                    { 246, 26, 8 },
                    { 245, 26, 7 },
                    { 235, 25, 7 },
                    { 244, 26, 6 },
                    { 242, 26, 4 },
                    { 241, 26, 3 },
                    { 240, 26, 2 },
                    { 239, 26, 1 },
                    { 238, 25, 10 },
                    { 237, 25, 9 },
                    { 243, 26, 5 },
                    { 145, 16, 3 },
                    { 144, 16, 2 },
                    { 143, 16, 1 },
                    { 51, 6, 1 },
                    { 50, 5, 10 },
                    { 49, 5, 9 },
                    { 48, 5, 8 },
                    { 47, 5, 7 },
                    { 46, 5, 6 },
                    { 52, 6, 2 },
                    { 45, 5, 5 },
                    { 43, 5, 3 },
                    { 42, 5, 2 },
                    { 41, 5, 1 },
                    { 40, 4, 10 },
                    { 39, 4, 9 },
                    { 38, 4, 8 },
                    { 44, 5, 4 },
                    { 37, 4, 7 },
                    { 53, 6, 3 },
                    { 55, 6, 5 },
                    { 69, 8, 1 },
                    { 68, 7, 8 },
                    { 67, 7, 7 },
                    { 66, 7, 6 },
                    { 65, 7, 5 },
                    { 64, 7, 4 },
                    { 54, 6, 4 },
                    { 63, 7, 3 },
                    { 61, 7, 1 },
                    { 60, 6, 10 },
                    { 59, 6, 9 },
                    { 58, 6, 8 },
                    { 57, 6, 7 },
                    { 56, 6, 6 },
                    { 62, 7, 2 },
                    { 70, 8, 2 },
                    { 36, 4, 6 },
                    { 34, 4, 4 },
                    { 15, 2, 5 },
                    { 14, 2, 4 },
                    { 13, 2, 3 },
                    { 12, 2, 2 },
                    { 11, 2, 1 },
                    { 10, 1, 10 },
                    { 16, 2, 6 },
                    { 9, 1, 9 },
                    { 7, 1, 7 },
                    { 6, 1, 6 },
                    { 5, 1, 5 },
                    { 4, 1, 4 },
                    { 3, 1, 3 },
                    { 2, 1, 2 },
                    { 8, 1, 8 },
                    { 35, 4, 5 },
                    { 17, 2, 7 },
                    { 19, 2, 9 },
                    { 33, 4, 3 },
                    { 32, 4, 2 },
                    { 31, 4, 1 },
                    { 30, 3, 10 },
                    { 29, 3, 9 },
                    { 28, 3, 8 },
                    { 18, 2, 8 },
                    { 27, 3, 7 },
                    { 25, 3, 5 },
                    { 24, 3, 4 },
                    { 23, 3, 3 },
                    { 22, 3, 2 },
                    { 21, 3, 1 },
                    { 20, 2, 10 },
                    { 26, 3, 6 },
                    { 71, 8, 3 },
                    { 72, 8, 4 },
                    { 73, 8, 5 },
                    { 124, 14, 1 },
                    { 123, 13, 9 },
                    { 122, 13, 8 },
                    { 121, 13, 7 },
                    { 120, 13, 6 },
                    { 119, 13, 5 },
                    { 125, 14, 2 },
                    { 118, 13, 4 },
                    { 116, 13, 2 },
                    { 115, 13, 1 },
                    { 114, 12, 10 },
                    { 113, 12, 9 },
                    { 112, 12, 8 },
                    { 111, 12, 7 },
                    { 117, 13, 3 },
                    { 110, 12, 6 },
                    { 126, 14, 3 },
                    { 128, 14, 5 },
                    { 142, 15, 9 },
                    { 141, 15, 8 },
                    { 140, 15, 7 },
                    { 139, 15, 6 },
                    { 138, 15, 5 },
                    { 137, 15, 4 },
                    { 127, 14, 4 },
                    { 136, 15, 3 },
                    { 134, 15, 1 },
                    { 133, 14, 10 },
                    { 132, 14, 9 },
                    { 131, 14, 8 },
                    { 130, 14, 7 },
                    { 129, 14, 6 },
                    { 135, 15, 2 },
                    { 109, 12, 5 },
                    { 108, 12, 4 },
                    { 107, 12, 3 },
                    { 87, 10, 1 },
                    { 86, 9, 8 },
                    { 85, 9, 7 },
                    { 84, 9, 6 },
                    { 83, 9, 5 },
                    { 82, 9, 4 },
                    { 88, 10, 2 },
                    { 81, 9, 3 },
                    { 79, 9, 1 },
                    { 78, 8, 10 },
                    { 77, 8, 9 },
                    { 76, 8, 8 },
                    { 75, 8, 7 },
                    { 74, 8, 6 },
                    { 80, 9, 2 },
                    { 89, 10, 3 },
                    { 90, 10, 4 },
                    { 91, 10, 5 },
                    { 106, 12, 2 },
                    { 105, 12, 1 },
                    { 104, 11, 8 },
                    { 103, 11, 7 },
                    { 102, 11, 6 },
                    { 101, 11, 5 },
                    { 100, 11, 4 },
                    { 99, 11, 3 },
                    { 98, 11, 2 },
                    { 97, 11, 1 },
                    { 96, 10, 10 },
                    { 95, 10, 9 },
                    { 94, 10, 8 },
                    { 93, 10, 7 },
                    { 92, 10, 6 },
                    { 287, 30, 9 },
                    { 288, 30, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ClientID",
                table: "Booking",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaHallTime_SeanceTimesID",
                table: "CinemaHallTime",
                column: "SeanceTimesID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_PhoneNumber",
                table: "Client",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenre_GenreID",
                table: "FilmGenre",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_HallRow_CinemaHallID",
                table: "HallRow",
                column: "CinemaHallID");

            migrationBuilder.CreateIndex(
                name: "IX_HallSeat_HallRowID",
                table: "HallSeat",
                column: "HallRowID");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_PhoneNumber",
                table: "Personal",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personal_RoleID",
                table: "Personal",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_BookingID",
                table: "Reservation",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_TicketID",
                table: "Reservation",
                column: "TicketID");

            migrationBuilder.CreateIndex(
                name: "IX_Seance_CinemaHallHallNumber",
                table: "Seance",
                column: "CinemaHallHallNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Seance_FilmID",
                table: "Seance",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_SeanceBoughtSeats_BoughtSeatsID",
                table: "SeanceBoughtSeats",
                column: "BoughtSeatsID");

            migrationBuilder.CreateIndex(
                name: "IX_SeanceReservedSeats_ReservedSeatsID",
                table: "SeanceReservedSeats",
                column: "ReservedSeatsID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PersonalID",
                table: "Ticket",
                column: "PersonalID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_RowID",
                table: "Ticket",
                column: "RowID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_SeanceID",
                table: "Ticket",
                column: "SeanceID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_SeatID",
                table: "Ticket",
                column: "SeatID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaHallTime");

            migrationBuilder.DropTable(
                name: "FilmGenre");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "SeanceBoughtSeats");

            migrationBuilder.DropTable(
                name: "SeanceReservedSeats");

            migrationBuilder.DropTable(
                name: "Time");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "HallSeat");

            migrationBuilder.DropTable(
                name: "Personal");

            migrationBuilder.DropTable(
                name: "Seance");

            migrationBuilder.DropTable(
                name: "HallRow");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "CinemaHall");
        }
    }
}
