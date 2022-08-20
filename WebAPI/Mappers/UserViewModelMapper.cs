using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels;

namespace WebAPI.Mappers
{
    public class UserViewModelMapper : IMapper<User, UserViewModel>
    {
        private readonly IMapper<IEnumerable<Chat>, IEnumerable<ChatViewModel>> chatsMapper;

        public UserViewModel Map(User entity)
        {
            var chats = entity.UserChats.Select(uc => uc.Chat);

            var chatsViewModels = chats != null ?
                chatsMapper.Map(chats) :
                new List<ChatViewModel>();

            var viewModel = new UserViewModel()
            {
                Id = entity.Id,
                Username = entity.UserName,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Chats = chatsViewModels
            };

            return viewModel;
        }
    }
}
