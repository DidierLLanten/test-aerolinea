using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services
{
    public class ReservationService : GenericService<Reservation>, IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationService(IReservationRepository repository) : base(repository)
        {
            _reservationRepository = repository;
        }

        public async Task<IEnumerable<Reservation>> GetByUserIdAsync(int userId)
        {
            return await _reservationRepository.GetByUserIdAsync(userId);
        }

        public async Task<IEnumerable<Reservation>> GetByFlightIdAsync(int flightId)
        {
            return await _reservationRepository.GetByFlightIdAsync(flightId);
        }
    }
}
