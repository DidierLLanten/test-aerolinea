using System.ComponentModel.DataAnnotations;

namespace WebApiAerolinea.DTOs
{
    public class UpdateFlightDto
    {
        public string? Airline { get; set; }
        [StringLength(6, MinimumLength = 6, ErrorMessage = "El número de vuelo debe tener exactamente 6 caracteres.")]
        public string? FlightNumber { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }        
        [Range(20000, 5000000)]
        public double Price { get; set; }
    }
}
