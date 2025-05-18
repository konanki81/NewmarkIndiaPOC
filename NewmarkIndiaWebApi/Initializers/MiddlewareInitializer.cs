using NewmarkIndiaWebApi.Middlewares;

namespace NewmarkIndiaWebApi.Initializers
{
    public static partial class MiddlewareInitializer
    {
        public static WebApplication ConfigureMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
            return app;
        }
    }
}
