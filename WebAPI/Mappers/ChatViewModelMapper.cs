using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels;

namespace WebAPI.Mappers
{
    public class ChatViewModelMapper : IMapper<Chat, ChatViewModel>
    {
        private readonly IMapper<IEnumerable<User>,IEnumerable<UserViewModel>> usersMapper;

        public ChatViewModelMapper(
            IMapper<IEnumerable<User>, IEnumerable<UserViewModel>> usersMapper)
        {
            this.usersMapper = usersMapper;
        }

        public ChatViewModel Map(Chat entity)
        {
            var users = 
                entity.UserChats?.Select(uc => uc.User).ToList();

            IEnumerable<UserViewModel> usersViewModels = 
                users != null ?
                    usersMapper.Map(users)
                    : new List<UserViewModel>();

            var viewModel = new ChatViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Users = usersViewModels,
                Type= entity.Type
            };

            return viewModel;
        }
    }
}
