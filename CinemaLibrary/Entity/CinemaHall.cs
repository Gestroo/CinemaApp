using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CinemaLibrary.Entity
{
    public class CinemaHall
    {
    [Key]
        public int HallNumber { get; set; }
        [Required]
        public string HallName { get; set; }
        [Required]
        public virtual List<HallRow> Rows { get; set; } 

        public CinemaHall() { Rows = new List<HallRow>(); }
    }
}
