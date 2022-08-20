using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IUserChatRepository : IRepository<UserChat>
    {
        public Task<bool> IsAlreadyExists(UserChat entity);
    }
}
