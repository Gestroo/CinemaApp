using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CinemaLibrary.Entity
{
    public class CashBox //билетная касса
    {
    [Key]
        public int CashBoxNumber { get; set; }
        [Required]
        public virtual Personal Personal { get; set; }
    }
}
