using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CinemaLibrary.Entity
{
    public class Role
    {
        public int ID { get; set; }
        [Required]
        public string PersonalRole { get; set; }
    }
}
