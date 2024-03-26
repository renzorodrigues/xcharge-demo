using MediatR;
using xcharge.Application.CQS.Queries.Condominium;
using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Application.Extensions;
using xcharge.Application.Interfaces.Mappers.Responses;
using xcharge.Application.Interfaces.Repositories;
using xcharge.Shared.Helpers;
using static xcharge.Shared.Helpers.ConstantStrings;

namespace xcharge.Application.Handlers.CondominiumHandlers;

public class CondominiumGetAllHandler(
    ICondominiumRepository repository,
    ICondominiumGetAllMapper condominiumGetAllMapper
) : IRequestHandler<CondominiumGetAllQuery, Result<IEnumerable<CondominiumGetAllDto>>>
{
    private readonly ICondominiumRepository _repository = repository;
    private readonly ICondominiumGetAllMapper _condominiumGetAllMapper = condominiumGetAllMapper;

    public async Task<Result<IEnumerable<CondominiumGetAllDto>>> Handle(
        CondominiumGetAllQuery request,
        CancellationToken cancellationToken
    )
    {
        var entities = await this._repository.GetAll();

        if (entities.IsNullOrEmpty())
        {
            return Result<IEnumerable<CondominiumGetAllDto>>.RequestOk(
                [],
                Response.NoRecordsToBeRetrieved
            );
        }

        var responses = this._condominiumGetAllMapper.Map(entities);

        return Result<IEnumerable<CondominiumGetAllDto>>.RequestOk(responses);
    }
}
