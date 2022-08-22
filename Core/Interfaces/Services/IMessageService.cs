using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IMessageService
    {
        Task<IList<Message>> GetMessagesForChat(int chatId, int skip, int take);
        Task AddMessage(Message message);
    }
}
