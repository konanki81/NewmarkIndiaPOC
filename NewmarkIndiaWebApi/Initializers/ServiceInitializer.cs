

using NewmarkIndia.BusinessLogic.Classes;
using NewmarkIndia.BusinessLogic.Interfaces;

namespace NewmarkIndiaWebApi.Initializers
{
    public static partial class ServiceInitializer
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, WebApplicationBuilder builder)
        {


            services.AddControllers()
                .AddNewtonsoftJson(
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            services.AddHttpClient<IBlobInfo, BlobInfo>();
            return services;
        }
    }
}