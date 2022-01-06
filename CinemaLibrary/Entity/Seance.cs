using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;


namespace CinemaLibrary.Entity
{
    public class Seance
    {
        public int ID { get; set; }
        [Required]
        public virtual CinemaHall CinemaHall { get; set; }
        [Required]
        public virtual Film Film { get; set; }
        [Required]
        public DateTime SeanceDate { get; set; }
        private static ApplicationContext db = Context.Db;
        public static List<Seance> GetSeances() 
        {
             { return db.Seance.ToList(); }
        }
    }
}
