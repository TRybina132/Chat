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
    }
}
