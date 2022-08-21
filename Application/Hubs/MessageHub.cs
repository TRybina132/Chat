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
        public async Task JoinChat(string chatName, string userName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatName);
            await Clients.Group(chatName).SendAsync("userJoined", $"User: {userName} joined chat!");
        }

        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("receiveMessage", message);
        }

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
