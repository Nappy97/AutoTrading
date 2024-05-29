using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Action = AutoTrading.Domain.Entities.Action;

namespace AutoTrading.Infrastructure.Data.Configurations;

public class ActionConfiguration : IEntityTypeConfiguration<Action>
{
    public void Configure(EntityTypeBuilder<Action> builder)
    {
        builder.Property(a => a.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(a => a.Memo)
            .HasMaxLength(50)
            .IsRequired()
            .HasDefaultValue(string.Empty);
    }
}