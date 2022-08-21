using Core.Entities;
using Core.Interfaces.Mappers;
using Core.Interfaces.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Application.Hubs
{
    [Authorize]
    public class MessageHub : Hub
    {
        private readonly IChatService chatService;

        //private async Task<User> GetCurrentUser()
        //{
        //    var username = Context.User.FindFirst("username")?.Value;
        //    User user = await userService.GetByUsername(username);
        //    return user;
        //}

        public MessageHub(
            IChatService chatService)
        {
            this.chatService = chatService;
        }

        //public async Task<IList<MessageViewModel>> JoinChat(ChatViewModel chat)
        //{
        //    var user = GetCurrentUser();
        //    await chatService.AddUserToChatAsync(new UserChat { ChatId = chat.Id, UserId = user.Id});
        //    await Groups.AddToGroupAsync(Context.ConnectionId, chat.Name);

        //    var messages = await messageService.GetMessagesForChat(chat.Id);
        //    return messageMapper.Map(messages).ToList();
        //}

        //public async Task SendMessageToGroup(MessageCreateViewModel message)
        //{
        //    Message mappedMessage = messageCreateMapper.Map(message);
        //    await messageService.AddMessage(mappedMessage);

        //    await Clients.Group(message.ChatName).SendAsync(message.Text);
        //}

        //public async Task SendMessage(string message)
        //{
        //    await Clients.All.SendAsync(message);
        //}

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
