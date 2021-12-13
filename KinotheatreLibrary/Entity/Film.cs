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
        public string Genre { get; set; }
        [MaxLength(2)]
        [Required]
        public int Restriction { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateFinish { get; set; }

        public static List<string> GetFilmName()
        {
            using (var db = new ApplicationContext())
            {
                return db.Film.Select(x => x.Name).ToList();
            }
        }
    }
}
