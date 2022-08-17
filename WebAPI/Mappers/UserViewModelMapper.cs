using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels;

namespace WebAPI.Mappers
{
    public class UserViewModelMapper : IMapper<User, UserViewModel>
    {
        public UserViewModel Map(User entity) =>
            new UserViewModel()
            {
                Id = entity.Id,
                UserName = entity.UserName,
                FirstName = entity.FirstName,
                LastName = entity.LastName
            };
    }
}
