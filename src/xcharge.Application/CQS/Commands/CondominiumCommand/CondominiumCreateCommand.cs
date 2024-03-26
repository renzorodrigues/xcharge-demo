using xcharge.Domain.ValueObjects;
using xcharge.Shared.Handlers;

namespace xcharge.Application.CQS.Commands.CondominiumCommand;

public record CondominiumCreateCommand : Command<Guid>
{
    public string? Name { get; set; }
    public string? Cnpj { get; set; }
    public Email? Email { get; set; }
    public Address? Address { get; set; }
    public string? Landline { get; set; }
    public string? Mobile { get; set; }
}
