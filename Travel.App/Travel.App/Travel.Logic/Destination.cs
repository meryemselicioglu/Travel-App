using System;
using System.Globalization;
namespace Travel.App

{
    public class Destination : TripItem
    {
        // Properties
        public string _city;
        public string _country;

        // Constructor
        public Destination() { }
        public Destination(string city, string country)
        {
            this.city = city;
            this.country = country;
        }

        // Properties
        public string city
        {
            get { return _city; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("City cannot be null or empty.", nameof(value));
                _city = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
            }
        }

        public string country
        {
            get { return _country; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Country cannot be null or empty.", nameof(value));
                _country = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
            }
        }

        // Methods
        public override void Display()
        {
            Console.WriteLine($"Destination: {city}, {country}");
        }
    }

}

