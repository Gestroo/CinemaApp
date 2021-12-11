using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CinemaLibrary.Entity;

namespace CinemaLibrary
{
     public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
           // Database.EnsureDeleted();
            Database.EnsureCreated();
        }
            public DbSet<Booking> Booking { get; set; }
            public DbSet<CashBox> CashBox { get; set; }
            public DbSet<CinemaHall> CinemaHall { get; set; }
            public DbSet<Client> Client { get; set; }
            public DbSet<Film>Film { get; set; }
            public DbSet<HallRow> HallRow { get; set; }
            public DbSet<Personal> Personal { get; set; }
            public DbSet<PriceFormer> PriceFormer { get; set; }
            public DbSet<Reservation> Reservation { get; set; }
            public DbSet<Role> Role { get; set; }
            public DbSet<Seance> Seance { get; set; }
            public DbSet<Ticket> Ticket { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=cinema;Username=Gestroo;Password=123");
        }
    }
}
