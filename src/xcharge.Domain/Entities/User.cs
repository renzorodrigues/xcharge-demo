using xcharge.Domain.Entities.Base;
using xcharge.Domain.Enums;
using xcharge.Domain.ValueObjects;

namespace xcharge.Domain.Entities;

public class User : BaseEntity
{
    public User() { }

    public User(
        string? fullName,
        DateTime birthdate,
        string? placeOfBirth,
        string? nationality,
        IdNaturalPerson? identification,
        UserType type,
        Address? address,
        Email? email,
        Telephone? landline,
        Telephone? mobile,
        IList<Condominium> condominiums
    )
    {
        this.FullName = fullName;
        this.Birthdate = birthdate;
        this.PlaceOfBirth = placeOfBirth;
        this.Nationality = nationality;
        this.Identification = identification;
        this.Type = type;
        this.Address = address;
        this.Email = email;
        this.Landline = landline;
        this.Mobile = mobile;
        this.Condominiums = condominiums;
    }

    public string? FullName { get; private set; }
    public DateTime Birthdate { get; private set; }
    public string? PlaceOfBirth { get; private set; }
    public string? Nationality { get; private set; }
    public IdNaturalPerson? Identification { get; private set; }
    public UserType Type { get; private set; }
    public Address? Address { get; private set; }
    public Email? Email { get; private set; }
    public Telephone? Landline { get; private set; }
    public Telephone? Mobile { get; private set; }
    public IList<Condominium>? Condominiums { get; private set; }
}
