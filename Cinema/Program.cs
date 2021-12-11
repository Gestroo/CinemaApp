using System;
using CinemaLibrary;
using CinemaLibrary.Entity;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ApplicationContext()) 
            { db.Client.Add(new Client { Login = "vadevid", Password = "kisliy123", FirstName = "Иван", LastName = "Кислицын", PhoneNumber = "+79998887766", BirthDate = DateTime.Parse("2002-02-03") });
                db.SaveChanges();
            }
             
        }
    }
}
