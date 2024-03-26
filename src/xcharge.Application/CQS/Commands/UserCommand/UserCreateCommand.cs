using xcharge.Domain.Enums;
using xcharge.Domain.ValueObjects;
using xcharge.Shared.Handlers;

namespace xcharge.Application.CQS.Commands.UserCommand;

public record UserCreateCommand : Command<Guid>
{
    public string? FullName { get; set; }
    public string? PlaceOfBirth { get; set; }
    public string? Nationality { get; set; }
    public DateTime Birthdate { get; set; }
    public UserType Type { get; set; }
    public Email? Email { get; set; }
    public IdNaturalPerson? Identification { get; set; }
    public Address? Address { get; set; }
    public string? Landline { get; set; }
    public string? Mobile { get; set; }
    public Guid CondominiumId { get; set; }
}
