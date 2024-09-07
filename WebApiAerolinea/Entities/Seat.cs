namespace WebApiAerolinea.Entities
{
    public class Seat
    {
        public int Id { get; set; }
        public required string SeatNumber { get; set; } // Ej: "12A", "15B"
        public bool IsAvailable { get; set; }

        // Relaciones
        public int FlightId { get; set; }
        public required Flight Flight { get; set; }

        public int? ReservationId { get; set; }
        public Reservation? Reservation { get; set; }
    }
}
