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
    }
}
