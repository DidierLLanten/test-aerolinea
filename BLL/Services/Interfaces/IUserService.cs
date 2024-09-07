using DAL.Entities;


namespace BLL.Services.Interfaces
{
    public interface IUserService : IGenericService<User>
    {            
        Task<IEnumerable<User>> GetByEmailFragmentAsync(string emailFragment);
    }

}
