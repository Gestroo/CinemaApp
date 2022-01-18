using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CinemaLibrary.Entity;
using CinemaLibrary;
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
            modelBuilder.Entity<Film>().Ignore(f => f.Genres).Ignore(f=>f.ogranPlus);
            modelBuilder.Entity<Seance>().HasMany(s => s.BoughtSeats).WithMany(bs => bs.BoughtSeances).UsingEntity(j => j.ToTable("SeanceBoughtSeats"));
            modelBuilder.Entity<Seance>().HasMany(s => s.ReservedSeats).WithMany(rs => rs.ReservedSeances).UsingEntity(j => j.ToTable("SeanceReservedSeats"));
            modelBuilder.Entity<CinemaHall>().HasMany(c => c.SeanceTimes).WithMany(s=>s.Halls).UsingEntity(j=>j.ToTable("CinemaHallTime"));
            modelBuilder.Entity<Role>().HasData(new Role
            {
                ID = 1,
                PersonalRole = "admin"
            },
            new Role
            {
                ID = 2,
                PersonalRole = "cashier"
            }
            ) ;
            modelBuilder.Entity<Personal>().HasData(new Personal
            {
                ID = 1,
                Login = "admin",
                Password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
                LastName = "Широков",
                FirstName = "Дмитрий",
                MiddleName = "Романович",
                RoleID = 1
            },
            new Personal
            {
                ID = 2,
                Login = "cashier1",
                Password = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5",
                LastName = "Ромашкова",
                FirstName = "Зинаида",
                MiddleName = "Григорьевна",
                RoleID = 2
            }
            ) ;

            modelBuilder.Entity<Genre>().HasData(
            
                new Genre
                {
                ID =1,
                Title = "Боевик"
                },
                new Genre
                {
                    ID = 2,
                    Title = "Ужасы"
                },
                new Genre
                {
                    ID = 3,
                    Title = "Мультфильм"
                },
                new Genre
                {
                    ID = 4,
                    Title = "Комедия"
                },
                new Genre
                {
                    ID = 5,
                    Title = "Фантастика"
                },
                new Genre
                {
                    ID = 6,
                    Title = "Фэнтези"
                },
                new Genre
                {
                    ID = 7,
                    Title = "Драма"
                },
                new Genre
                {
                    ID = 8,
                    Title = "Мелодрама"
                },
                new Genre
                {
                    ID = 9,
                    Title = "Вестерн"
                },
                new Genre
                {
                    ID = 10,
                    Title = "Аниме"
                },
                new Genre
                {
                    ID = 11,
                    Title = "Триллер"
                }
            );

             tmptimes = new List<Time>
            {
                new Time
                {
                    ID = 1,
                    SeanceTime = DateTime.Parse("1/1/0001 9:00")
                },
                new Time
                {
                    ID = 2,
                    SeanceTime = DateTime.Parse("1/1/0001 11:10")
                },
                new Time
                {
                    ID = 3,
                    SeanceTime = DateTime.Parse("1/1/0001 13:30")
                },
                new Time
                {
                    ID = 4,
                    SeanceTime = DateTime.Parse("1/1/0001 16:00")
                },
                new Time
                {
                    ID = 5,
                    SeanceTime = DateTime.Parse("1/1/0001 18:30")
                },
                new Time
                {
                    ID = 6,
                    SeanceTime = DateTime.Parse("1/1/0001 21:00")
                },
                new Time
                {
                    ID = 7,
                    SeanceTime = DateTime.Parse("1/1/0001 23:20")
                },
                new Time
                {
                    ID = 8,
                    SeanceTime = DateTime.Parse("1/1/0001 8:30")
                },
                new Time
                {
                    ID = 9,
                    SeanceTime = DateTime.Parse("1/1/0001 11:00")
                },
                new Time
                {
                    ID = 10,
                    SeanceTime = DateTime.Parse("1/1/0001 13:40")
                },
                new Time
                {
                    ID = 11,
                    SeanceTime = DateTime.Parse("1/1/0001 16:20")
                },
                new Time
                {
                    ID = 12,
                    SeanceTime = DateTime.Parse("1/1/0001 19:00")
                },
                new Time
                {
                    ID = 13,
                    SeanceTime = DateTime.Parse("1/1/0001 21:30")
                },
                new Time
                {
                    ID = 14,
                    SeanceTime = DateTime.Parse("1/1/0001 13:00")
                },
                new Time
                {
                    ID = 15,
                    SeanceTime = DateTime.Parse("1/1/0001 15:30")
                },
                new Time
                {
                    ID = 16,
                    SeanceTime = DateTime.Parse("1/1/0001 18:00")
                },
                new Time
                {
                    ID = 17,
                    SeanceTime = DateTime.Parse("1/1/0001 20:30")
                },
                new Time
                {
                    ID = 18,
                    SeanceTime = DateTime.Parse("1/1/0001 23:00")
                },
                new Time
                {
                    ID = 19,
                    SeanceTime = DateTime.Parse("1/1/0001 9:20")
                },
                new Time
                {
                    ID = 20,
                    SeanceTime = DateTime.Parse("1/1/0001 11:40")
                },
                new Time
                {
                    ID = 21,
                    SeanceTime = DateTime.Parse("1/1/0001 13:50")
                },
                new Time
                {
                    ID = 22,
                    SeanceTime = DateTime.Parse("1/1/0001 21:40")
                },
                new Time
                {
                    ID = 23,
                    SeanceTime = DateTime.Parse("1/1/0001 8:40")
                },
                new Time
                {
                    ID = 24,
                    SeanceTime = DateTime.Parse("1/1/0001 10:30")
                },
                new Time
                {
                    ID = 25,
                    SeanceTime = DateTime.Parse("1/1/0001 12:30")
                },
                new Time
                {
                    ID = 26,
                    SeanceTime = DateTime.Parse("1/1/0001 15:00")
                },
                new Time
                {
                    ID = 27,
                    SeanceTime = DateTime.Parse("1/1/0001 17:10")
                },
                new Time
                {
                    ID = 28,
                    SeanceTime = DateTime.Parse("1/1/0001 19:40")
                },
                new Time
                {
                    ID = 29,
                    SeanceTime = DateTime.Parse("1/1/0001 22:20")
                }
                
            };
            modelBuilder.Entity<Time>().HasData(tmptimes);

            

            modelBuilder.Entity<CinemaHall>().HasData(new CinemaHall
            {
                HallNumber = 1,
                HallName = "Зал 1",
             /*   SeanceTimes = new List<Time> 
                { 
                tmptimes[0],
                tmptimes[1],
                tmptimes[2],
                tmptimes[3],
                tmptimes[4],
                tmptimes[5],
                tmptimes[6],
                }*/
            },
            new CinemaHall
            {
                HallNumber = 2,
                HallName = "Зал 2",
              /*  SeanceTimes = new List<Time>
                {
                tmptimes[7],
                tmptimes[8],
                tmptimes[9],
                tmptimes[10],
                tmptimes[11],
                tmptimes[12],
                }*/
            },
            new CinemaHall
            {
                HallNumber = 3,
                HallName = "Зал 3",
              /*  SeanceTimes = new List<Time>
                {
                tmptimes[0],
                tmptimes[8],
                tmptimes[13],
                tmptimes[14],
                tmptimes[15],
                tmptimes[16],
                tmptimes[17],
                }*/
            },
            new CinemaHall
            {
                HallNumber = 4,
                HallName = "Зал 4",
              /* SeanceTimes = new List<Time>
                {
                tmptimes[18],
                tmptimes[19],
                tmptimes[20],
                tmptimes[10],
                tmptimes[11],
                tmptimes[21],
                }*/
            },
            new CinemaHall
            {
                HallNumber = 5,
                HallName = "Зал 5",
             /*   SeanceTimes = new List<Time>
                {
                tmptimes[22],
                tmptimes[23],
                tmptimes[24],
                tmptimes[25],
                tmptimes[26],
                tmptimes[27],
                tmptimes[28],
                }*/
            }
            );
            var rows = new List<HallRow>();//Добавление рядов
            for (int i = 1; i < 7; i++)
                rows.Add(new HallRow { ID = i, RowNumber = i, CinemaHallID = 1 });
            for (int i = 7; i < 13; i++)
                rows.Add(new HallRow { ID = i, RowNumber = i - 6, CinemaHallID = 2 });
            for (int i = 13; i < 19; i++)
                rows.Add(new HallRow { ID = i, RowNumber = i - 12, CinemaHallID = 3 });
            for (int i = 19; i < 25; i++)
                rows.Add(new HallRow { ID = i, RowNumber = i - 18, CinemaHallID = 4 });
            for (int i = 25; i < 31; i++)
                rows.Add(new HallRow { ID = i, RowNumber = i - 24, CinemaHallID = 5 });
            modelBuilder.Entity<HallRow>().HasData(rows);
            var seats = new List<HallSeat>();
            int count = 1;
            for (int i = 0; i < 6; i++)//заполнение мест для первого зала
                for (int j = 1; j < 11; j++)
                {
                    seats.Add(new HallSeat { ID = count, SeatNumber = j, HallRowID = rows[i].ID });
                    count++;
                }
            for (int i = 6; i < 12; i++)//для второго зала
                if (i % 2 == 0)
                    for (int j = 1; j < 9; j++)
                    {
                        seats.Add(new HallSeat { ID = count, SeatNumber = j, HallRowID = rows[i].ID });
                        count++;
                    }
                else
                    for (int j = 1; j < 11; j++)
                    {
                        seats.Add(new HallSeat { ID = count, SeatNumber = j, HallRowID = rows[i].ID });
                        count++;
                    }
            for (int i = 12; i < 18; i++)//для третьего зала
                if (i % 2 == 0)
                    for (int j = 1; j < 10; j++)
                    {
                        seats.Add(new HallSeat { ID = count, SeatNumber = j, HallRowID = rows[i].ID });
                        count++;
                    }
                else
                    for (int j = 1; j < 11; j++)
                    {
                        seats.Add(new HallSeat { ID = count, SeatNumber = j, HallRowID = rows[i].ID });
                        count++;
                    }
            for (int i = 18; i < 24; i++)//для четвертого зала
                if (i % 2 == 0)
                    for (int j = 1; j < 11; j++)
                    {
                        seats.Add(new HallSeat { ID = count, SeatNumber = j, HallRowID = rows[i].ID });
                        count++;
                    }
                else
                    for (int j = 1; j < 10; j++)
                    {
                        seats.Add(new HallSeat { ID = count, SeatNumber = j, HallRowID = rows[i].ID });
                        count++;
                    }
            for (int i = 24; i < 30; i++)// для пятого зала
                for (int j = 1; j < 11; j++)
                {
                    seats.Add(new HallSeat { ID = count, SeatNumber = j, HallRowID = rows[i].ID });
                    count++;
                }
            modelBuilder.Entity<HallSeat>().HasData(seats);
        }
    }
}
