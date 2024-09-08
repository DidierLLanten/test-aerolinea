using DAL.Entities;
using WebApiAerolinea.Repositories.Interfaces;

namespace DAL.Repositories.Interfaces
{
    public interface IFlightRepository : IRepository<Flight>
    {
        Task<Flight?> GetByFlightNumberAsync(string flightNumber);
        Task<IEnumerable<Flight>> GetByFlightAirlineAsync(string airLine);
    }
}
