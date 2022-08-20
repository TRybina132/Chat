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

        public Task<bool> IsAlreadyExists(UserChat entity) =>
            dbSet.AnyAsync(uc => uc.UserId == entity.UserId && uc.ChatId == entity.ChatId);
    }
}
