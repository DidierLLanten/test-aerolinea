using AutoMapper;
using Azure.Messaging.ServiceBus;
using BLL.Services.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApiAerolinea.DTOs;

namespace WebApiAerolinea.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        private readonly ILogger<ReservationsController> _logger;
        private readonly string? _serviceBusConnectionString;

        public ReservationsController(IReservationService reservationService, IMapper mapper, ILogger<ReservationsController> logger, IConfiguration configuration)
        {
            _reservationService = reservationService;
            _mapper = mapper;
            _logger = logger;
            _serviceBusConnectionString = configuration.GetSection("AzureServiceBus")["ConnectionString"];
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
            await using var client = new ServiceBusClient(_serviceBusConnectionString);
            var sender = client.CreateSender("cola-stack");

            try
            {
                var reservation = _mapper.Map<Reservation>(createReservationDto);
                var createdReservation = await _reservationService.CreateAsync(reservation);
                //var message = new ServiceBusMessage(JsonSerializer.Serialize( createdReservation));
                //Console.WriteLine(JsonSerializer.Serialize(createdReservation));

                await _reservationService.ReserveSeatAsync(createReservationDto.SeatsId, createdReservation.FlightId, createdReservation.Id);

                //await sender.SendMessageAsync(message);                
                _logger.LogInformation("Mensaje enviado a la cola.");


                var reservationDto = _mapper.Map<ReservationDto>(createdReservation);

                return CreatedAtAction(nameof(GetReservationById), new { id = createdReservation.Id }, new { message = "Reservation created successfully", reservation = reservationDto });
            }
            catch (InvalidOperationException ex)
            {

                _logger.LogError("Testing log.");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.InnerException?.Message ?? ex.Message });
            }
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
