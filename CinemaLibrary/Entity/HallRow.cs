using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CinemaLibrary.Entity
{
    public class HallRow
    {
        public int ID { get; set; }
        [Required]
        public virtual CinemaHall CinemaHall { get; set; }
        [Required]
        public int RowNumber { get; set; }
        [Required]
        public virtual List<HallSeat> Seats { get; set; } 
        
        public int CinemaHallID { get; set; }

        public HallRow() {Seats = new List<HallSeat>(); }
    }
}
