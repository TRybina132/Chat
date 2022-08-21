using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace Application.Providers
{
    public class UserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection) =>
            connection.User.Claims.FirstOrDefault(c => c.Type == "username")!.Value;
    }
}
