using xcharge.Application.Interfaces.Mappers;
using xcharge.Domain.ValueObjects;

namespace xcharge.Application.Mappers.ValueObjects.Responses;

public class TelephoneResponseMapper : ITelephoneResponseMapper
{
    public string Map(Telephone? entity)
    {
        return entity!.Number;
    }
}
