using Microsoft.AspNetCore.Mvc;
using WebApiAerolinea.DTOs;
using AutoMapper;
using DAL.Entities;
using BLL.Services.Interfaces;

namespace WebApiAerolinea.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
            var createdUser = await _userService.CreateAsync(user);            
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, new { message = "User created successfully", user = createdUser });

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userActualizado = _mapper.Map(updateUserDto, user);
            await _userService.UpdateAsync(userActualizado);
            return Ok(new { message = $"User {id} updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("by-email")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserByEmailFragment([FromQuery] string email)
        {
            var users = await _userService.GetByEmailFragmentAsync(email);
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

    }
}
