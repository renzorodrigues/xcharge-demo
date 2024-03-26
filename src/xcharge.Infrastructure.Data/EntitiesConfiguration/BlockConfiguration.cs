using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using xcharge.Domain.Entities;

namespace xcharge.Infrastructure.Data.EntitiesConfiguration;

public class BlockConfiguration : IEntityTypeConfiguration<Block>
{
    public void Configure(EntityTypeBuilder<Block> builder)
    {
        builder.HasKey(k => k.Id);

        builder.Property(b => b.Code).IsRequired();

        builder.Property(b => b.NumberOfLifts);

        builder.HasMany(b => b.Units).WithOne(u => u.Block);
    }
}
