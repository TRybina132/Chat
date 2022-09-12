using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Chat.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        private async Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync($"Status code: {context.Response.StatusCode} \n message: {exception.Message ?? "uknown"}");
        }

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (EntityNotFoundException ex)
            {
                await ex.HadnleError(httpContext);
            }
            catch(Exception ex) 
            {
                await HandleException(httpContext, ex);
            }
        }
    }
}
