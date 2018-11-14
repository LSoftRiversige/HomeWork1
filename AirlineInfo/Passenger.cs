using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineInfo
{
    public class Passenger: ICloneable
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Passport { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public Sex Sex { get; set; }
        public TripClass TripClass { get; set; }
        public Passenger(string firstName, string secondName, string passport, string nationality, DateTime dateOfBirthday, Sex sex, TripClass tripClass)
        {
            FirstName = firstName;
            SecondName = secondName;
            Passport = passport;
            Nationality = nationality;
            DateOfBirthday = dateOfBirthday;
            Sex = sex;
            TripClass = tripClass;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    

    public enum Sex
    { 
        Male, 
        Femail
    }

    public enum TripClass
    {
        Ecomony, 
        Business
    }
}
