using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels;

namespace WebAPI.Mappers
{
    public class MessagesViewModelMapper : IMapper<IEnumerable<Message>, IEnumerable<MessageViewModel>>
    {
        private readonly IMapper<Message, MessageViewModel> mapper;

        public MessagesViewModelMapper(IMapper<Message, MessageViewModel> mapper)
        {
            this.mapper = mapper;
        }

        public IEnumerable<MessageViewModel> Map(IEnumerable<Message> messages)
        {
            foreach(var message in messages)
                yield return mapper.Map(message);
        }
    }
}
