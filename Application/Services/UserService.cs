using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IList<User>> GetAllUsersAsync() =>
            await repository.GetAsync(asNoTracking: true);

        public async Task<User> GetByIdAsync(int id) =>
            await repository.GetById(id) ?? throw new Exception("User not found!");
    }
}
