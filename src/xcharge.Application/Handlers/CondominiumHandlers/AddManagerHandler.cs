using System.Net;
using MediatR;
using xcharge.Application.CQS.Commands.CondominiumCommand;
using xcharge.Application.Interfaces.Mappers.Condominium;
using xcharge.Application.Interfaces.Repositories;
using xcharge.Shared.Helpers;
using xcharge.Shared.Validations;
using static xcharge.Shared.Helpers.ConstantStrings;

namespace xcharge.Application.Handlers.CondominiumHandlers;

public class AddManagerHandler(
    ICondominiumRepository condominiumRepository,
    IUserRepository userRepository,
    IValidator validator,
    ICondominiumMapper condominiumCreateMapper
) : IRequestHandler<AddManagerCommand, Result<Guid>>
{
    private readonly IValidator _validator = validator;
    private readonly ICondominiumRepository _condominiumRepository = condominiumRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ICondominiumMapper _condominiumCreateMapper = condominiumCreateMapper;

    public async Task<Result<Guid>> Handle(
        AddManagerCommand request,
        CancellationToken cancellationToken
    )
    {
        if (!IsValid(request))
        {
            return Result<Guid>.RequestFailed(
                Response.RequestFailed,
                HttpStatusCode.BadRequest,
                [new Error(Validation.InvalidCnpj)]
            );
        }

        var condominium = await this._condominiumRepository.GetById(request.CondominiumId);

        var user = await this._userRepository.GetById(request.UserId);

        if (condominium is null || user is null)
        {
            return Result<Guid>.RequestFailed();
        }

        condominium.AddManager(condominium, user);

        var result = await this._condominiumRepository.Update(condominium);

        return Result<Guid>.RequestOk(result, Response.UpdatedSuccessfully);
    }

    private static bool IsValid(AddManagerCommand request)
    {
        if (request is null || request.CondominiumId == Guid.Empty || request.UserId == Guid.Empty)
        {
            return false;
        }

        return true;
    }
}
