using DAL.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetByEmailFragmentAsync(string emailFragment);
    }
}
