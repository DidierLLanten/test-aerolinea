using DAL.Entities;

namespace BLL.Services.Interfaces
{
    public interface IFlightService : IGenericService<Flight>
    {
        Task<Flight?> GetByFlightNumberAsync(string flightNumber);
        Task<IEnumerable<Flight>> GetByFlightAirlineAsync(string airLine);
        Task<Flight> CreateFlightWithSeatsAsync(Flight flight);
    }
}
