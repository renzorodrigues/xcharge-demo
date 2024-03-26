using System.Net;
using MediatR;
using xcharge.Application.CQS.Queries.Condominium;
using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Application.Interfaces.Repositories;
using xcharge.Shared.Helpers;
using static xcharge.Shared.Helpers.ConstantStrings;

namespace xcharge.Application.Handlers.CondominiumHandlers;

public class UserSearchHandler(IUserRepository repository)
    : IRequestHandler<UserSearchQuery, Result<IEnumerable<UserSearchDto>>>
{
    private readonly IUserRepository _repository = repository;

    public async Task<Result<IEnumerable<UserSearchDto>>> Handle(
        UserSearchQuery request,
        CancellationToken cancellationToken
    )
    {
        var users = await this._repository.GetAllPaged(request.Name);

        if (users is null)
        {
            return Result<IEnumerable<UserSearchDto>>.RequestFailed(
                Response.ObjectNotFound,
                HttpStatusCode.NotFound
            );
        }

        return Result<IEnumerable<UserSearchDto>>.RequestOk(users);
    }
}
