using Bookstore.Core;
using Microsoft.Extensions.Configuration;

namespace BookstoreAPI.Services
{
    public static class DependencyInjectionRegistry
    {
        public static IServiceCollection AddMyServices(this IServiceCollection services)
        {
            services.AddTransient<IBookServices, BookServices>();

            services.AddSingleton<IDbClient, DBClient>();
            return services;
        }
    }
}
