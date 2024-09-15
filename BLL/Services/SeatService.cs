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

        public async Task<IEnumerable<Seat>> CreateSeatsAsync(int flightId, int numberOfSeats)
        {
            char fila = 'A';
            int filaNumber = 1;
            var seats = new List<Seat>();

            for (int i = 1; i <= numberOfSeats; i++)
            {

                if (i != 1 && (i % 4) == 1) { fila = 'A'; filaNumber++; }
                Seat seat = new()
                {
                    FlightId = flightId,                 
                    SeatNumber = $"{filaNumber}{fila}",
                };
                fila++;

                //await _repository.AddAsync(seat);
                seats.Add(seat);
            }

            await _repository.AddManyAsync(seats); //guardar todos los asientos al timpo en la bd                          
            return seats;
        }

        public async Task ReserveSeatAsync(List<int> seatsIds, int flightId, int reservationId)
        {
            foreach (int seatId in seatsIds)
            {
                Seat? seatFound = await _repository.GetByIdAsync(seatId);
                if (seatFound != null)
                {
                    if (seatFound.FlightId == flightId)
                    {
                        if (seatFound.IsAvailable)
                        {
                            seatFound.ReservationId = reservationId;
                            seatFound.IsAvailable = false;
                            await _repository.UpdateAsync(seatFound);
                        }
                        else
                        {
                            throw new InvalidOperationException($"Seat {seatFound.SeatNumber} unavailable to Flight ID {flightId}.");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException($"Seat with ID {seatId} does not belong to Flight ID {flightId}.");
                    }
                }
                else
                {
                    throw new InvalidOperationException($"Seat with ID {seatId} not found."); 
                }
            }
        }
    }
}
