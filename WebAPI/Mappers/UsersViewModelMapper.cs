using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels;

namespace WebAPI.Mappers
{
    public class UsersViewModelMapper : IMapper<IEnumerable<User>, IEnumerable<UserViewModel>>
    {
        private readonly IMapper<User, UserViewModel> mapper;

        public UsersViewModelMapper(IMapper<User, UserViewModel> mapper)
        {
            this.mapper = mapper;
        }

        public IEnumerable<UserViewModel> Map(IEnumerable<User> users)
        {
            if (users != null)
            {
                foreach (var user in users)
                    yield return mapper.Map(user);
            }
        }
    }
}
