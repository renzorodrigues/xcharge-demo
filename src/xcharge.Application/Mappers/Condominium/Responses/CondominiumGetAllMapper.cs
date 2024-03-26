using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Application.Interfaces.Mappers;
using xcharge.Application.Interfaces.Mappers.Responses;
using xcharge.Domain.Enums;
using Entities = xcharge.Domain.Entities;

namespace xcharge.Application.Mappers.Condominium.Responses;

public class CondominiumGetAllMapper(ITelephoneResponseMapper telephoneResponseMapper)
    : ICondominiumGetAllMapper
{
    private readonly ITelephoneResponseMapper _telephoneResponseMapper = telephoneResponseMapper;

    public IEnumerable<CondominiumGetAllDto> Map(IEnumerable<Entities.Condominium> entities)
    {
        IEnumerable<CondominiumGetAllDto> responses;

        responses = entities.Select(entity => new CondominiumGetAllDto()
        {
            Id = entity.Id,
            Name = entity.Name,
            Manager = entity.Users?.FirstOrDefault(u => u.Type == UserType.Manager)?.FullName,
            Landline = this._telephoneResponseMapper.Map(entity.Landline),
            Mobile = this._telephoneResponseMapper.Map(entity.Mobile),
            Email = entity.Email?.EmailAddress,
            City = entity.Address?.City,
        });

        return responses;
    }
}
