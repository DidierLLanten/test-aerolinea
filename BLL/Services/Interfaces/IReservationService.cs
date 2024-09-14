using DAL.Entities;

namespace BLL.Services.Interfaces
{
    public interface IReservationService : IGenericService<Reservation>
    {
        Task<IEnumerable<Reservation>> GetByUserIdAsync(int userId);
        Task<IEnumerable<Reservation>> GetByFlightIdAsync(int flightId);
    }
}
