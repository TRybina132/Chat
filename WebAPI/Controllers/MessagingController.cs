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
        private readonly IMapper<MessageCreateViewModel, Message> messageCreateMapper;
        private readonly IMapper<Message, MessageViewModel> messageMapper;

        public MessagingController(
            IMessageService messageService,
            IChatService chatService,
            IHubContext<MessageHub> hubContext,
            IMapper<MessageCreateViewModel, Message> messageCreateMapper,
            IMapper<Message, MessageViewModel> messageMapper,
            IUserService userService)
        {
            this.messageService = messageService;
            this.chatService = chatService;
            this.hubContext = hubContext;
            this.messageCreateMapper = messageCreateMapper;
            this.userService = userService;
            this.messageMapper = messageMapper;
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
            Message mappedMessage = messageCreateMapper.Map(message);

            Message createdMessage = await messageService.AddMessage(mappedMessage);
            MessageViewModel createdMessageViewModel = messageMapper.Map(createdMessage);

            createdMessageViewModel.SenderName = User.FindFirstValue("username");
            await hubContext.Clients.Group(message.ChatName).SendAsync("receive", createdMessageViewModel);
        }

        [HttpDelete("deleteMessage/{id}")]
        public async Task DeleteMessage([FromRoute] int id)
        {

        }

        [HttpPost("sendToUser")]
        public async Task SendMessageToUser([FromBody] MessageCreateViewModel message)
        {
                
        }
    }
}
