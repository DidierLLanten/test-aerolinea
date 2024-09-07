using BLL.Services.Interfaces;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using WebApiAerolinea.Repositories.Interfaces;

namespace BLL.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetByEmailFragmentAsync(string emailFragment)
        {
            return await _userRepository.GetByEmailFragmentAsync(emailFragment);
        }
    }

}
