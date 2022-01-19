using System;
using CinemaLibrary;
using CinemaLibrary.Entity;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ApplicationContext()) 
            { 
                db.SaveChanges();
            }
             
        }
    }
}
