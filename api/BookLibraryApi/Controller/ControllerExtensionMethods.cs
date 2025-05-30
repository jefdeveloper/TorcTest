namespace BookLibraryApi.Controller
{
    public static class ControllerExtensionMethods
    {
        public static WebApplication UseApiEndpoints(this WebApplication app)
        {
            app.MapGet("/books", BookLibraryApi.GetBooks);

            return app;
        }
    }
}
