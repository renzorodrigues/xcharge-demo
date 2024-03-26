using xcharge.Application.Interfaces.Mappers;
using xcharge.Domain.ValueObjects;

namespace xcharge.Application.Mappers.ValueObjects;

public class IdLegalPersonMapper : IIdLegalPersonMapper
{
    public IdLegalPerson Map(string request)
    {
        return new IdLegalPerson(request, string.Empty, string.Empty);
    }
}
