using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineInfo
{
    
    public class Airport: ICloneable
    {
        public static void Run()
        {
            Airport airport = new Airport("A1", "Kh", "");
            foreach (Airport a in airport)
            {
                a.DisplayInfo();
            }
        }

        private void DisplayInfo()
        {
            Console.WriteLine($"{Name}\t{City}\t{Country}");
        }

        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Airport(string name, string city, string country)
        {
            Name = name;
            City = city;
            Country = country;
        }

        public IEnumerator GetEnumerator()
        {
            yield return this;
            yield return this;
            yield return this;
            yield return this;
            yield return this;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
