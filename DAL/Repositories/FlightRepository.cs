using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class FlightRepository : Repository<Flight>, IFlightRepository
    {

        public FlightRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Flight?> GetByFlightNumberAsync(string flightNumber)
        {
            return await _context.Set<Flight>().FirstOrDefaultAsync(f => f.FlightNumber == flightNumber);
        }

        public async Task<IEnumerable<Flight>> GetByFlightAirlineAsync(string airLine)
        {
            return await _context.Set<Flight>().Where(f => f.Airline == airLine).ToListAsync();
        }

    }
}
