using AutoTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoTrading.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        
        builder.Property(u => u.UserName)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(u => u.Password)
            .IsRequired();

        builder.HasIndex(u => u.UserName)
            .IsUnique();

        builder.Property(u => u.LastLoggedAt)
            .IsRequired();

        builder.Property(u => u.Name)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(u => u.AccessFailedCount)
            .HasDefaultValue(0)
            .IsRequired();

        builder.HasIndex(u => u.UserName)
            .IsUnique();
    }
}