using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace DAL.Entities
{
    [Index(nameof(SeatNumber), nameof(FlightId), IsUnique = true)]
    public class Seat
    {
        public int Id { get; set; }
        public required string SeatNumber { get; set; } // Ej: "12A", "15B"        
        public bool IsAvailable { get; set; } = true;

        // Relaciones
        public int FlightId { get; set; }
        public required Flight Flight { get; set; }

        public int? ReservationId { get; set; }
        public Reservation? Reservation { get; set; }
    }
}
