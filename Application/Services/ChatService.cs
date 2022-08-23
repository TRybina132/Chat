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
        private readonly IUserService userService;

        public ChatService(
            IChatRepository repository,
            IUserChatRepository userChatRepository,
            IUserService userService)
        {
            this.repository = repository;
            this.userChatRepository = userChatRepository;
            this.userService = userService;
        }

        public async Task<IList<Chat>> GetAllChatsAsync() =>
            await repository.GetAsync(
                asNoTracking: true,
                filter: chat => chat.Type == ChatType.Group,
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

        public async Task<Chat> AddChatAsync(Chat chat)
        {
            var createdChat = await repository.InsertAsync(chat);
            await repository.SaveChangesAsync();
            return createdChat;
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

        public async Task<Chat> GetPrivateChat(int senderId, int recipientId)
        {
            var (sender, recipient) = 
                                (await userService.GetByIdAsync(senderId),
                                 await userService.GetByIdAsync(recipientId));
            if (sender is null)
                throw new Exception($"User with id {senderId} does not exist");
            if (recipient is null)
                throw new Exception($"User with id {recipientId} does not exist");

            var chat = await repository.GetFirstOrDefaultAsync(
                include: query => 
                    query.Include(chat => chat.UserChats)
                    .ThenInclude(uc => uc.User),
                filter: chat => 
                    chat.UserChats.Select(uc => uc.UserId).Contains(senderId)
                    && chat.UserChats.Select(ur => ur.UserId).Contains(recipientId)
                    && chat.Type == ChatType.Private);

            if(chat != null)
                return chat;

            Chat privateChat = new Chat()
            {
                Name = $"{sender.UserName} - {recipient.UserName}",
                Type = ChatType.Private,
                UserChats = new[]
                {
                    new UserChat { UserId = senderId },
                    new UserChat { UserId = recipientId }
                }
            };

            var createdChat = await AddChatAsync(privateChat);
            return createdChat;
        }
    }
}
