using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SeatRepository : Repository<Seat>, ISeatRepository
    {
        public SeatRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Seat?> GetByFlightIdAndSeatNumberAsync(string seatNumber, int FlightId)
        {
            return await _context.Set<Seat>().FirstOrDefaultAsync(s => s.SeatNumber == seatNumber && s.FlightId == FlightId);
        }

        public async Task<IEnumerable<Seat>> GetAvailablesAsync(bool available)
        {
            return await _context.Set<Seat>().Where(s => s.IsAvailable == available).ToListAsync();
        }

        public async Task<IEnumerable<Seat>> GetByFlightIdAsync(int flightId)
        {
            return await _context.Set<Seat>().Where(s => s.FlightId == flightId).ToListAsync();
        }

        public async Task<IEnumerable<Seat>> GetByFlightIdAndAvailableAsync(int flightId, bool available)
        {
            return await _context.Set<Seat>().Where(s => s.FlightId == flightId && s.IsAvailable == available).ToListAsync();
        }
    }
}
