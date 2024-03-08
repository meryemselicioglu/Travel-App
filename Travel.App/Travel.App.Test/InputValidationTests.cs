using Xunit;
using Travel.App;

namespace Travel.App.Test
{
    public class InputValidationTests
    {
        // Test for Valid Destination Input
        [Fact]
        public void CreateDestination_ValidInput_DoesNotThrowException()
        {
            // Arrange
            string city = "New York";
            string country = "USA";

            // Act & Assert
            Assert.NotNull(new Destination(city, country));
        }

        // Test for Invalid Destination Input
        [Fact]
        public void CreateDestination_InvalidInput_ThrowsException()
        {
            // Arrange
            string city = "New York";
            string country = "";

            // Act & Assert
            Assert.Throws<System.ArgumentException>(() => new Destination(city, country));
        }
        
        [Fact]
        public void CreateTime_ValidDateInput_DoesNotThrowException()
        {
            // Arrange
            DateTime validDate = new DateTime(2022, 1, 15);
            int duration = 5;

            // Act & Assert
            Assert.NotNull(new Time(validDate, duration));
        }

        // Test for Valid Ratings Input
        [Fact]
        public void CreateRatings_ValidInput_DoesNotThrowException()
        {
            // Arrange
            int validFoodRating = 8;
            int validTransportationRating = 7;
            int validAccommodationRating = 9;
            int validSightseeingRating = 6;

            // Act & Assert
            Assert.NotNull(new Ratings(validFoodRating, validTransportationRating, validAccommodationRating, validSightseeingRating));
        }
    }
}
