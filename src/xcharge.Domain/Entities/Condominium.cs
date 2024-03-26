using xcharge.Domain.Entities.Base;
using xcharge.Domain.ValueObjects;

namespace xcharge.Domain.Entities;

public sealed class Condominium : BaseEntity
{
    private Condominium() { }

    public Condominium(
        string? name,
        Address? address,
        Email? email,
        Telephone? landline,
        Telephone? mobile,
        IdLegalPerson? identification
    )
    {
        this.Name = name;
        this.Address = address;
        this.Email = email;
        this.Landline = landline;
        this.Mobile = mobile;
        this.Identification = identification;
    }

    public string? Name { get; private set; }
    public Address? Address { get; private set; }
    public Email? Email { get; private set; }
    public Telephone? Landline { get; private set; }
    public Telephone? Mobile { get; private set; }
    public IdLegalPerson? Identification { get; private set; }
    public IList<User>? Users { get; private set; } = [];

    public void AddManager(Condominium condominium, User user)
    {
        condominium.Users?.Add(user);
    }
}
