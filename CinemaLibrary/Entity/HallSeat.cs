using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CinemaLibrary.Entity
{
    public class HallSeat
    {
     
        public int ID { get; set; }
        [Required]
        public virtual HallRow HallRow { get; set; }
        [Required]
        public int SeatNumber { get; set; }
    }
}
