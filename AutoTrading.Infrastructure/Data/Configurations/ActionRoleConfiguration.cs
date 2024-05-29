using AutoTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoTrading.Infrastructure.Data.Configurations;

public class ActionRoleConfiguration : IEntityTypeConfiguration<ActionRole>
{
    public void Configure(EntityTypeBuilder<ActionRole> builder)
    {
        builder.HasKey(a => new { a.ActionId, a.RoleId });
        builder.Ignore(a => a.Id);
    }
}