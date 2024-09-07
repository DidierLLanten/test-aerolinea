namespace WebApiAerolinea.DTOs
{
    public class CreateSeatDto
    {
        public required string SeatNumber { get; set; }
        public required int FlightId { get; set; }
    }
}
