using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels;

namespace WebAPI.Mappers
{
    public class MessageCreateViewModelMapper : IMapper<MessageCreateViewModel, Message>
    {
        public Message Map(MessageCreateViewModel entity) =>
            new Message
            {
                ChatId = entity.ChatId,
                SenderId = entity.SenderId,
                Text = entity.Text,
                SentAt = entity.SentAt
            };
    }
}
