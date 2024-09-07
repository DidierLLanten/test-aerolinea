namespace DAL.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public required string PaymentMethod { get; set; } // Credit Card, PayPal, etc.

        // Relaciones
        public int ReservationId { get; set; }
        public required Reservation Reservation { get; set; }
    }
}
