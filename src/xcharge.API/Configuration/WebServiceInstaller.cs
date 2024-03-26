using System.Text.Json.Serialization;
using xcharge.API.Configuration.Base;
using xcharge.Shared.Middlewares;

namespace xcharge.API.Configuration;

public class WebServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        services.AddTransient<ExceptionHandlerMiddleware>();

        services
            .AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

        services.AddCors(options =>
        {
            options.AddPolicy(
                name: MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                }
            );
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddRouting(r => r.LowercaseUrls = true);
    }
}
