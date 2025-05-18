using NewmarkIndia.BusinessLogic.Classes;
using NewmarkIndia.BusinessLogic.Interfaces;
using NewmarkIndiaWebApi.Extensions;
using System.Text.Json;

namespace NewmarkIndiaWebApi.Initializers
{
    public static class BuilderInitializers
    {
        public static WebApplicationBuilder RegisterBuildServices(this WebApplicationBuilder builder)
        {
            builder.EnableSerilog();
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });

            var blobUrlInfoOptionsSection = builder.Configuration.GetSection(nameof( BlobUrlInfo));
            builder.Services.Configure<BlobUrlInfo>(blobUrlInfoOptionsSection);

           

            return builder;
        }
    }
}
