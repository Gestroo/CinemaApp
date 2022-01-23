using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CinemaLibrary.Entity
{
    public class Client : Human //Клиент
    {
        public int ID { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public virtual List<Booking> Bookings { get; set; }

        private static ApplicationContext db = Context.Db;
        public Client()
        {
            Bookings = new List<Booking>();
        }

        public Client(string LastName, string FirstName, string MiddleName, string PhoneNumber, DateTime BirthDate)
            : base(LastName, FirstName, MiddleName, PhoneNumber)
        {
            this.BirthDate = BirthDate;
            Bookings = new List<Booking>();
        }
        public static Client FindClient(string lastName, string firstName, string middleName, string phoneNumber, DateTime birthDate)
        {
            return db.Client.Where(c => c.LastName == lastName && c.FirstName == firstName && c.MiddleName == middleName && c.PhoneNumber == phoneNumber && c.BirthDate == birthDate).FirstOrDefault();
        }
        public static Client FindClientByTicket(Seance seance, int row, int seat)
        {
            return db.Client.FirstOrDefault(c => c.Bookings.Any(b => b.Reservations.Any(r => r.Ticket == Ticket.FindTicket(seance, row, seat))));

        }
        public static void Add(Client client)
        {
            db.Client.Add(client);
            db.SaveChanges();
        }
        public override string GetFullName()
        {
            return "Клиент: " + base.GetFullName();
        }

    }
}
