﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CinemaLibrary.Entity
{
    public class Time //Времена сеансов
    {
        public int ID { get; set; }
        [Required]
        public DateTime SeanceTime { get; set; }

        public virtual List<CinemaHall> Halls { get; set; }

        public Time()
        {
            Halls = new List<CinemaHall>();
        }    

    }
}
