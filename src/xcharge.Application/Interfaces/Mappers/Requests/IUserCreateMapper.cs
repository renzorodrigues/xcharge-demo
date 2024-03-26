using xcharge.Application.CQS.Commands.UserCommand;
using xcharge.Domain.Entities;

namespace xcharge.Application.Interfaces.Mappers;

public interface IUserCreateMapper
{
    User Map(UserCreateCommand? command);
}
