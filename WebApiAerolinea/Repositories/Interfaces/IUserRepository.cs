using WebApiAerolinea.Entities;

namespace WebApiAerolinea.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        // Métodos adicionales específicos para User (si es necesario)
        Task<User?> GetByEmailAsync(string email);
    }
}
