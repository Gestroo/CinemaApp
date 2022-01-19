using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CinemaLibrary.Entity
{
    public class Personal : Human // Персонал
    {
        public int ID { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public int RoleID { get; set; }

        public virtual Role Role { get; set; }
        private static ApplicationContext db = Context.Db;

        public Personal(string LastName, string FirstName, string MiddleName, string PhoneNumber)
            : base(LastName, FirstName, MiddleName, PhoneNumber)
        {

        }
        public Personal(string LastName, string FirstName, string PhoneNumber) : base(LastName, FirstName, PhoneNumber) { }
        public static Personal GetPersonal(string Login, string Password)
        {
            return db.Personal.Where(g => g.Login == Login && g.Password == Password).FirstOrDefault();
        }
        public override string GetFullName()
        {
            if (RoleID == 2)
                return "Кассир: " + base.GetFullName();
            if (RoleID == 1)
                return "Админ :" + base.GetFullName();
            return null;
        }
    }
}
