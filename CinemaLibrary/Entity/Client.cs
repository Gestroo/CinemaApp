using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CinemaLibrary.Entity
{
    public class Client
    {
        public int ID { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }//отчество
        public string FullName
        {
            get
            {
                var temp = $"{LastName} {FirstName.Substring(0, 1)}.";
                if (MiddleName != null) temp += $" {MiddleName.Substring(0, 1)}.";
                return temp;
            }
        }
        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
    }
}
