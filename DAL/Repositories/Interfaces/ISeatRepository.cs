using DAL.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface ISeatRepository : IRepository<Seat>
    {
        Task<Seat?> GetByFlightIdAndSeatNumberAsync(string seatNumber, int FlightId);
        Task<IEnumerable<Seat>> GetAvailablesAsync(bool available);
        Task<IEnumerable<Seat>> GetByFlightIdAsync(int flightId);
        Task<IEnumerable<Seat>> GetByFlightIdAndAvailableAsync(int flightId, bool available);
        Task AddManyAsync(List<Seat> seats);
        Task<IEnumerable<Seat>> GetByReservationIdAsync(int reservationId);
        Task SaveChangesAsync();
    }
}
