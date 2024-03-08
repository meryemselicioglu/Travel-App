using System;
using System.Globalization;

namespace Travel.App
{
    public class Trip
    {
        // Fields
        public Destination destination { get; set; }
        public Time time { get; set; }
        public Ratings ratings { get; set; }
        public double totalCost { get; set; }


        // Constructor
        public Trip() { }
        public Trip(Destination destination, Time time, Ratings ratings, double totalCost)
        {
            this.destination = destination;
            this.time = time;
            this.ratings = ratings;
            this.totalCost = totalCost;
        }

        // Method

        public static Trip CreateTrip()
        {
            try
            {
                Console.WriteLine("Let's create a new trip!\n");

                Console.Write("Which 'city, country' did you visit? ");
                string[] input = Console.ReadLine().Split(',');

                if (input.Length != 2)
                {
                    throw new ArgumentException("Invalid input format. Please enter city and country separated by a comma.");
                    CreateTrip();
                }

                string city = input[0].Trim();
                string country = input[1].Trim();
                Destination destination = new Destination(city, country);

                Console.Write("When did you travel there (mm/dd/yyyy)? ");
                string dateString = Console.ReadLine();
                DateTime travelDate;
                if (!DateTime.TryParseExact(dateString, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out travelDate))
                {
                    Console.WriteLine("Invalid date format. Please enter the date in mm/dd/yyyy format: ");
                    return null;
                }

                Console.Write("How many days did your trip last? ");
                int duration = Int32.Parse(Console.ReadLine());

                Time time = new Time(travelDate, duration);

                Console.Write("How much did you spend there in total? ");
                double totalCost = double.Parse(Console.ReadLine());

                Console.WriteLine("Please rate your trip (1-10) according to the categories below.");
                Console.Write("Food rating: ");
                int foodRating = int.Parse(Console.ReadLine());

                Console.Write("Transportation rating: ");
                int transportationRating = int.Parse(Console.ReadLine());

                Console.Write("Accommodation rating: ");
                int accommodationRating = int.Parse(Console.ReadLine());

                Console.Write("Sightseeing rating: ");
                int sightseeingRating = int.Parse(Console.ReadLine());

                Ratings ratings =new Ratings(foodRating, transportationRating, accommodationRating, sightseeingRating);

                // Create the trip using the provided information
                Trip trip = new Trip(destination, time, ratings, totalCost);

                Console.WriteLine($"\nAverage Rating: {trip.CalculateAvgRating():F1}");
                Console.WriteLine($"Cost Per Day: ${trip.CalculateCostPerDay():F2}");

                Console.WriteLine("\nGreat! Your trip has been successfully recorded. Thanks for sharing your experience with us!\n");
                return trip;

            }

            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return null;
            }

        }

        public double CalculateCostPerDay()
        {
            return totalCost / time.duration;
            Console.WriteLine($"Cost Per Day:$ {CalculateCostPerDay():F2}");
        }

        public double CalculateAvgRating()
        {
            return (ratings.food + ratings.transportation + ratings.accommodation + ratings.sightseeing) / 4.0;
            Console.WriteLine($"Average Rating: {CalculateAvgRating():F1}");
        }


        public void DisplaySummary()
        {
            Console.WriteLine();
            destination.Display();
            time.Display();
            Console.WriteLine($"Total Cost: {totalCost}");
            ratings.Display();
            Console.WriteLine($"Average Rating: {CalculateAvgRating():F1}");
            Console.WriteLine($"Cost Per Day: ${CalculateCostPerDay():F2}");

        }

        public void SortedShortDisplay()
        {
            Console.WriteLine();
            destination.Display();
            time.Display();
            Console.WriteLine($"Average Rating: {CalculateAvgRating():F1}" + " ");
            Console.WriteLine($"Cost Per Day: ${CalculateCostPerDay():F2}");
        }
    }
}