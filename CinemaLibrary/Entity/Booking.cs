using System;
using System.Collections.Generic;

namespace CinemaLibrary.Entity
{
    public class Booking
    {
        public int ID { get; set; }
        public virtual Client Client { get; set; }
        public DateTime DateTime { get; set; }
        public virtual List<Reservation> Reservations { get; set; }

        public int ClientID { get; set; }
        private static ApplicationContext db = Context.Db;

        public Booking() { Reservations = new List<Reservation>(); }

        public static void Add(Booking booking)
        {
            db.Add(booking);
            db.SaveChanges();
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }

}
