using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services
{
    public class SeatService : GenericService<Seat>, ISeatService
    {
        private readonly ISeatRepository _repository;

        public SeatService(ISeatRepository seatRepository) : base(seatRepository)
        {
            _repository = seatRepository;
        }

        public async Task<IEnumerable<Seat>> GetByFlightIdAsync(int flightId)
        {
            return await _repository.GetByFlightIdAsync(flightId);
        }

        public async Task<IEnumerable<Seat>> GetAvailablesAsync(bool available)
        {
            return await _repository.GetAvailablesAsync(available);
        }

        public async Task<Seat?> GetByFlightIdAndSeatNumberAsync(string seatNumber, int FlightId)
        {
            return await _repository.GetByFlightIdAndSeatNumberAsync(seatNumber, FlightId);
        }

        public async Task<IEnumerable<Seat>> GetByFlightIdAndAvailableAsync(int flightId, bool available)
        {
            return await _repository.GetByFlightIdAndAvailableAsync(flightId, available);
        }
    }
}
