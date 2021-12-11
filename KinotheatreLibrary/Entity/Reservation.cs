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
        public Ticket Ticket { get; set; }
    }
}
