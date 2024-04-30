﻿using AutoTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoTrading.Infrastructure.Data.Configurations;

public class CodeConfiguration : IEntityTypeConfiguration<Code>
{
    public void Configure(EntityTypeBuilder<Code> builder)
    {
        builder.Property(c => c.Text)
            .IsRequired()
            .HasMaxLength(50)
            .HasComment("설명");

        builder.Property(c => c.Enabled)
            .HasComment("사용 여부");

        builder.Property(c => c.CodeCategoryId)
            .HasComment("코드 카테고리 ID")
            .IsRequired();
    }
}