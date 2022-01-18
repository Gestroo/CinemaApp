using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CinemaLibrary.Entity
{
    public class Reservation
    {
        public int ID { get; set; }
        [Required]
        public virtual Ticket Ticket { get; set; }

        private static ApplicationContext db = Context.Db;
        public static void Add(Reservation reservation)
        {
            db.Reservation.Add(reservation);
            db.SaveChanges();
        }
    }
}
