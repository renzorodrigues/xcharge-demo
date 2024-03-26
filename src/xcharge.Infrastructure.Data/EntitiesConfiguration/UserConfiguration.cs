using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using xcharge.Domain.Entities;

namespace xcharge.Infrastructure.Data.EntitiesConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(k => k.Id);

        builder.Property(u => u.FullName).IsRequired();

        builder.Property(u => u.Birthdate).IsRequired();

        builder.Property(u => u.PlaceOfBirth);

        builder.Property(u => u.Nationality);

        builder.Property(u => u.Type).IsRequired();

        builder.ComplexProperty(u => u.Address).IsRequired();

        builder.ComplexProperty(u => u.Email).IsRequired();

        builder.ComplexProperty(u => u.Identification).IsRequired();

        builder.ComplexProperty(u => u.Landline).IsRequired();

        builder.ComplexProperty(u => u.Mobile).IsRequired();
    }
}
