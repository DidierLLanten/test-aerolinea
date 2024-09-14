using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Reservation>> GetByUserIdAsync(int userId)
        {
            return await _context.Set<Reservation>().Where(r => r.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetByFlightIdAsync(int flightId)
        {
            return await _context.Set<Reservation>().Where(r => r.FlightId == flightId).ToListAsync();
        }
    }
}