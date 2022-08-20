using Core.Entities;
using Core.Interfaces.Mappers;
using Core.Interfaces.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Application.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IChatService chatService;
        private readonly IUserService userService;
        private readonly IMessageService messageService;
        private readonly IMapper<IEnumerable<Message>,IEnumerable<MessageViewModel>> messageMapper;
        private readonly IMapper<Message, MessageCreateViewModel> messageCreateMapper;

        private async Task<User> GetCurrentUser()
        {
            var username = Context.User.FindFirst("username")?.Value;
            User user = await userService.GetByUsername(username);
            return user;
        }

        public ChatHub(
            IChatService chatService, 
            IUserService userService, IMessageService messageService,
            IMapper<IEnumerable<Message>, IEnumerable<MessageViewModel>> messageMapper,
            IMapper<Message, MessageCreateViewModel> messageCreateMapper)
        {
            this.chatService = chatService;
            this.userService = userService;
            this.messageService = messageService;
            this.messageMapper = messageMapper;
            this.messageCreateMapper = messageCreateMapper;
        }

        public async Task<IList<MessageViewModel>> JoinChat(ChatViewModel chat)
        {
            var user = GetCurrentUser();
            await chatService.AddUserToChatAsync(new UserChat { ChatId = chat.Id, UserId = user.Id});

            var messages = await messageService.GetMessagesForChat(chat.Id);
            return messageMapper.Map(messages).ToList();
        }

        public async Task SendMessage(MessageCreateViewModel message)
        {
            
        }
    }
}
