using Microsoft.AspNetCore.Mvc;
using WebApiAerolinea.DTOs;
using AutoMapper;
using DAL.Entities;
using BLL.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace WebApiAerolinea.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, IMapper mapper, ILogger<UsersController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            _logger.LogInformation("Usuarios obtenidos");
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                _logger.LogWarning($"Usuario con id {id} no encontrado");
                return NotFound();
            }
            _logger.LogInformation($"Usuario con id {id} encontrado exitosamente");
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
            var createdUser = await _userService.CreateAsync(user);
            _logger.LogInformation("Usuario creado exitosamente");
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, new { message = "User created successfully", user = createdUser });

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                _logger.LogWarning($"Usuario con id {id} no encontrado");
                return NotFound();
            }

            var userActualizado = _mapper.Map(updateUserDto, user);
            await _userService.UpdateAsync(userActualizado);
            _logger.LogInformation($"Usuario con id {id} actualizado exitosamente");
            return Ok(new { message = $"User {id} updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteAsync(id);
            _logger.LogInformation($"Usuario con id {id} eliminado exitosamente");
            return NoContent();
        }

        [HttpGet("by-email")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserByEmailFragment([FromQuery] string email)
        {
            var users = await _userService.GetByEmailFragmentAsync(email);
            if (users.IsNullOrEmpty())
            {
                _logger.LogWarning($"Usuario con email {email} no encontrado");
                return NotFound();
            }
            _logger.LogInformation($"Usuario con email {email} encontrado exitosamente");
            return Ok(users);
        }

    }
}
