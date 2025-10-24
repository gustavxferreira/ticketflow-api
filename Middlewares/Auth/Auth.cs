using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TicketFlowApi.Middlewares.Auth
{
    public class Auth
    {
        private readonly RequestDelegate _next;

        public Auth(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
            await _next(context);
        }
    }
}
