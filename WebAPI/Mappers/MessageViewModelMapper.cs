using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels;

namespace WebAPI.Mappers
{
    public class MessageViewModelMapper : IMapper<Message, MessageViewModel>
    {
        private readonly IMapper<User, UserViewModel> userMapper;
        
        public MessageViewModelMapper(
            IMapper<User, UserViewModel> userMapper, IMapper<Chat, ChatViewModel> chatMapper)
        {
            this.userMapper = userMapper;
        }

        public MessageViewModel Map(Message entity)
        {
            var viewModel = new MessageViewModel
            {
                Id = entity.Id,
                Text = entity.Text,
                SentAt = entity.SentAt,
                SenderName = entity.Sender?.UserName,
                ChatId = entity.Chat.Id,
                SenderId = entity.SenderId
            };

            return viewModel;

        }
    }
}
