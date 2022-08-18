using Core.Entities;
using Core.Interfaces.Mappers;
using Core.Interfaces.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/user")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase 
    {
        private readonly IUserService service;
        private readonly IMapper<User, UserViewModel> userMapper;
        private readonly IMapper<IEnumerable<User>, IEnumerable<UserViewModel>> listMapper;

        public UserController(
            IUserService service, 
            IMapper<User, UserViewModel> userMapper, 
            IMapper<IEnumerable<User>, IEnumerable<UserViewModel>> listMapper)
        {
            this.service = service;
            this.userMapper = userMapper;
            this.listMapper = listMapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> GetAllUsers()
        {
            var users = await service.GetAllUsersAsync();

            var result = listMapper.Map(users);

            return result;
        }

        [HttpGet("{id}")]
        public async Task<UserViewModel> GetUserById([FromRoute]int id)
        {
            User user = await service.GetByIdAsync(id);

            UserViewModel result = userMapper.Map(user);

            return result;
        }
    }
}
