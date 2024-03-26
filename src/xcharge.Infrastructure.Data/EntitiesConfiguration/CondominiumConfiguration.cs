using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using xcharge.Domain.Entities;

namespace xcharge.Infrastructure.Data.EntitiesConfiguration;

public class CondominiumConfiguration : IEntityTypeConfiguration<Condominium>
{
    public void Configure(EntityTypeBuilder<Condominium> builder)
    {
        builder.HasKey(k => k.Id);

        builder.Property(c => c.Name).IsRequired();

        builder.ComplexProperty(c => c.Address).IsRequired();

        builder.ComplexProperty(c => c.Landline).IsRequired();

        builder.ComplexProperty(c => c.Mobile).IsRequired();

        builder.ComplexProperty(c => c.Email).IsRequired();

        builder.ComplexProperty(c => c.Identification).IsRequired();

        builder.HasMany(c => c.Users).WithMany(u => u.Condominiums);
    }
}
