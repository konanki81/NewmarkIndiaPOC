using Serilog;

namespace NewmarkIndiaWebApi.Extensions
{
    public static class SerilogSetupExtension
    {
        public static WebApplicationBuilder EnableSerilog(this WebApplicationBuilder builder)
        {

            var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().CreateLogger();
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);

            Log.Information("Serilog Enabled");

            return builder;
        }
    }
}
