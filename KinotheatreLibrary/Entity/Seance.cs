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
        public CinemaHall CinemaHall { get; set; }
        [Required]
        public Film Film { get; set; }
        [Required]
        public DateTime SeanceDate { get; set; }

        public static List<Seance> GetSeances() 
        {
            using (var db = new ApplicationContext()) { return db.Seance.ToList(); }
        }
    }
}
