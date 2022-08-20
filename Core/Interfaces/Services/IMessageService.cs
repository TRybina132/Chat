using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IMessageService
    {
        Task<IList<Message>> GetMessagesForChat(int chatId);
        Task AddMessage(Message message);
    }
}
