using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository repository;

        public MessageService(IMessageRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IList<Message>> GetMessagesForChat(int chatId)
        {
            var result =
                await repository.GetAsync(
                    filter: message => message.ChatId == chatId,
                    asNoTracking: true,
                    include: query => query.Include(m => m.Sender));

            return result;
        }

        public async Task AddMessage(Message message)
        {
            await repository.InsertAsync(message);
            await repository.SaveChangesAsync();
        }
    }
}
