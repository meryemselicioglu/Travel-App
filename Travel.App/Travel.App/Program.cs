using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Travel.App
{
    public class Program
    {
        static List<Trip> trips = new List<Trip>();
        static string path = @".\Trips.txt";

        public static void Main(string[] args)
        {
            string? choice;
            do
            {
                DisplayMenu();
                choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        Trip trip = Trip.CreateTrip();
                        trips.Add(trip);
                        break;
                    case "2":
                        SortAndDisplayTrips();
                        break;
                    case "3":
                        DisplayTripSummary();
                        break;
                    case "4":
                        LoadTripsFromFile(path);
                        break;
                    case "5":
                        SaveTripsToFile(path);
                        break;
                    case "6":
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != "6");

        }

        static void DisplayMenu()
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create a trip");
            Console.WriteLine("2. Sort and display my trips");
            Console.WriteLine("3. Display the summary of a specific destination");
            Console.WriteLine("4. Load the trips data");
            Console.WriteLine("5. Save the trips to the file");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
        }



        static void SortAndDisplayTrips()
        {
            if (trips.Count == 0)
            {
                Console.WriteLine("No trips available.");
                return;
            }

            Console.WriteLine("Sort and display trips:");
            Console.WriteLine("Do you want them sorted by 1.date, 2.avg rate or 3.cost?");
            int sortBy = int.Parse(Console.ReadLine());

            switch (sortBy)
            {
                case 1:
                    SortTripsByDate(trips);
                    break;
                case 2:
                    SortTripsByRate(trips);
                    break;
                case 3:
                    SortTripsByCostPerDay(trips);
                    break;
                default:
                    Console.WriteLine("Invalid sort option.");
                    SortAndDisplayTrips(); // Return to sorting choices
                    break;
            }

        }

        public static void SortTripsByDate(List<Trip> trips)
        {
            trips.OrderBy(t => t.time.date).ToList().ForEach(t => t.SortedShortDisplay());
        }
        public static void SortTripsByRate(List<Trip> trips)
        {
            trips.OrderBy(t => t.CalculateAvgRating()).ToList().ForEach(t => t.SortedShortDisplay());
        }

        public static void SortTripsByCostPerDay(List<Trip> trips)
        {
            trips.OrderBy(t => t.totalCost).ToList().ForEach(t => t.SortedShortDisplay());
        }

        static void DisplayTripSummary()
        {
            try
            {
                if (trips.Count == 0)
                {
                    Console.WriteLine("No trips available.");
                    return;
                }

                Console.WriteLine("Display the summary of a specific destination:");
                Console.Write("Please enter the 'city,country' to view the data: ");
                string[] destinationInput = Console.ReadLine().Split(',');
                string city = destinationInput[0];
                string country = destinationInput[1];

                Trip trip = trips.FirstOrDefault(t => t.destination.city == city && t.destination.country == country);
                if (trip != null)
                    trip.DisplaySummary();
                else
                    Console.WriteLine("Trip not found for the specified destination.");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }



        }

        static void LoadTripsFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Trip>));
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    trips = (List<Trip>)serializer.Deserialize(fileStream);
                }
                Console.WriteLine("Trips loaded from file.");
            }
            else
            {
                Console.WriteLine("File does not exist. No trips loaded.");
            }
        }

        static void SaveTripsToFile(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Trip>));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, trips);
            }
            Console.WriteLine("Trips data saved to XML file.");
        }
    }
}
