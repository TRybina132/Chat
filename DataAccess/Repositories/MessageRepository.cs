using Core.Entities;
using Core.Interfaces.Repositories;
using DataAccess.Context;

namespace DataAccess.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(ChatContext context) : base(context) { }

        public async Task<Message> InsertMessageAsync(Message message)
        {
            var newMessage = await dbSet.AddAsync(message);

            //  ᓚᘏᗢ Just like regular include
            await newMessage.Navigation("Sender").LoadAsync();
            await newMessage.Navigation("Chat").LoadAsync();

            return newMessage.Entity;
        }
    }
}
