using Application.Hubs;
using Core.Entities;
using Core.Interfaces.Mappers;
using Core.Interfaces.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/messaging")]
    [ApiController]
    public class MessagingController : ControllerBase
    {
        private readonly IMessageService messageService;
        private readonly IChatService chatService;
        private readonly IUserService userService;
        private readonly IHubContext<MessageHub> hubContext;
        private readonly IMapper<IEnumerable<Message>, IEnumerable<MessageViewModel>>enumMessageMapper;
        private readonly IMapper<MessageCreateViewModel, Message> messageCreateMapper;

        public MessagingController(
            IMessageService messageService,
            IChatService chatService,
            IHubContext<MessageHub> hubContext,
            IMapper<IEnumerable<Message>, IEnumerable<MessageViewModel>> enumMessageMapper, IMapper<MessageCreateViewModel, Message> messageCreateMapper,
            IUserService userService)
        {
            this.messageService = messageService;
            this.chatService = chatService;
            this.hubContext = hubContext;
            this.enumMessageMapper = enumMessageMapper;
            this.messageCreateMapper = messageCreateMapper;
            this.userService = userService; 
        }

        [HttpPost("joinChat")]
        public async Task AddUserToChat([FromBody] ChatViewModel chat)
        {
            string username = User.FindFirstValue("username");

            var user = await userService.GetByUsername(username);
            
            await chatService.AddUserToChatAsync(new UserChat { ChatId = chat.Id, UserId = user.Id });
        }

        [HttpPost("sendToChat")]
        public async Task SendMessageToChat([FromBody] MessageCreateViewModel message)
        {
            string username = User.FindFirstValue("username");

            var user = await userService.GetByUsername(username);
            Message mappedMessage = messageCreateMapper.Map(message);

            await messageService.AddMessage(mappedMessage);
            await hubContext.Clients.Group(message.ChatName).SendAsync("receive", message);
        }
    }
}
