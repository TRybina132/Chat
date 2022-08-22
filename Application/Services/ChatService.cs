using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;


namespace Application.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository repository;
        private readonly IUserChatRepository userChatRepository;

        public ChatService(
            IChatRepository repository,
            IUserChatRepository userChatRepository)
        {
            this.repository = repository;
            this.userChatRepository = userChatRepository;
        }

        public async Task<IList<Chat>> GetAllChatsAsync() =>
            await repository.GetAsync(
                asNoTracking: true,
                include: query =>
                    query.Include(chat => chat.UserChats)
                        .ThenInclude(uc => uc.User));

        public async Task<Chat> GetChatById(int id)
        {
            Chat? chat = await repository.GetById(id,
                include: query =>
                    query.Include(chat => chat.UserChats)
                        .ThenInclude(uc => uc.User));
            return chat ?? throw new Exception($"Chat with id:{id} not found");
        }

        public async Task AddChatAsync(Chat chat)
        {
            await repository.InsertAsync(chat);
            await repository.SaveChangesAsync();
        }

        public async Task AddUserToChatAsync(UserChat userChat)
        {
            var isExists = await userChatRepository.IsAlreadyExists(userChat);
            if (!isExists)
            {
                await userChatRepository.InsertAsync(userChat);
                await userChatRepository.SaveChangesAsync();
            }
        }

        public async Task RemoveUserFromChat(UserChat userChat)
        {
            if (await userChatRepository.IsAlreadyExists(userChat))
            {
                userChatRepository.Delete(userChat);
                await userChatRepository.SaveChangesAsync();
            }
        }

        public async Task<IList<Chat>> GetChatsForUser(int userId)
        {
            var result = await userChatRepository.GetUserChats(userId);
            if (result == null)
                throw new Exception($"There no chats for user: {userId}");
            return result;
        }
    }
}
