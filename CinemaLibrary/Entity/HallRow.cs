using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CinemaLibrary.Entity
{
    public class HallRow //Ряд
    {
        public int ID { get; set; }
        [Required]
        public virtual CinemaHall CinemaHall { get; set; }
        [Required]
        public int RowNumber { get; set; }
        [Required]
        public virtual List<HallSeat> Seats { get; set; }

        public int CinemaHallID { get; set; }

        public HallRow() { Seats = new List<HallSeat>(); }
        private static ApplicationContext db = Context.Db;
        public static HallRow GetHallRowByNumber(int rowNumber)
        {
            return db.HallRow.FirstOrDefault(h => h.RowNumber == rowNumber);
        }
    }
}
