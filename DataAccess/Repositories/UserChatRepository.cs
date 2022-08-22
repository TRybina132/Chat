using Core.Entities;
using Core.Interfaces.Repositories;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class UserChatRepository : Repository<UserChat>, IUserChatRepository
    {
        public UserChatRepository(ChatContext context) : base(context)
        {

        }

        public async Task<IList<Chat?>> GetUserChats(int userId)
        {
            IQueryable<Chat?> chats = dbSet.Where(uc => uc.UserId == userId)
                .Select(uc => uc.Chat);

            var usersChats = await chats.ToListAsync();
            return usersChats;
        }

        public Task<bool> IsAlreadyExists(UserChat entity) =>
            dbSet.AnyAsync(uc => uc.UserId == entity.UserId && uc.ChatId == entity.ChatId);
    }
}
