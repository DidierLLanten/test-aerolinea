namespace WebApiAerolinea.DTOs
{
    public class ReserveSeatDto
    {
        public required int ReservationId { get; set; }
        public bool IsAvailable { get; }
    }
}
