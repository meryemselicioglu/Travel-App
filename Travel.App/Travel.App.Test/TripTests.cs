using Travel.App;

namespace Travel.App.Test
{
    public class TripTest
    {
        [Fact]
        public void TestCalculateCostPerDay()
        {
            // Arrange     
            Trip trip = new Trip
            {
                totalCost = 780.00,
                time = new Time { duration = 8 }
            };

            // Act
            double costPerDay = trip.CalculateCostPerDay();

            // Assert
            Assert.Equal(97.5, costPerDay);
        }

        [Fact]
        public void TestCalculateAvgRating()
        {
            // Arrange
            Trip trip = new Trip
            {
                ratings = new Ratings
                {
                    food = 5,
                    transportation = 6,
                    accommodation = 9,
                    sightseeing = 8
                }
            };

            // Act
            double avgRating = trip.CalculateAvgRating();

            // Assert
            Assert.Equal(7.0, avgRating);
        }

        [Fact]
        public void CreateTrip_InvalidCityInput_ReturnsNull()
        {
            // Arrange
            string invalidCityInput = "123"; // Invalid city input
            StringReader stringReader = new StringReader(invalidCityInput);
            Console.SetIn(stringReader);

            // Act
            Trip trip = Trip.CreateTrip();

            // Assert
            Assert.Null(trip); // Ensure that null is returned when invalid input is provided
        }

        [Fact]
        public void Duration_MaximumValue_ReturnsExpectedResult()
        {
            // Arrange
            int maxDuration = int.MaxValue;
            Time time = new Time(new DateTime(2022, 1, 1), maxDuration);

            // Act
            int actualDuration = time._duration;

            // Assert
            Assert.Equal(maxDuration, actualDuration);
        }
    }
}