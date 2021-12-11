using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaLibrary.Entity
{
    public class HallSeat
    {
        public int ID { get; set; }
        public HallRow HallRow { get; set; }
        public int SeatNumber { get; set; }
    }
}
