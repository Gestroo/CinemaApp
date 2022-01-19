using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CinemaLibrary.Entity
{
    public class Genre //Жанр
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public virtual List<Film> Films { get; set; }

        public Genre() { Films = new List<Film>(); }

        private static ApplicationContext db = Context.Db;
        public static List<string> GetGenres()
        {
            return db.Genre.Select(g => g.Title).ToList();
        }
        public static Genre GetGenreByTitle(string title)
        {
            return db.Genre.Where(g => g.Title == title).FirstOrDefault();
        }
    }
}

