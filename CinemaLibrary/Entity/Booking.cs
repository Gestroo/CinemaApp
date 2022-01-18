using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CinemaLibrary.Entity
{
    public class Booking
    {
        public int ID { get; set; }
        [Required]
        public virtual Client Client { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
       
        public int ClientID { get; set; }
        private static ApplicationContext db = Context.Db;

        public Booking() { Reservations = new List<Reservation>(); }

        public void Save()
        {
            db.SaveChanges();
        }
    }
    
}
