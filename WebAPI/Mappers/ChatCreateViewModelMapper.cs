using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels;

namespace WebAPI.Mappers
{
    public class ChatCreateViewModelMapper : IMapper<ChatCreateViewModel, Chat>
    {
        public Chat Map(ChatCreateViewModel entity) =>
            new Chat
            {
                Name = entity.Name
            };
    }
}
