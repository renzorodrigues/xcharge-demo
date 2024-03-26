using Microsoft.EntityFrameworkCore;
using xcharge.API.Configuration.Base;
using xcharge.Application.Interfaces.Repositories;
using xcharge.Application.Interfaces.Services;
using xcharge.Infrastructure.Data.DataContext;
using xcharge.Infrastructure.Data.Repositories;
using xcharge.Infrastructure.Services.HttpClient;
using xcharge.Shared.Validations;

namespace xcharge.API.Configuration;

public class InfrastructuresServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        RepositoriesServiceInstaller(services, configuration);
        ServicesServiceInstaller(services, configuration);
        DbContextsServiceInstaller(services, configuration);
    }

    private static void RepositoriesServiceInstaller(
        IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddTransient<ICondominiumRepository, CondominiumRepository>();
        services.AddTransient<IBlockRepository, BlockRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
    }

    private static void ServicesServiceInstaller(
        IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddHttpClient();
        services.AddTransient<IHttpClient, HttpClientFactory>();

        services.AddTransient<IValidator, ValidationRequest>();
    }

    private static void DbContextsServiceInstaller(
        IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PostgreeConnection"))
        );
    }
}
