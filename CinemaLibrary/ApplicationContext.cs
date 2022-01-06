using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CinemaLibrary.Entity;
using CinemaLibrary;

namespace CinemaLibrary
{
     public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) :base(options)
        {
            Database.Migrate();
            Context.AddDb(this);
        }
            public DbSet<Booking> Booking { get; set; }
            public DbSet<CashBox> CashBox { get; set; }
            public DbSet<CinemaHall> CinemaHall { get; set; }
            public DbSet<Client> Client { get; set; }
            public DbSet<Film>Film { get; set; }
            public DbSet<Genre> Genre { get; set; }
            public DbSet<HallRow> HallRow { get; set; }
            public DbSet<Personal> Personal { get; set; }
            public DbSet<PriceFormer> PriceFormer { get; set; }
            public DbSet<Reservation> Reservation { get; set; }
            public DbSet<Role> Role { get; set; }
            public DbSet<Seance> Seance { get; set; }
            public DbSet<Ticket> Ticket { get; set; }
    
        public static DbContextOptions<ApplicationContext> GetDb()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            return optionsBuilder.UseLazyLoadingProxies().UseNpgsql("Host=localhost;Port=5432;Database=cinema;Username=Gestroo;Password=123").Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Personal>().Ignore(p => p.FullName);
            modelBuilder.Entity<Client>().Ignore(c => c.FullName);
            modelBuilder.Entity<Client>().HasIndex(c => c.Email).IsUnique();
        }
    }
}
