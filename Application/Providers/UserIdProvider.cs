using Microsoft.AspNetCore.SignalR;

namespace Application.Providers
{
    public class UserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection) =>
            connection.User.Claims.FirstOrDefault(claim =>
                claim.Type == "username").Value;
    }
}
