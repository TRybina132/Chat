using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<IList<User>> GetAllUsersAsync();

        Task<User> GetByIdAsync(int id);
    }
}
