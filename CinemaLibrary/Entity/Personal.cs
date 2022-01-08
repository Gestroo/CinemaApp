using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace CinemaLibrary.Entity
{
    public class Personal
    {
        public int ID { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }//отчество
        public int RoleID { get; set; }
        public string FullName
        {
            get
            {
                var temp = $"{LastName} {FirstName.Substring(0, 1)}.";
                if (MiddleName != null) temp += $" {MiddleName.Substring(0, 1)}.";
                return temp;
            }
        }
        public virtual Role Role { get; set; }
        private static ApplicationContext db = Context.Db;

        public static Personal GetPersonal(string Login, string Password)
        {
            return db.Personal.Where(g => g.Login == Login && g.Password == Password).FirstOrDefault();
        }
        
    }
}
