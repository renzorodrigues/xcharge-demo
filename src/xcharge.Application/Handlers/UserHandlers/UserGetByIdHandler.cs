using System.Net;
using MediatR;
using xcharge.Application.CQS.Queries.Condominium;
using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Application.Interfaces.Mappers;
using xcharge.Application.Interfaces.Repositories;
using xcharge.Shared.Helpers;
using static xcharge.Shared.Helpers.ConstantStrings;

namespace xcharge.Application.Handlers.CondominiumHandlers;

public class UserGetByIdHandler(IUserRepository repository, IUserMapper mapper)
    : IRequestHandler<UserGetByIdQuery, Result<UserGetByIdDto>>
{
    private readonly IUserRepository _repository = repository;
    private readonly IUserMapper _mapper = mapper;

    public async Task<Result<UserGetByIdDto>> Handle(
        UserGetByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        var entity = await this._repository.GetById(request.Id);

        if (entity is null)
        {
            return Result<UserGetByIdDto>.RequestFailed(
                Response.ObjectNotFound,
                HttpStatusCode.NotFound
            );
        }

        var response = this._mapper.Map(entity);

        return Result<UserGetByIdDto>.RequestOk(response);
    }
}
