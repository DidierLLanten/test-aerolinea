using DAL.Entities;

namespace WebApiAerolinea.DTOs
{
    public class CreateReservationDto
    {        
        public required int UserId { get; set; }
        public required int FlightId { get; set; }
        public required int NumberOfPassengers { get; set; }
        public required List<int> SeatsId { get; set; }
    }
}
