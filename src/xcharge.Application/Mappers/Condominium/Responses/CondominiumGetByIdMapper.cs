using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Application.Interfaces.Mappers;
using xcharge.Application.Interfaces.Mappers.Responses;

namespace xcharge.Application.Mappers.Condominium.Responses;

public class CondominiumGetByIdMapper(ITelephoneResponseMapper telephoneResponseMapper)
    : ICondominiumGetByIdMapper
{
    private readonly ITelephoneResponseMapper _telephoneResponseMapper = telephoneResponseMapper;

    public CondominiumGetByIdDto Map(Domain.Entities.Condominium entity)
    {
        return new CondominiumGetByIdDto()
        {
            Id = entity.Id,
            Name = entity.Name,
            AddressPublicArea = entity.Address?.PublicArea,
            AddressComplement = entity.Address?.Complement,
            AddressNumber = entity.Address?.Number,
            AddressDistrict = entity.Address?.District,
            AddressCity = entity.Address?.City,
            AddressState = entity.Address?.State,
            AddressZipCode = entity.Address?.ZipCode,
            Email = entity.Email?.EmailAddress,
            IdCnpj = entity.Identification?.Cnpj,
            IdCityRegistration = entity.Identification?.CityRegistration,
            IdStateRegistration = entity.Identification?.StateRegistration,
            Landline = this._telephoneResponseMapper.Map(entity.Landline),
            Mobile = this._telephoneResponseMapper.Map(entity.Mobile),
        };
    }
}
