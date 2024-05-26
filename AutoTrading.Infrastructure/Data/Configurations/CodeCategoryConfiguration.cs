using AutoTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoTrading.Infrastructure.Data.Configurations;

public class CodeCategoryConfiguration : IEntityTypeConfiguration<CodeCategory>
{
    public void Configure(EntityTypeBuilder<CodeCategory> builder)
    {
        builder.Ignore(c => c.Id);

        builder.HasKey(c => c.CodeCategoryId);

        builder.Property(c => c.CodeCategoryId)
            .ValueGeneratedNever();

        builder.Property(c => c.Text)
            .HasDefaultValue(string.Empty)
            .IsRequired()
            .HasMaxLength(50)
            .HasComment("코드 카테고리 설명");
    }
}