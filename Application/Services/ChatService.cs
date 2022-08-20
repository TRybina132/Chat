using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;


namespace Application.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository repository;

        public ChatService(IChatRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IList<Chat>> GetAllChatsAsync() =>
            await repository.GetAsync(
                asNoTracking: true,
                include: query => 
                    query.Include(chat => chat.UserChats)
                        .ThenInclude(uc => uc.User)
                    .Include(chat => chat.Messages));

        public async Task<Chat> GetChatById(int id)
        {
            Chat? chat = await repository.GetById(id);
            return chat ?? throw new Exception($"Chat with id:{id} not found");
        }

        public async Task AddChatAsync(Chat chat)
        {
            await repository.InsertAsync(chat);
            await repository.SaveChangesAsync();
        }
    }
}
