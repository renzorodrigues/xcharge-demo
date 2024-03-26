using xcharge.Application.Interfaces.Mappers;
using xcharge.Domain.ValueObjects;

namespace xcharge.Application.Mappers.ValueObjects;

public class TelephoneMapper : ITelephoneMapper
{
    public Telephone Map(string request)
    {
        return new Telephone(request);
    }
}
