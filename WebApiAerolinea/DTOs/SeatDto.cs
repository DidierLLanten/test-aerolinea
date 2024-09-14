namespace WebApiAerolinea.DTOs
{
    public class SeatDto
    {
        public int Id { get; set; }
        public string SeatNumber { get; set; }
        public bool IsAvailable { get; set; }
        public int FlightId { get; set; }
    }
}
