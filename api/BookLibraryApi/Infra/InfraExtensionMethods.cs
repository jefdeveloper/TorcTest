using Microsoft.EntityFrameworkCore;

namespace BookLibraryApi.Infra
{
    public static class InfraExtensionMethods
    {
        public static IServiceCollection AddDbContext(this IServiceCollection  serviceDescriptors, IConfiguration configuration)
        {
            serviceDescriptors.AddDbContextFactory<BookLibraryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return serviceDescriptors;
        }

        public static WebApplication UseDbContext(this WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var databaseContext = scope.ServiceProvider.GetService<BookLibraryContext>();
            if (databaseContext != null)
            {
                databaseContext.Database.EnsureCreated();
            }

            return app;
        }
    }
}
