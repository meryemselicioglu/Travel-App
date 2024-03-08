namespace Travel.App
{

    // Fields
    public class Time : TripItem
    {
        // Fields
        private DateTime _date { get; set; }
        public int _duration { get; set; }


        // Constructor
        public Time(){}
        public Time(DateTime date, int duration)
        {
            _date = date;

            if (duration < 0)
            {
                Console.WriteLine("Duration cannot be negative. Please enter a valid duration.");
            }
            else
            {
                _duration = duration;
            }

        }

        // Properties
        public DateTime date
        {
            get { return _date; }
            set { _date = value; }
        }

        public int duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        // Method
        public override void Display()
        {
            Console.WriteLine($"Duration: {duration} days\t\t\tDate: {date.ToShortDateString()}");
        }
    }


}
