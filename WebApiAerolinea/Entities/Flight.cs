namespace WebApiAerolinea.Entities
{
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
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
    }
}
