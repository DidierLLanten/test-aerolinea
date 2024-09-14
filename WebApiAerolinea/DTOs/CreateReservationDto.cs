namespace WebApiAerolinea.DTOs
{
    public class CreateReservationDto
    {        
        public int NumberOfPassengers { get; set; }
        public int UserId { get; set; }
        public int FlightId { get; set; }
    }
}
