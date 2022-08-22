using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IUserChatRepository : IRepository<UserChat>
    {
        public Task<bool> IsAlreadyExists(UserChat entity);
        public Task<IList<Chat?>> GetUserChats(int userId);
    }
}
