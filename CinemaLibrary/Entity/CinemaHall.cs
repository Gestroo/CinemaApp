using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CinemaLibrary.Entity
{
    public class CinemaHall //Кинозал
    {
        [Key]
        public int HallNumber { get; set; }
        public string HallName { get; set; }
        public virtual List<HallRow> Rows { get; set; }
        public virtual List<Time> SeanceTimes { get; set; }

        private static ApplicationContext db = Context.Db;


        public CinemaHall()
        {

            Rows = new List<HallRow>();
            SeanceTimes = new List<Time>();
        }

        public static List<CinemaHall> GetHalls()
        {
            return db.CinemaHall.ToList();
        }
    }
}
