namespace xcharge.Domain.ValueObjects;

public record Address(
    string PublicArea,
    string Number,
    string? Complement,
    string District,
    string City,
    string State,
    string ZipCode
);
