using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace CinemaLibrary.Entity
{
    public class Seance //Сеанс
    {
        public int ID { get; set; }
        [Required]
        public virtual CinemaHall CinemaHall { get; set; }
        [Required]
        public virtual Film Film { get; set; }
        [Required]
        public DateTime SeanceDate { get; set; }

        public virtual List<HallSeat> BoughtSeats { get; set; }
        public virtual List<HallSeat> ReservedSeats { get; set; }
        public int Cost { get; set; }

        public string Date { get { return SeanceDate.ToString("d"); } }
        public string Time { get { return SeanceDate.ToString("t"); } }

        public Seance()
        {
            BoughtSeats = new List<HallSeat>();
            ReservedSeats = new List<HallSeat>();
        }

        private static ApplicationContext db = Context.Db;
        public static List<Seance> GetSeances()
        {
            { return db.Seance.ToList(); }
        }
        public static Seance GetSeance(DateTime dateTime, CinemaHall cinemaHall)
        {
            return db.Seance.Where(s => s.SeanceDate == dateTime).Where(s => s.CinemaHall == cinemaHall).FirstOrDefault();
        }
        public static void Add(Seance seance)
        {
            db.Seance.Add(seance);
            db.SaveChanges();
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
