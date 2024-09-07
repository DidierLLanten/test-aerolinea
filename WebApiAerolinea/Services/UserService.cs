using WebApiAerolinea.Entities;
using WebApiAerolinea.Repositories.Interfaces;
using WebApiAerolinea.Services.Interfaces;

namespace WebApiAerolinea.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }
    }

}
