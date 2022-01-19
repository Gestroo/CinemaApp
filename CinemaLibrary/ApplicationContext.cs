using CinemaLibrary.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CinemaLibrary
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.Migrate();
            Context.AddDb(this);
        }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<CinemaHall> CinemaHall { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Film> Film { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<HallRow> HallRow { get; set; }
        public DbSet<HallSeat> HallSeat { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Seance> Seance { get; set; }
        public DbSet<Ticket> Ticket { get; set; }

        public static DbContextOptions<ApplicationContext> GetDb()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            return optionsBuilder.UseLazyLoadingProxies().UseNpgsql("Host=localhost;Port=5432;Database=cinema;Username=Gestroo;Password=123").Options;
        }

        public static List<Time> tmptimes;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seance>().Ignore(s => s.Date).Ignore(s => s.Time);
            modelBuilder.Entity<Film>().Ignore(f => f.Genres).Ignore(f => f.ogranPlus);
            modelBuilder.Entity<Seance>().HasMany(s => s.BoughtSeats).WithMany(bs => bs.BoughtSeances).UsingEntity(j => j.ToTable("SeanceBoughtSeats"));
            modelBuilder.Entity<Seance>().HasMany(s => s.ReservedSeats).WithMany(rs => rs.ReservedSeances).UsingEntity(j => j.ToTable("SeanceReservedSeats"));
            modelBuilder.Entity<CinemaHall>().HasMany(c => c.SeanceTimes).WithMany(s => s.Halls).UsingEntity(j => j.ToTable("CinemaHallTime"));
            modelBuilder.Entity<Personal>(EntityConfiguration.PersonalConfigure);
            modelBuilder.Entity<Role>(EntityConfiguration.RoleDataConfigure);
            modelBuilder.Entity<Personal>(EntityConfiguration.PersonalDataConfigure);
            modelBuilder.Entity<Client>(EntityConfiguration.ClientConfigure);
            modelBuilder.Entity<Genre>(EntityConfiguration.GenreDataConfigure);
            modelBuilder.Entity<Time>(EntityConfiguration.TimeDataConfigure);
            modelBuilder.Entity<CinemaHall>(EntityConfiguration.HallDataConfigure);
            modelBuilder.Entity<HallRow>(EntityConfiguration.RowsDataConfigure);
            modelBuilder.Entity<HallSeat>(EntityConfiguration.SeatsDataConfigure);
        }
    }
}
