using Microsoft.AspNetCore.Builder;

namespace TicketFlowApi.Middlewares.Auth
{
    public static class AuthExtension
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Auth>();
        }
    }
}
