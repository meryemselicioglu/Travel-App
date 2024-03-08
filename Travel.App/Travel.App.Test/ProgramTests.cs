using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Xunit;

namespace Travel.App.Test
{
    public class ProgramTests
    {
        [Fact]
        public void SortTripsByDateTest()
        {
            // Arrange
            List<Trip> trips = new List<Trip>
            {
                new Trip(new Destination("City1", "Country1"), new Time(new DateTime(2021, 12, 10), 5), new Ratings(7, 8, 9, 7), 500),
                new Trip(new Destination("City2", "Country2"), new Time(new DateTime(2022, 1, 15), 3), new Ratings(6, 7, 8, 6), 300),
                new Trip(new Destination("City3", "Country3"), new Time(new DateTime(2022, 2, 20), 7), new Ratings(8, 9, 9, 8), 700)
            };

            // Act
            Program.SortTripsByDate(trips);

            // Assert
            Assert.Equal(new DateTime(2021, 12, 10), trips[0].time.date);
            Assert.Equal(new DateTime(2022, 1, 15), trips[1].time.date);
            Assert.Equal(new DateTime(2022, 2, 20), trips[2].time.date);
        }

        [Fact]
        public void SortTripsByRateTest()
        {
            // Arrange
            List<Trip> trips = new List<Trip>
            {
                new Trip(new Destination("City1", "Country1"), new Time(DateTime.Now, 5), new Ratings(7, 8, 9, 7), 500),
                new Trip(new Destination("City2", "Country2"), new Time(DateTime.Now, 3), new Ratings(6, 7, 8, 6), 300),
                new Trip(new Destination("City3", "Country3"), new Time(DateTime.Now, 7), new Ratings(8, 9, 9, 8), 700)
            };

            // Act
            Program.SortTripsByRate(trips);

            // Assert
            Assert.Equal(7.75, trips[0].CalculateAvgRating());
            Assert.Equal(6.75, trips[1].CalculateAvgRating());
            Assert.Equal(8.5, trips[2].CalculateAvgRating());
        }

        [Fact]
        public void SortTripsByCostTest()
        {
            // Arrange
            List<Trip> trips = new List<Trip>
            {
                new Trip(new Destination("City1", "Country1"), new Time(DateTime.Now, 4), new Ratings(7, 8, 9, 7), 500),
                new Trip(new Destination("City2", "Country2"), new Time(DateTime.Now, 6), new Ratings(6, 7, 8, 6), 300),
                new Trip(new Destination("City3", "Country3"), new Time(DateTime.Now, 10), new Ratings(8, 9, 9, 8), 700)
            };

            // Act
            Program.SortTripsByCostPerDay(trips);

            // Assert
            Assert.Equal(125, trips[0].CalculateCostPerDay());
            Assert.Equal(50, trips[1].CalculateCostPerDay());
            Assert.Equal(70, trips[2].CalculateCostPerDay());
        }

        [Fact]
        public void SerializeDeserializeTrip()
        {
            // Arrange
            Trip originalTrip = new Trip(new Destination("City", "Country"), new Time(new DateTime(2022, 2, 20), 7), new Ratings(8, 9, 9, 8), 700);

            // Create a StringWriter to capture the XML output
            StringWriter stringWriter = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(typeof(Trip));

            // Act: Serialize the Trip object to XML
            serializer.Serialize(stringWriter, originalTrip);
            string xml = stringWriter.ToString();

            // Write the XML to a temporary file
            string filePath = Path.GetTempFileName();
            File.WriteAllText(filePath, xml);

            // Read the XML from the file and deserialize it back to a Trip object
            Trip deserializedTrip;
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                deserializedTrip = (Trip)serializer.Deserialize(streamReader);
            }

            // Assert: Verify that the deserialized Trip object is equal to the original one
            Assert.Equal(originalTrip.destination.city, deserializedTrip.destination.city);
            Assert.Equal(originalTrip.destination.country, deserializedTrip.destination.country);
            Assert.Equal(originalTrip.time.date, deserializedTrip.time.date);
            Assert.Equal(originalTrip.time.duration, deserializedTrip.time.duration);
            Assert.Equal(originalTrip.ratings.food, deserializedTrip.ratings.food);
            Assert.Equal(originalTrip.ratings.transportation, deserializedTrip.ratings.transportation);
            Assert.Equal(originalTrip.ratings.accommodation, deserializedTrip.ratings.accommodation);
            Assert.Equal(originalTrip.ratings.sightseeing, deserializedTrip.ratings.sightseeing);
            Assert.Equal(originalTrip.totalCost, deserializedTrip.totalCost);

            // Clean up: Delete the temporary file
            File.Delete(filePath);
        }
    }
}
