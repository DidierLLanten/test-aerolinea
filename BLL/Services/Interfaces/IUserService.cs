using DAL.Entities;


namespace BLL.Services.Interfaces
{
    public interface IUserService : IGenericService<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }

}
