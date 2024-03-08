namespace Travel.App
{
    public class Ratings : TripItem
    {
        // Attributes
        private int _food;
        private int _transportation;
        private int _accommodation;
        private int _sightseeing;

        // Constructor
        public Ratings(){}

        public Ratings(int food, int transportation, int accommodation, int sightseeing)
        {
            _food = food;
            _transportation = transportation;
            _accommodation = accommodation;
            _sightseeing = sightseeing;
        }
        

        // Properties
        public int food
        {
            get { return _food; }
            set { _food = ValidateRating(value, "Food"); }
        }

        public int transportation
        {
            get { return _transportation; }
            set { _transportation = ValidateRating(value, "Transportation"); }
        }

        public int accommodation
        {
            get { return _accommodation; }
            set { _accommodation = ValidateRating(value, "Accommodation"); }
        }

        public int sightseeing
        {
            get { return _sightseeing; }
            set { _sightseeing = ValidateRating(value, "Sightseeing"); }
        }


        // Methods
        private int ValidateRating(int value, string attributeName)
        {
            // Check for valid input range (1-10)
            if (value < 1 || value > 10)
            {
                Console.WriteLine($"{attributeName} rating must be between 1 and 10. Please enter a valid rating.");
                return 0; // Default value if input is invalid
            }
            return value;
        }

        public override void Display()
        {
            Console.WriteLine($"Ratings:\nFood: {_food}\t\tTransportation: {_transportation}\tAccommodation: {_accommodation}\tSightseeing: {_sightseeing}");
        }
    }
}
