using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services
{
    public class FlightService : GenericService<Flight>, IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly ISeatService _seatService;
        public FlightService(IFlightRepository repository, ISeatService seatService) : base(repository)
        {
            _flightRepository = repository;
            _seatService = seatService;
        }
        public async Task<Flight?> GetByFlightNumberAsync(string flightNumber)
        {
            return await _flightRepository.GetByFlightNumberAsync(flightNumber);
        }
        public async Task<IEnumerable<Flight>> GetByFlightAirlineAsync(string airLine)
        {
            return await _flightRepository.GetByFlightAirlineAsync(airLine);
        }
        public async Task<Flight> CreateFlightWithSeatsAsync(Flight flight)
        {
            var createdFlight = await CreateAsync(flight);
            IEnumerable<Seat> seats = await _seatService.CreateSeatsAsync(createdFlight.Id, createdFlight.TotalSeats);

            return createdFlight;
        }


    }
}
