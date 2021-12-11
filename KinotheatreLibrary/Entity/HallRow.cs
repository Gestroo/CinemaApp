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
        public CinemaHall CinemaHall { get; set; }
        [Required]
        public int RowNumber { get; set; }
        public List<HallSeat> Seats { get; set; } = new List<HallSeat>(); 
    }
}
