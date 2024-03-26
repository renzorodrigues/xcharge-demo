using xcharge.Application.CQS.Commands.UserCommand;
using xcharge.Application.Interfaces.Mappers;

namespace xcharge.Application.Mappers.User;

public class UserCreateMapper(ITelephoneMapper telephoneMapper) : IUserCreateMapper
{
    private readonly ITelephoneMapper _telephoneMapper = telephoneMapper;

    public Domain.Entities.User Map(UserCreateCommand? command)
    {
        if (command is null)
        {
            return new Domain.Entities.User();
        }

        return new Domain.Entities.User(
            command.FullName,
            command.Birthdate,
            command.PlaceOfBirth,
            command.Nationality,
            command.Identification,
            command.Type,
            command.Address,
            command.Email,
            this._telephoneMapper.Map(command.Landline!),
            this._telephoneMapper.Map(command.Mobile!),
            []
        );
    }
}
