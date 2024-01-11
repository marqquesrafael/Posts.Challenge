using Posts.Challenge.Domain.Interfaces.Repositories.User;
using Posts.Challenge.Infrastructure.Persistence.Configuration;
using Posts.Challenge.Infrastructure.Persistence.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Posts.Challenge.Domain.Interfaces.Repositories.Post;
using Posts.Challenge.Infrastructure.Persistence.Repositories.Post;

namespace Posts.Challenge.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddPersistenceConfiguration(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PostsDbContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Posts.Challenge.Infrastructure"));
            });

            return services;
        }

        public static IServiceCollection AddRepositoriesResolvers(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }
    }
}
