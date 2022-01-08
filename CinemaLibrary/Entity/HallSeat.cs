using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace CinemaLibrary.Entity
{
    public class HallSeat
    {
     
        public int ID { get; set; }
        [Required]
        public virtual HallRow HallRow { get; set; }
        [Required]
        public int SeatNumber { get; set; }
        private static ApplicationContext db = Context.Db;

        public int HallRowID { get; set; }
    }
}
