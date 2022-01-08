using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

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
