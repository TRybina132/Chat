using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels;

namespace WebAPI.Mappers
{
    public class ChatsViewModelMapper : IMapper<IEnumerable<Chat>, IEnumerable<ChatViewModel>>
    {
        private readonly IMapper<Chat, ChatViewModel> mapper;

        public ChatsViewModelMapper(IMapper<Chat, ChatViewModel> mapper)
        {
            this.mapper = mapper;
        }

        public IEnumerable<ChatViewModel> Map(IEnumerable<Chat> chats)
        {
            foreach (var chat in chats)
                yield return mapper.Map(chat);
        }
    }
}
