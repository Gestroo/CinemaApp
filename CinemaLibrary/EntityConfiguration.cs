using CinemaLibrary.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace CinemaLibrary
{
    static class EntityConfiguration
    {
        public static void PersonalConfigure(EntityTypeBuilder<Personal> builder)
        {
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(15);
            builder.Property(e => e.MiddleName).HasMaxLength(50);
            builder.HasIndex(e => e.PhoneNumber).IsUnique();
        }

        public static void ClientConfigure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(15);
            builder.Property(e => e.MiddleName).HasMaxLength(50);
            builder.HasIndex(e => e.PhoneNumber).IsUnique();
        }


        public static void RoleDataConfigure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role
            {
                ID = 1,
                PersonalRole = "admin"
            },
                new Role
                {
                    ID = 2,
                    PersonalRole = "cashier"
                }
                );
        }

        public static void PersonalDataConfigure(EntityTypeBuilder<Personal> builder)
        {
            builder.HasData(new Personal
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
             );
        }
        public static void GenreDataConfigure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(

                    new Genre
                    {
                        ID = 1,
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
        }
        public static void TimeDataConfigure(EntityTypeBuilder<Time> builder)
        {
            var tmptimes = new List<Time>
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
            builder.HasData(tmptimes);

        }
        public static void HallDataConfigure(EntityTypeBuilder<CinemaHall> builder)
        {
            builder.HasData(new CinemaHall
            {
                HallNumber = 1,
                HallName = "Зал 1",
            },
                new CinemaHall
                {
                    HallNumber = 2,
                    HallName = "Зал 2",
                },
                new CinemaHall
                {
                    HallNumber = 3,
                    HallName = "Зал 3",
                },
                new CinemaHall
                {
                    HallNumber = 4,
                    HallName = "Зал 4",
                },
                new CinemaHall
                {
                    HallNumber = 5,
                    HallName = "Зал 5",
                }
                );
        }
        static List<HallRow> rows;
        public static void RowsDataConfigure(EntityTypeBuilder<HallRow> builder)
        {
            rows = new List<HallRow>();//Добавление рядов
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
            builder.HasData(rows);
        }
        public static void SeatsDataConfigure(EntityTypeBuilder<HallSeat> builder)
        {
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
            builder.HasData(seats);
        }
    }

}

