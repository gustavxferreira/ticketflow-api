using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TicketFlowApi.Middlewares.Guest
{
    public class Guest
    {
        private readonly RequestDelegate _next;

        public Guest(RequestDelegate next)
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
