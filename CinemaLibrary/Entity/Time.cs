using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CinemaLibrary.Entity
{
    public class Time //Времена сеансов
    {
        public int ID { get; set; }
        [Required]
        public DateTime SeanceTime { get; set; }

        public virtual List<CinemaHall> Halls { get; set; }
        private static ApplicationContext db = Context.Db;
        public Time()
        {
            Halls = new List<CinemaHall>();
        }
        public static Time GetTimeByID(int id) 
        {
            return db.Time.FirstOrDefault(t => t.ID == id);     
        }
    }
}
