using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace CinemaLibrary.Entity
{
    public class HallSeat //Место
    {

        public int ID { get; set; }
        [Required]
        public virtual HallRow HallRow { get; set; }
        [Required]
        public int SeatNumber { get; set; }
        public virtual List<Seance> BoughtSeances { get;set;}
        public virtual List<Seance> ReservedSeances { get; set; }
        private static ApplicationContext db = Context.Db;

        public int HallRowID { get; set; }
        public HallSeat() 
        {
            BoughtSeances = new List<Seance>();
            ReservedSeances = new List<Seance>();
        }

        public static HallSeat FindSeat(int row, int number) 
        {
            return db.HallSeat.FirstOrDefault(h => h.HallRow.RowNumber == row && h.SeatNumber == number);
        }
    }
}
