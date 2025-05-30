namespace BookLibraryApi.Config
{
    public static class ConfigExtensionMethods
    {
        public static IServiceCollection AddCorsPolicy(this IServiceCollection serviceDescriptors, string corsPolicyName)
        {
            serviceDescriptors.AddCors(options =>
            {
                options.AddPolicy(corsPolicyName,
                    policy => policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod());
            });

            return serviceDescriptors;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddEndpointsApiExplorer();
            serviceDescriptors.AddSwaggerGen((options =>
            {
                options.SwaggerDoc("v1", new()
                {
                    Title = "Book Store API",
                    Version = "v1",
                    Description = "API for search books"
                });
            }));

            return serviceDescriptors;
        }
    }
}
