using WebApiAerolinea.Context;
using WebApiAerolinea.Entities;

namespace WebApiAerolinea.Repositories
{
    public class FlightRepository
    {
        private readonly ApplicationDbContext _context;

        public FlightRepository(ApplicationDbContext context) { _context = context; }

        public IEnumerable<Flight> GetAll()
        {
            return _context.Flights.ToList();
        }

        public Flight? GetById(int id)
        {
            return _context.Flights.FirstOrDefault(f => f.Id == id);
        }

        public async Task Post(Flight flight)
        {
            _context.Add(flight);
            await _context.SaveChangesAsync();
        }

        public async Task Put(Flight flight)
        {
            _context.Add(flight);
            await _context.SaveChangesAsync();
        }

    }
}
