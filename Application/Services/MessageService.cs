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

        public async Task<IList<Message>> GetMessagesForChat(int chatId, int skip, int take)
        {
            var result =
                await repository.GetAsync(
                    filter: message => message.ChatId == chatId,
                    asNoTracking: true,
                    skip: skip,
                    take: take,
                    include: query => query.Include(m => m.Sender)
                        .Include(m => m.Chat),
                    orderBy: orderQuery => orderQuery.OrderByDescending(message => message.SentAt));

            return result;
        }

        public async Task<Message> AddMessage(Message message)
        {
            var createdMessage = await repository.InsertMessageAsync(message);
            await repository.SaveChangesAsync();
            return createdMessage;
        }

        public async Task DeleteMessage(int messageId)
        {
            Message? message = await repository.GetById(messageId);
            if (message == null)
                throw new Exception($"There no message with id: {messageId}");

            repository.Delete(message);
            await repository.SaveChangesAsync();
        }

        public async Task UpdateMessage(Message updatedMessage)
        {
            var message = await repository.GetById(updatedMessage.Id);
            if (message == null)
                throw new Exception($"There no message with id: {updatedMessage.Id}");

        }
    }
}
