using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    [Index(nameof(FlightNumber), IsUnique = true)]
    public class Flight
    {
        public int Id { get; set; }
        public required string Airline { get; set; }
        public required string FlightNumber { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public double Price { get; set; }
        [Range(10, 100)]
        public int TotalSeats { get; set; }
        [Range(0, 100)]
        public int AvailableSeats { get; set; }
    }
}
