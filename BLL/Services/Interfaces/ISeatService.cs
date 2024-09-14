using DAL.Entities;

namespace BLL.Services.Interfaces
{
    public interface ISeatService : IGenericService<Seat>
    {
        Task<Seat?> GetByFlightIdAndSeatNumberAsync(string seatNumber, int FlightId);
        Task<IEnumerable<Seat>> GetAvailablesAsync(bool available);
        Task<IEnumerable<Seat>> GetByFlightIdAsync(int flightId);
        Task<IEnumerable<Seat>> GetByFlightIdAndAvailableAsync(int flightId, bool available);
        Task<IEnumerable<Seat>> CreateSeatsAsync(int flightId, int numberOfSeats);
        Task ReserveSeatAsync(List<int> seatsIds, int flightId, int reservationId);
    }
}
