namespace WebApiAerolinea.DTOs
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public int UserId { get; set; }
        public int FlightId { get; set; }
        public int NumberOfPassengers { get; set; }
        public List<SeatDto>? Seats { get; set; }
    }
}
