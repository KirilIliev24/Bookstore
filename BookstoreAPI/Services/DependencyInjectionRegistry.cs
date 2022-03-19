using Bookstore.Core;
using Bookstore.Core.Services.UserServices;
using BookstoreAPI.BusinessLogic.Implementations;
using BookstoreAPI.BusinessLogic.Interfaces;

namespace BookstoreAPI.Services
{
    public static class DependencyInjectionRegistry
    {
        public static IServiceCollection AddMyServices(this IServiceCollection services)
        {
            //database related
            services.AddSingleton<IDbClient, DBClient>();
            services.AddTransient<IBookServices, BookServices>();
            services.AddTransient<IUserService, UserService>();

            //business logic related
            services.AddTransient<IBookBL, BookBL>();
            services.AddTransient<IUserBL, UserBL>();
            
            //mapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            return services;
        }
    }
}
