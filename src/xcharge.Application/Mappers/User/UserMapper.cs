using xcharge.Application.DTOs.Condominium.Responses;
using xcharge.Application.Interfaces.Mappers;

namespace xcharge.Application.Mappers.User;

public class UserMapper : IUserMapper
{
    public UserGetByIdDto Map(Domain.Entities.User source)
    {
        return new UserGetByIdDto()
        {
            Id = source.Id,
            FullName = source.FullName,
            Birthdate = source.Birthdate.ToString("dd/MM/yyyy"),
            PlaceOfBirth = source.PlaceOfBirth,
            Nationality = source.Nationality,
            Cpf = source.Identification?.Cpf,
            Rg = source.Identification?.Rg,
            Pis = source.Identification?.Pis,
            UserType = source.Type.ToString(),
            AddressPublicArea = source.Address?.PublicArea,
            AddressComplement = source.Address?.Complement,
            AddressDistrict = source.Address?.District,
            AddressZipCode = source.Address?.ZipCode,
            AddressCity = source.Address?.City,
            AddressState = source.Address?.State,
            Email = source.Email?.EmailAddress,
            Landline = source.Landline?.Number,
            Mobile = source.Mobile?.Number,
        };
    }
}
