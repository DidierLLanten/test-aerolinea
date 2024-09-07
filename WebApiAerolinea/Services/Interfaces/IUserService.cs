using WebApiAerolinea.Entities;

namespace WebApiAerolinea.Services.Interfaces
{
    public interface IUserService : IGenericService<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }

}
