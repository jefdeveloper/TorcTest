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
    }
}
