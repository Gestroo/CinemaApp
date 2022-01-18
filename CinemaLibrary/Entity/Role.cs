using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CinemaLibrary.Entity
{
    public class Role //Роль доступа
    {
        public int ID { get; set; }
        [Required]
        public string PersonalRole { get; set; }

        public virtual List<Personal> Personals {get;set;}

        public Role() 
        {
            Personals = new List<Personal>();
        }
    }
}
