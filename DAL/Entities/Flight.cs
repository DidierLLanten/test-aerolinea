﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    [Index(nameof(FlightNumber), IsUnique = true)]
    public class Flight
    {
        // Constructor que inicializa AvailableSeats con TotalSeats
        public int Id { get; set; }
        public required string Airline { get; set; }
        public required string FlightNumber { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        [Range(20000, 5000000)]
        public double Price { get; set; }
        [Range(10, 100)]
        public int TotalSeats { get; set; }
        [Range(0, 100)]
        public int AvailableSeats { get; set; }
    }
}
