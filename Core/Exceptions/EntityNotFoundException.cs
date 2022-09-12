using Microsoft.AspNetCore.Http;
using System.Net;

namespace Core.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string? message) : base(message)
        {

        }

        public async Task HadnleError(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync($"Status code: {HttpStatusCode.NotFound} \n Message: {Message}");
        }
    }
}
