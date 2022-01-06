﻿// <auto-generated />
using System;
using CinemaLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CinemaLibrary.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20211222133647_newUpdateGenresMigration")]
    partial class newUpdateGenresMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("CinemaLibrary.Entity.Booking", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ClientID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("CinemaLibrary.Entity.CashBox", b =>
                {
                    b.Property<int>("CashBoxNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("PersonalID")
                        .HasColumnType("integer");

                    b.HasKey("CashBoxNumber");

                    b.HasIndex("PersonalID");

                    b.ToTable("CashBox");
                });

            modelBuilder.Entity("CinemaLibrary.Entity.CinemaHall", b =>
                {
                    b.Property<int>("HallNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("HallName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("HallNumber");

                    b.ToTable("CinemaHall");
                });

            modelBuilder.Entity("CinemaLibrary.Entity.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("CinemaLibrary.Entity.Film", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateFinish")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Restriction")
                        .HasMaxLength(2)
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Film");
                });

            modelBuilder.Entity("CinemaLibrary.Entity.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("CinemaLibrary.Entity.HallRow", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CinemaHallHallNumber")
                        .HasColumnType("integer");

                    b.Property<int>("RowNumber")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("CinemaHallHallNumber");

                    b.ToTable("HallRow");
                });

            modelBuilder.Entity("CinemaLibrary.Entity.HallSeat", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("HallRowID")
                        .HasColumnType("integer");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("HallRowID");

                    b.ToTable("HallSeat");
                });

            modelBuilder.Entity("CinemaLibrary.Entity.Personal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PersonalRoleID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("PersonalRoleID");

                    b.ToTable("Personal");
                });

            modelBuilder.Entity("CinemaLibrary.Entity.PriceFormer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Discount")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeSpan>("PriceTime")
                        .HasColumnType("interval");

                    b.Property<bool>("PriceWeekend")
                        .HasColumnType("boolean");

                    b.HasKey("ID");

                    b.ToTable("PriceFormer");
                });

            modelBuilder.Entity("CinemaLibrary.Entity.Reservation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("BookingID")
                        .HasColumnType("integer");

                    b.Property<int?>("TicketID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("BookingID");

                    b.HasIndex("TicketID");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("CinemaLibrary.Entity.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("PersonalRole")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("CinemaLibrary.Entity.Seance", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CinemaHallHallNumber")
                        .HasColumnType("integer");

                    b.Property<int?>("FilmID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("SeanceDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.HasIndex("CinemaHallHallNumber");

                    b.HasIndex("FilmID");

                    b.ToTable("Seance");
                });

            modelBuilder.Entity("CinemaLibrary.Entity.Ticket", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CashBoxNumber")
                        .HasColumnType("integer");

                    b.Property<bool>("Reservation")
                        .HasColumnType("boolean");

                    b.Property<int?>("RowID")
                        .HasColumnType("integer");

                    b.Property<int?>("SeatID")
                        .HasColumnType("integer");

                    b.Property<int>("TicketNumber")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.HasKey("ID");

                    b.HasIndex("CashBoxNumber");

                    b.HasIndex("RowID");

                    b.HasIndex("SeatID");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("FilmGenre", b =>
                {
                    b.Property<int>("FilmsID")
                        .HasColumnType("integer");

                    b.Property<int>("GenreID")
                        .HasColumnType("integer");

                    b.HasKey("FilmsID", "GenreID");

                    b.HasIndex("GenreID");

                    b.ToTable("FilmGenre");
                });

            modelBuilder.Entity("CinemaLibrary.Entity.Booking", b =>
                {
                    b.HasOne("CinemaLibrary.Entity.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("CinemaLibrary.Entity.CashBox", b =>
                {
                    b.HasOne("CinemaLibrary.Entity.Personal", "Personal")
                        .WithMany()
                        .HasForeignKey("PersonalID");

                    b.Navigation("Personal");
                });

            modelBuilder.Entity("CinemaLibrary.Entity.HallRow", b =>
                {
                    b.HasOne("CinemaLibrary.Entity.CinemaHall", "CinemaHall")
                        .WithMany("Rows")
                        .HasForeignKey("CinemaHallHallNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CinemaHall");
                });

            modelBuilder.Entity("CinemaLibrary.Entity.HallSeat", b =>
                {
                    b.HasOne("CinemaLibrary.Entity.HallRow", "HallRow")
                        .WithMany("Seats")
                        .HasForeignKey("HallRowID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HallRow");
                });

            modelBuilder.Entity("CinemaLibrary.Entity.Personal", b =>
                {
                    b.HasOne("CinemaLibrary.Entity.Role", "PersonalRole")
                        .WithMany()
                        .HasForeignKey("PersonalRoleID");

                    b.Navigation("PersonalRole");
                });

            modelBuilder.Entity("CinemaLibrary.Entity.Reservation", b =>
                {
                    b.HasOne("CinemaLibrary.Entity.Booking", null)
                        .WithMany("Reservations")
                        .HasForeignKey("BookingID");

                    b.HasOne("CinemaLibrary.Entity.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketID");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("CinemaLibrary.Entity.Seance", b =>
                {
                    b.HasOne("CinemaLibrary.Entity.CinemaHall", "CinemaHall")
                        .WithMany()
                        .HasForeignKey("CinemaHallHallNumber");

                    b.HasOne("CinemaLibrary.Entity.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmID");

                    b.Navigation("CinemaHall");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("CinemaLibrary.Entity.Ticket", b =>
                {
                    b.HasOne("CinemaLibrary.Entity.CashBox", "CashBox")
                        .WithMany()
                        .HasForeignKey("CashBoxNumber");

                    b.HasOne("CinemaLibrary.Entity.HallRow", "Row")
                        .WithMany()
                        .HasForeignKey("RowID");

                    b.HasOne("CinemaLibrary.Entity.HallSeat", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatID");

                    b.Navigation("CashBox");

                    b.Navigation("Row");

                    b.Navigation("Seat");
                });

            modelBuilder.Entity("FilmGenre", b =>
                {
                    b.HasOne("CinemaLibrary.Entity.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaLibrary.Entity.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CinemaLibrary.Entity.Booking", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("CinemaLibrary.Entity.CinemaHall", b =>
                {
                    b.Navigation("Rows");
                });

            modelBuilder.Entity("CinemaLibrary.Entity.HallRow", b =>
                {
                    b.Navigation("Seats");
                });
#pragma warning restore 612, 618
        }
    }
}
