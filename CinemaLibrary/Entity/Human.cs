using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaLibrary.Entity
{
    public class Human
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }//отчество

        public string PhoneNumber { get; set; }
        public Human() { }

        public Human(string Lastname, string FirstName, string PhoneNumber)
        {
            this.LastName = Lastname;
            this.FirstName = FirstName;
            this.PhoneNumber = PhoneNumber;
        }
        public Human(string Lastname, string FirstName, string PhoneNumber,string MiddleName)
        {
            this.LastName = Lastname;
            this.FirstName = FirstName;
            this.PhoneNumber = PhoneNumber;
            this.MiddleName = MiddleName;
        }
        public virtual string GetFIO()
        {
            string str = $"{LastName} {FirstName.Substring(0, 1)}.";
            if (MiddleName != "") str += $"{MiddleName.Substring(0, 1)}.";
            return str;
        }
        public virtual string GetFullName()
        {
            string str = $"{LastName} {FirstName}";
            if (MiddleName != "") str += $" {MiddleName}";
            return str;
        }
    }
}

    
