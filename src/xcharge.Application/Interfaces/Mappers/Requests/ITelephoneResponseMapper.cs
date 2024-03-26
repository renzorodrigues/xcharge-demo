using xcharge.Domain.ValueObjects;

namespace xcharge.Application.Interfaces.Mappers;

public interface ITelephoneResponseMapper
{
    string Map(Telephone? entity);
}
