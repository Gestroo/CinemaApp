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


        public Booking() { Reservations = new List<Reservation>(); }
    }

    
}
