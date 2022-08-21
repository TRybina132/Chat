using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IChatService
    {
        Task<IList<Chat>> GetAllChatsAsync();
        Task<Chat> GetChatById(int id);
        Task AddChatAsync(Chat chat);
        Task AddUserToChatAsync(UserChat userChat);
        Task RemoveUserFromChat(UserChat userChat);
    }
}
