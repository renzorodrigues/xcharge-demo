using System.Net;
using MediatR;
using xcharge.Application.CQS.Commands.UserCommand;
using xcharge.Application.Interfaces.Mappers;
using xcharge.Application.Interfaces.Repositories;
using xcharge.Shared.Helpers;
using xcharge.Shared.Validations;
using static xcharge.Shared.Helpers.ConstantStrings;

namespace xcharge.Application.Handlers.UserHandlers;

public class UserCreateHandler(
    IUserRepository userRepository,
    ICondominiumRepository condominiumRepository,
    IValidator validator,
    IUserCreateMapper userCreateMapper
) : IRequestHandler<UserCreateCommand, Result<Guid>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ICondominiumRepository _condominiumRepository = condominiumRepository;
    private readonly IValidator _validator = validator;
    private readonly IUserCreateMapper _userCreateMapper = userCreateMapper;

    public async Task<Result<Guid>> Handle(
        UserCreateCommand request,
        CancellationToken cancellationToken
    )
    {
        if (request is null)
        {
            return Result<Guid>.RequestFailed();
        }

        var entity = this._userCreateMapper.Map(request);

        var condominium = await this._condominiumRepository.GetById(request.CondominiumId);

        if (condominium is null)
        {
            return Result<Guid>.RequestFailed();
        }

        entity.Condominiums?.Add(condominium);

        var result = await this._userRepository.Create(entity);

        return Result<Guid>.RequestOk(result, Response.CreatedSuccessfully, HttpStatusCode.Created);
    }
}
