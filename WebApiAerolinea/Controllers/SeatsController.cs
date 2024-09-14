using AutoMapper;
using BLL.Services.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApiAerolinea.DTOs;

namespace WebApiAerolinea.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatService _seatService;
        private readonly IMapper _mapper;

        public SeatsController(ISeatService seatService, IMapper mapper)
        {
            _seatService = seatService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seat>>> GetAllSeats()
        {
            var seats = await _seatService.GetAllAsync();
            return Ok(seats);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Seat>> GetSeatById(int id)
        {
            var seat = await _seatService.GetByIdAsync(id);
            if (seat == null)
            {
                return NotFound();
            }
            return Ok(seat);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeat([FromBody] CreateSeatDto createSeatDto)
        {            
            var seat = _mapper.Map<Seat>(createSeatDto);
            var createdSeat = await _seatService.CreateAsync(seat);         
            return CreatedAtAction(nameof(GetSeatById), new { id = createdSeat.Id }, new { message = "Seat created successfully", seat = createdSeat });

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeat(int id, [FromBody] UpdateSeatDto updateSeatDto)
        {
            var seat = await _seatService.GetByIdAsync(id);
            if (seat == null)
            {
                return NotFound();
            }

            var seatActualizado = _mapper.Map(updateSeatDto, seat);
            await _seatService.UpdateAsync(seatActualizado);
            return Ok(new { message = $"Seat {id} updated successfully" });
        }

        [HttpPut("reserve/{id}")]
        public async Task<IActionResult> MakeReservation(int id, [FromBody] ReserveSeatDto reserveSeatDto)
        {
            var seat = await _seatService.GetByIdAsync(id);
            if (seat == null)
            {
                return NotFound();
            }
            var seatActualizado = _mapper.Map(reserveSeatDto, seat);
            await _seatService.UpdateAsync(seatActualizado);
            return Ok(new { message = $"Seat {id} reserved successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeat(int id)
        {
            await _seatService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("flight-seat-number")]
        public async Task<ActionResult<Seat>> GetByFlightIdAndSeatNumber(int FlightId, string seatNumber)
        {
            var seat = await _seatService.GetByFlightIdAndSeatNumberAsync(seatNumber, FlightId);
            if (seat == null)
            {
                return NotFound();
            }
            return Ok(seat);
        }

        [HttpGet("by-flight-id/{id}")]
        public async Task<ActionResult<IEnumerable<Seat>>> GetSeatByEmailFragment(int id)
        {
            var seats = await _seatService.GetByFlightIdAsync(id);
            if (seats == null)
            {
                return NotFound();
            }
            return Ok(seats);
        }

        [HttpGet("by-available")]
        public async Task<ActionResult<IEnumerable<Seat>>> GetSeatsAvailables(bool available)
        {
            var seats = await _seatService.GetAvailablesAsync(available);
            if (seats == null)
            {
                return NotFound();
            }
            return Ok(seats);
        }

        [HttpGet("flight")]
        public async Task<ActionResult<IEnumerable<Seat>>> GetSeatsByFlightAndAvailables(int flightId, bool available)
        {
            var seats = await _seatService.GetByFlightIdAndAvailableAsync(flightId, available);
            if (seats == null)
            {
                return NotFound();
            }
            return Ok(seats);
        }

    }
}
