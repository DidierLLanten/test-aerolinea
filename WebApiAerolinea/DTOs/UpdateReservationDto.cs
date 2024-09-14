using DAL.Entities;

namespace WebApiAerolinea.DTOs
{
    public class UpdateReservationDto
    {   
        public int NumberOfPassengers { get; set; }        
        public required List<Seat> Seats { get; set; }
    }
}
