namespace DAL.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; } = DateTime.Now;
        public int NumberOfPassengers { get; set; }

        // Relaciones
        public int UserId { get; set; }
        public required User User { get; set; }

        public int FlightId { get; set; }
        public required Flight Flight { get; set; }

        public required List<Seat> Seats { get; set; }
    }
}
