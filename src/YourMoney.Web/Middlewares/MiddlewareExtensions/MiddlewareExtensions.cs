namespace YourMoney.Web.Middlewares.MiddlewareExtensions
{
    using Microsoft.AspNetCore.Builder;

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseSeedDataMiddleware(this IApplicationBuilder builder)
           => builder.UseMiddleware<SeedDataMiddleware>();
    }
}