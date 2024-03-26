using xcharge.API.Configuration.Base;
using xcharge.Application.Interfaces.Mappers;
using xcharge.Application.Interfaces.Mappers.Condominium;
using xcharge.Application.Interfaces.Mappers.Responses;
using xcharge.Application.Mappers.BankSlip;
using xcharge.Application.Mappers.Block.Responses;
using xcharge.Application.Mappers.Condominium;
using xcharge.Application.Mappers.Condominium.Responses;
using xcharge.Application.Mappers.User;
using xcharge.Application.Mappers.ValueObjects;
using xcharge.Application.Mappers.ValueObjects.Responses;

namespace xcharge.API.Configuration;

public class MappersServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IBankSlipIssueMapper, BankSlipIssueMapper>();

        services.AddTransient<ICondominiumMapper, CondominiumMapper>();
        services.AddTransient<IUserMapper, UserMapper>();
        services.AddTransient<ICondominiumGetByIdMapper, CondominiumGetByIdMapper>();
        services.AddTransient<ICondominiumGetAllMapper, CondominiumGetAllMapper>();

        services.AddTransient<IBlockGetByIdMapper, BlockGetByIdMapper>();

        services.AddTransient<IUserCreateMapper, UserCreateMapper>();

        services.AddTransient<IIdLegalPersonMapper, IdLegalPersonMapper>();
        services.AddTransient<ITelephoneMapper, TelephoneMapper>();
        services.AddTransient<ITelephoneResponseMapper, TelephoneResponseMapper>();
    }
}
