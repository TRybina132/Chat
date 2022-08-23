using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels;

namespace WebAPI.Mappers
{
    public class MessageMapper : IMapper<MessageViewModel, Message>
    {
        public Message Map(MessageViewModel entity) =>
            new Message
            {
                Id = entity.Id,
                ChatId = entity.ChatId,
                Text = entity.Text
            };
    }
}
