using AutoTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoTrading.Infrastructure.Data.Configurations;

public class CodeConfiguration : IEntityTypeConfiguration<Code>
{
    public void Configure(EntityTypeBuilder<Code> builder)
    {
        builder.Ignore(c => c.Id);

        builder.HasKey(c => c.CodeId);

        builder.Property(c => c.CodeId)
            .ValueGeneratedNever();

        builder.Property(c => c.Text)
            .IsRequired()
            .HasMaxLength(50)
            .HasComment("설명");

        builder.Property(c => c.Enabled)
            .HasDefaultValue(true)
            .IsRequired()
            .HasComment("사용 여부");

        builder.Property(c => c.CodeCategoryId)
            .HasComment("코드 카테고리 ID")
            .IsRequired();

        builder.Property(c => c.Memo)
            .IsRequired()
            .HasDefaultValue(string.Empty)
            .HasMaxLength(50);
    }
}