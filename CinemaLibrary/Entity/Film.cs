using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace CinemaLibrary.Entity
{
    public class Film
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public virtual List<Genre> Genre { get; set; }
        [Required]
        public int Restriction { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateFinish { get; set; }

        public Film() { Genre = new List<Genre>(); }

        private static ApplicationContext db = Context.Db;
        public static List<string> GetFilmName()
        {  
           return db.Film.Select(x => x.Name).ToList();
        }
        public static List<Film> GetFilms() => db.Film.ToList(); //лямбда-выражение заменяет return
        
        public static void Add(Film film) 
        {
            db.Film.Add(film);
            db.SaveChanges();
        }
    }
}
