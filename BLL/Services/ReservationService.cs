using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services
{
    public class ReservationService : GenericService<Reservation>, IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ISeatService _seatService;
        public ReservationService(IReservationRepository repository, ISeatService seatService) : base(repository)
        {
            _reservationRepository = repository;
            _seatService = seatService;
        }

        public async Task<IEnumerable<Reservation>> GetByUserIdAsync(int userId)
        {
            return await _reservationRepository.GetByUserIdAsync(userId);
        }

        public async Task<IEnumerable<Reservation>> GetByFlightIdAsync(int flightId)
        {
            return await _reservationRepository.GetByFlightIdAsync(flightId);
        }

        public async Task ReserveSeatAsync(List<int> seatsIds, int flightId, int reservationId)
        {
            await _seatService.ReserveSeatAsync(seatsIds, flightId, reservationId);
        }
    }
}
