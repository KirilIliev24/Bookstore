using Bookstore.Core;
using BookstoreAPI.BusinessLogic.Implementations;
using BookstoreAPI.BusinessLogic.Interfaces;

namespace BookstoreAPI.Services
{
    public static class DependencyInjectionRegistry
    {
        public static IServiceCollection AddMyServices(this IServiceCollection services)
        {
            services.AddTransient<IBookServices, BookServices>();
            services.AddTransient<IBookBL, BookBL>();
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddSingleton<IDbClient, DBClient>();
            return services;
        }
    }
}
