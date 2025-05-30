using Microsoft.EntityFrameworkCore;

namespace BookLibraryApi.Infra
{
    public static class InfraExtensionMethods
    {
        public static IServiceCollection AddDbContext(this IServiceCollection  serviceDescriptors, IConfiguration configuration)
        {
            serviceDescriptors.AddDbContext<BookLibraryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return serviceDescriptors;
        }
    }
}
