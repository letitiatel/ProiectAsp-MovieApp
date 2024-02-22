using Proiectasp.Helpers.Seeders;
using Proiectasp.Repositories.UserRepository;
using Proiectasp.Services.UserService;

namespace Proiectasp.Helpers.Extensions
{
    public static  class ServiceExtentions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddTransient<UsersSeeder>();

            return services;
        }
    }
}
