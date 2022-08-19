using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels;

namespace WebAPI.Mappers
{
    public class MessageViewModelMapper : IMapper<Message, MessageViewModel>
    {
        private readonly IMapper<User, UserViewModel> userMapper;
        //private readonly IMapper<Chat, ChatViewModel> chatMapper;

        public MessageViewModelMapper(
            IMapper<User, UserViewModel> userMapper)
        {
            this.userMapper = userMapper;
            //this.chatMapper = chatMapper;
        }

        public MessageViewModel Map(Message entity) =>
            new MessageViewModel
            {
                Id = entity.Id,
                Text = entity.Text,
                SentAt = entity.SentAt,
                //Chat = chatMapper.Map(entity.Chat),
                Sender = userMapper.Map(entity.Sender)
            };
    }
}
