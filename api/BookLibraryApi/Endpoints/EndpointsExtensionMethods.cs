namespace BookLibraryApi.Endpoints
{
    public static class EndpointsExtensionMethods
    {
        public static WebApplication UseApiEndpoints(this WebApplication app)
        {
            app.MapGet("/books", BookLibraryApi.GetBooks);

            return app;
        }
    }
}
