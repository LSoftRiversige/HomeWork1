using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineInfo
{
    public class FlightPoint: ICloneable
    {
        public Airport Airport { get; set; }
        public DateTime Date { get; set; }
        public string Port { get; set; }
        public string Terminal { get; set; }
        public string Gate { get; set; }
        public FlightPoint(string airportName, string airpotCity, string airportCountry, DateTime date)
        {
            Airport = new Airport(airportName, airpotCity, airportCountry);
            Date = date;
        }

        public FlightPoint()
        {
        }

        public object Clone()
        {
            FlightPoint other = (FlightPoint)this.MemberwiseClone();
            other.Airport = (Airport)Airport.Clone();
            return other;
        }
    }
}
