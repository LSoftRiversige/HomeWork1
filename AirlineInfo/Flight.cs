using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineInfo
{
    public class Flight : IComparable<Flight>, ICloneable
    {
        public FlightPoint Departure { get; set; }
        public FlightPoint Arrival { get; set; }
        public string Number { get; set; }
        public FlightStatus Status { get; set; }
        public double Price { get; set; }
        public List<Passenger> Passengers { get; set; }
        public Flight(string number, FlightStatus status, double price, string fromAirportName, string fromAirportCity, string fromAirportCountry,
            string toAirportName, string toAirportCity, string toAirportCountry, DateTime flightDate)
        {
            Passengers = new List<Passenger>();
            Departure = new FlightPoint(fromAirportName, fromAirportCity, fromAirportCountry, flightDate);
            Arrival = new FlightPoint(toAirportName, toAirportCity, toAirportCountry, flightDate);
            Number = number;
            Status = status;
            Price = price;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Date: {Departure.Date}\tFlight #{Number}\tPrice ${string.Format("{0,12:0,000.00}", Price)}\t{Status}");
        }

        public int CompareTo(Flight other)
        {
            if (Price < other.Price) { return -1; }
            else if (Price > other.Price) { return 1; }
            else return 0;
        }

        public object Clone()
        {
            Flight other = (Flight)this.MemberwiseClone();

            other.Passengers = new List<Passenger>();

            foreach (var passenger in Passengers)
            {
                other.Passengers.Add((Passenger)passenger.Clone());
            }

            other.Departure = (FlightPoint)Departure.Clone();
            other.Arrival = (FlightPoint)Arrival.Clone();
            return other;
        }
    }

    public enum FlightStatus
    {
        CheckIn, GateClosed, Arrived, DepartedAt, Unknown, Canceled, ExpectedAt, Delayed, InFlight
    }
}
