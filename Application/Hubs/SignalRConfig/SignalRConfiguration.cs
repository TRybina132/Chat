using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Application.Hubs.SignalRConfig
{
    public static class SignalRConfiguration 
    {
        public static void AddAuthenticationForSignalRHubs(this JwtBearerOptions options)
        {
            options.Events = new JwtBearerEvents()
            {
                OnMessageReceived = context =>
                {
                    var accessToken = context.Request.Query["access_token"];

                    var path = context.HttpContext.Request.Path;
                    if (!string.IsNullOrEmpty(accessToken) &&
                        (path.StartsWithSegments("/chat")))
                    {
                        context.Token = accessToken;
                    }
                    return Task.CompletedTask;
                }
            };
        }
    }
}
