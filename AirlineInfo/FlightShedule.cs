using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineInfo
{
    public class FlightShedule: IEnumerable, ICloneable
    {
        public List<Flight> Flights { get; set; }
        public FlightShedule()
        {
            Flights = new List<Flight>();
        }

        internal void Run()
        {
            bool cicle = true;
            while (cicle)
                {
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1. Adding test flights");
                    Console.WriteLine("2. Display price");
                    Console.WriteLine("3. Exit");
                    Console.WriteLine("4. Find by flight number");
                    Console.WriteLine("5. Check yield enumerator");
                    Console.WriteLine("6. Clone the entire shedule of flights");
                    Console.WriteLine("7. Clear the shedule of flights");
                    Console.WriteLine("8. String collection");

                string userInput=Console.ReadLine();

                    switch (userInput)
                    {
                    case "1":  AddTestFlights(); break;
                    case "2":  DiplayPrice(); break;
                    case "3":  cicle = false; break;
                    case "4":  Find(); break;
                    case "5":  Airport.Run(); break;
                    case "6":  CloneShedule(); break;
                    case "7":  Flights.Clear(); break;
                    case "8":   LearnStringCollections(); break;

                    default: break;
                    }

                    if (cicle)
                    {
                        Console.WriteLine("Press any key...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                                                           
                }
            
        }

        private void LearnStringCollections()
        {
            var strs = new StringCollection();
            for (int i = 0; i < 100; i++)
            {
                strs.Add($"string number {i}");
            }
            DisplayStrings(strs);
        }

        private void DisplayStrings(StringCollection strs)
        {
            foreach (var s in strs)
            {
                Console.WriteLine(s);
            }
        }

        private void CloneShedule()
        {
            FlightShedule clone = (FlightShedule)Clone();
            clone.DiplayPrice();
        }

        private void Find()
        {
            Console.WriteLine("Please, enter the flight number then press 'Enter' key:");
            string number = Console.ReadLine();
            bool found=false;
            foreach (Flight flight in this)
            {
                if (flight.Number == number)
                {
                    found = true;
                    flight.DisplayInfo();
                    break;
                }
            }
            if (found == false)
            {
                Console.WriteLine("Not found");
            }
        }

        internal void AddTestFlights()
        {
            Flights.Add(new Flight("12KL", FlightStatus.Unknown, 800, "ArName1", "Kharkiv1", "Ukraine", "Gunsel", "Istambul", "Turkey", DateTime.Parse("11.11.2018")));
            Flights.Add(new Flight("145L", FlightStatus.Unknown, 1800, "ArName2", "Kharkiv2", "Ukraine", "Gunsel", "Istambul", "Turkey", DateTime.Parse("17.11.2018")));
            Flights.Add(new Flight("18G", FlightStatus.Unknown, 3800, "ArName3", "Kharkiv3", "Ukraine", "Gunsel", "Istambul", "Turkey", DateTime.Parse("20.11.2018")));
            Flights.Add(new Flight("894DF", FlightStatus.Unknown, 430, "ArName4", "Kharkiv4", "Ukraine", "Gunsel", "Istambul", "Turkey", DateTime.Parse("21.11.2018")));
            Flights.Add(new Flight("1343A", FlightStatus.Unknown, 12732, "ArName5", "Kharkiv5", "Ukraine", "Gunsel", "Istambul", "Turkey", DateTime.Parse("30.11.2018")));
            Console.WriteLine("Done");
        }

        public IEnumerator GetEnumerator()
        {
            return Flights.GetEnumerator();
        }

        public class CompareByNumber : IComparer<Flight>
        {
            public int Compare(Flight x, Flight y)
            {
                return string.Compare(x.Number, y.Number);
            }
        }

        public void DiplayPrice()
        {
            Console.WriteLine("Sorting by price");
            Flights.Sort();
            foreach (Flight flight in this)
            {
                flight.DisplayInfo();
            }

            Console.WriteLine("Sorting by number");
            Flights.Sort(new CompareByNumber());
            foreach (Flight flight in this)
            {
                flight.DisplayInfo();
            }
            Console.WriteLine("Done");
        }

        public object Clone()
        {
            FlightShedule other = (FlightShedule)this.MemberwiseClone();
            other.Flights = new List<Flight>();
            foreach (var flight in Flights)
            {
                other.Flights.Add((Flight)flight.Clone());
            }

            Console.WriteLine("Clear original flights");
            Flights.Clear();

            return other;
        }
    }
}
