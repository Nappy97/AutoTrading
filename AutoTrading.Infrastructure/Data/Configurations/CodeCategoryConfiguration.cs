using AutoTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoTrading.Infrastructure.Data.Configurations;

public class CodeCategoryConfiguration : IEntityTypeConfiguration<CodeCategory>
{
    public void Configure(EntityTypeBuilder<CodeCategory> builder)
    {
        builder.Property(c => c.Id)
            .ValueGeneratedNever();

        builder.Property(c => c.Text)
            .IsRequired()
            .HasMaxLength(50)
            .HasComment("코드 카테고리 설명");
    }
}