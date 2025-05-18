using System.Net;
using System.Text.Json;

namespace NewmarkIndiaWebApi.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode code;
            string? message = exception?.Message;
            var stackTrace = String.Empty;

            switch (exception)
            {
                case KeyNotFoundException
                or FileNotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;

                case UnauthorizedAccessException:
                    code = HttpStatusCode.Unauthorized;
                    break;
                case
                 ArgumentException
                or InvalidOperationException:
                    code = HttpStatusCode.BadRequest;
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(new { error = message, stackTrace });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
