using AutoMapper;
using BLL.Services.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApiAerolinea.DTOs;

namespace WebApiAerolinea.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;

        public ReservationsController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetAllReservations()
        {
            var reservations = await _reservationService.GetAllAsync();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservationById(int id)
        {
            var reservation = await _reservationService.GetByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationDto createReservationDto)
        {
            var reservation = _mapper.Map<Reservation>(createReservationDto);
            var createdReservation = await _reservationService.CreateAsync(reservation);
            return CreatedAtAction(nameof(GetReservationById), new { id = createdReservation.Id }, new { message = "Reservation created successfully", reservation = createdReservation });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, [FromBody] UpdateReservationDto updateReservationDto)
        {
            var reservation = await _reservationService.GetByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            var reservationActualizado = _mapper.Map(updateReservationDto, reservation);
            await _reservationService.UpdateAsync(reservationActualizado);
            return Ok(new { message = $"Reservation {id} updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            await _reservationService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("by-user-id/{userId}")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetByUserId(int userId)
        {
            var reservations = await _reservationService.GetByUserIdAsync(userId);
            return Ok(reservations);
        }

        [HttpGet("by-flight-id/{flightId}")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetByFlightId(int flightId)
        {
            var reservations = await _reservationService.GetByFlightIdAsync(flightId);
            return Ok(reservations);
        }


    }
}
