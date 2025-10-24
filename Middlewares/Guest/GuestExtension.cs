using Microsoft.AspNetCore.Builder;

namespace TicketFlowApi.Middlewares.Guest
{
    public static class GuestExtesion
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Guest>();
        }
    }
}
