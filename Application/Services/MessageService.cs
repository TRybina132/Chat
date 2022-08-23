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

        public async Task<Message> GetMessageById(int messageId) =>
                await repository.GetById(messageId, include: query => query.Include(m => m.Chat)) 
                    ?? throw new Exception($"There no message with id: {messageId}");

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

        public async Task<Message> DeleteMessage(int messageId)
        {
            var message = await GetMessageById(messageId);
            repository.Delete(message);
            await repository.SaveChangesAsync();
            return message;
        }

        public async Task<Message> UpdateMessage(Message updatedMessage)
        {
            var message = await GetMessageById(updatedMessage.Id);
            message.Text = updatedMessage.Text;
            repository.Update(message);
            await repository.SaveChangesAsync();
            return message;
        }
    }
}
