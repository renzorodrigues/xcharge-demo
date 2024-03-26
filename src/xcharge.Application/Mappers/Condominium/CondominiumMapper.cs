using xcharge.Application.CQS.Commands.CondominiumCommand;
using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Application.Interfaces.Mappers;
using xcharge.Application.Interfaces.Mappers.Condominium;

namespace xcharge.Application.Mappers.Condominium;

public class CondominiumMapper(
    ITelephoneMapper telephoneMapper,
    IIdLegalPersonMapper idLegalPersonMapper
) : ICondominiumMapper
{
    private readonly ITelephoneMapper _telephoneMapper = telephoneMapper;
    private readonly IIdLegalPersonMapper _idLegalPersonMapper = idLegalPersonMapper;

    public CondominiumGetByIdDto Map(Domain.Entities.Condominium entity)
    {
        return new CondominiumGetByIdDto()
        {
            Id = entity.Id,
            Name = entity.Name,
            AddressPublicArea = entity.Address?.PublicArea,
            AddressNumber = entity.Address?.Number,
            AddressComplement = entity.Address?.Complement,
            AddressZipCode = entity.Address?.ZipCode,
            AddressDistrict = entity.Address?.District,
            AddressCity = entity.Address?.City,
            AddressState = entity.Address?.State,
            IdCnpj = entity.Identification?.Cnpj,
            IdCityRegistration = entity.Identification?.CityRegistration,
            IdStateRegistration = entity.Identification?.StateRegistration,
            Email = entity.Email?.EmailAddress,
            Landline = entity.Landline?.Number,
            Mobile = entity.Mobile?.Number,
        };
    }

    public Domain.Entities.Condominium Map(CondominiumCreateCommand request)
    {
        return new Domain.Entities.Condominium(
            request.Name,
            request.Address,
            request.Email,
            this._telephoneMapper.Map(request.Landline!),
            this._telephoneMapper.Map(request.Mobile!),
            this._idLegalPersonMapper.Map(request.Cnpj!)
        );
    }
}
