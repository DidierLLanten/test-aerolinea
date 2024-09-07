using DAL.Entities;
using WebApiAerolinea.Repositories.Interfaces;

namespace DAL.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetByEmailFragmentAsync(string emailFragment);
    }
}
