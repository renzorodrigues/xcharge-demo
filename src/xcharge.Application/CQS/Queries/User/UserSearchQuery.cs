using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Shared.Handlers;

namespace xcharge.Application.CQS.Queries.Condominium;

public class UserSearchQuery(string name) : Query<IEnumerable<UserSearchDto>>
{
    public string Name { get; set; } = name;
}
