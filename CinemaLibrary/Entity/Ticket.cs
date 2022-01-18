using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace CinemaLibrary.Entity
{
    public class Ticket //Билет
    {
        public int ID { get; set; }
        public virtual Seance Seance { get; set; }
        [Required]
        public virtual HallRow Row { get; set; }
        [Required]
        public virtual HallSeat Seat { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        public int SeanceID { get; set; }
        [Required]
        public virtual Reservation Reservation {get;set;}
        public virtual Personal Personal { get; set; }
        private static ApplicationContext db = Context.Db;


        public static Ticket FindTicket(Seance seance, int row, int seat) 
        {
            return db.Ticket.FirstOrDefault(t => t.Seance == seance && t.Row.RowNumber == row && t.Seat.SeatNumber == seat);
        }
        public static void Add(Ticket ticket )
        {
            db.Ticket.Add(ticket);
            db.SaveChanges();
        }

    }
}
