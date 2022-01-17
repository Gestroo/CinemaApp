using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CinemaLibrary.Entity
{
    public class Ticket
    {
        public int ID { get; set; }
        public virtual Seance Seance{ get; set; }
        [Required]
        public virtual HallRow Row{ get; set; }
        [Required]
        public virtual HallSeat Seat { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        public int SeanceID { get; set; }

        [Required]
        public virtual Personal Personal { get; set; }

    }
}
