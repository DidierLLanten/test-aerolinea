using DAL.Entities;

namespace WebApiAerolinea.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetByEmailFragmentAsync(string emailFragment);
    }
}
