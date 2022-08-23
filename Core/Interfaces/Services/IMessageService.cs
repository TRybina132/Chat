using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IMessageService
    {
        Task<IList<Message>> GetMessagesForChat(int chatId, int skip, int take);
        Task<Message> GetMessageById(int messageId);
        Task<Message> DeleteMessage(int messageId);
        Task<Message> AddMessage(Message message);
        Task<Message> UpdateMessage(Message updatedMessage);
    }
}
