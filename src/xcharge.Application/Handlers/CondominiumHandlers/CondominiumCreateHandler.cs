using System.Net;
using MediatR;
using xcharge.Application.CQS.Commands.CondominiumCommand;
using xcharge.Application.Interfaces.Mappers.Condominium;
using xcharge.Application.Interfaces.Repositories;
using xcharge.Domain.ValueObjects;
using xcharge.Shared.Helpers;
using xcharge.Shared.Validations;
using static xcharge.Shared.Helpers.ConstantStrings;

namespace xcharge.Application.Handlers.CondominiumHandlers;

public class CondominiumCreateHandler(
    ICondominiumRepository repository,
    IValidator validator,
    ICondominiumMapper condominiumCreateMapper
) : IRequestHandler<CondominiumCreateCommand, Result<Guid>>
{
    private readonly IValidator _validator = validator;
    private readonly ICondominiumRepository _repository = repository;
    private readonly ICondominiumMapper _condominiumCreateMapper = condominiumCreateMapper;

    public async Task<Result<Guid>> Handle(
        CondominiumCreateCommand request,
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

        var entity = this._condominiumCreateMapper.Map(request);

        var result = await this._repository.Create(entity);

        return Result<Guid>.RequestOk(result, Response.CreatedSuccessfully, HttpStatusCode.Created);
    }

    private static bool IsValid(CondominiumCreateCommand request)
    {
        if (!IdLegalPerson.IsValidCnpj(request.Cnpj))
        {
            return false;
        }

        return true;
    }
}
