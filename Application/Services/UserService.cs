using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

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
            await repository.GetAsync(
                asNoTracking: true,
                include: query => query.Include(user => user.UserChats)
                    .ThenInclude(uc => uc.Chat));

        public async Task<User> GetByIdAsync(int id) =>
            await repository.GetById(id) ?? throw new Exception($"User with id: {id} not found!");

        public async Task<User> GetByUsername(string username)
        {
            var result = await repository.GetAsync(filter: user => user.UserName == username, take: 1);
            User? user = result.FirstOrDefault();

            return user ?? throw new Exception($"User: {username} not found!");
        }
    }
}
