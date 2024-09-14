using DAL.Entities;
using WebApiAerolinea.Repositories.Interfaces;

namespace DAL.Repositories.Interfaces
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        Task<IEnumerable<Reservation>> GetByUserIdAsync(int userId);
        Task<IEnumerable<Reservation>> GetByFlightIdAsync(int flightId);
    }
}
