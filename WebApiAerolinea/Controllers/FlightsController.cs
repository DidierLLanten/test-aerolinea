using AutoMapper;
using Azure.Messaging;
using Azure.Messaging.ServiceBus;
using BLL.Services.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApiAerolinea.DTOs;

namespace WebApiAerolinea.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _flightService;
        private readonly IMapper _mapper;

        public FlightsController(IFlightService flightService, IMapper mapper)
        {
            _flightService = flightService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight>>> GetAllFlights()
        {
            var flights = await _flightService.GetAllAsync();
            return Ok(flights);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetFlightById(int id)
        {
            //try
            //{
            //    await using var client = new
            //ServiceBusClient("BorradParaPoderSubirAGitHub");
            //var sender = client.CreateSender("cola-stack");
            //var message = new ServiceBusMessage("probando la cola");
            
            //    await sender.SendMessageAsync(message);
            //    return Ok("Message sent successfully.");
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, $"Error sending message: { ex.Message}");
            //}



            var flight = await _flightService.GetByIdAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            return Ok(flight);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFlight([FromBody] CreateFlightDto createFlightDto)
        {
            var flight = _mapper.Map<Flight>(createFlightDto);
            flight.AvailableSeats = flight.TotalSeats;
            var createdFlight = await _flightService.CreateFlightWithSeatsAsync(flight);
            return CreatedAtAction(nameof(GetFlightById), new { id = createdFlight.Id }, new { message = "Flight created successfully", flight = createdFlight });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlight(int id, [FromBody] UpdateFlightDto updateFlightDto)
        {
            var flight = await _flightService.GetByIdAsync(id);
            if (flight == null)
            {
                return NotFound();
            }

            var flightActualizado = _mapper.Map(updateFlightDto, flight);
            await _flightService.UpdateAsync(flightActualizado);
            return Ok(new { message = $"Flight {id} updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            await _flightService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("by-flight-number/{flightNumber}")]
        public async Task<ActionResult<Flight>> GetByFlightNumber(string flightNumber)
        {
            var flight = await _flightService.GetByFlightNumberAsync(flightNumber);
            if (flight == null)
            {
                return NotFound();
            }
            return Ok(flight);
        }

        [HttpGet("airline/{airLine}")]
        public async Task<IEnumerable<Flight>> GetByFlightAirline(string airLine)
        {
            return await _flightService.GetByFlightAirlineAsync(airLine);
        }


    }
}
