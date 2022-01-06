using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CinemaLibrary.Entity
{
    public class PriceFormer
    {
        public int ID { get; set; }
        [Required]
        public bool PriceWeekend { get; set; }
        [Required]
        public TimeSpan PriceTime { get; set; }
        [Required]
        public string Discount { get; set; }
    }
}
