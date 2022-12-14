using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<Message> InsertMessageAsync(Message message);
    }
}
