using AutoTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoTrading.Infrastructure.Data.Configurations;

public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
{
    public void Configure(EntityTypeBuilder<Promotion> builder)
    {
        builder.Property(a => a.PromotionName)
            .HasMaxLength(20)
            .IsRequired()
            .HasComment("이벤트 이름");

        builder.Property(a => a.StartedAt)
            .IsRequired()
            .HasComment("프로모션 시작 날짜");

        builder.Property(a => a.FinishedAt)
            .IsRequired()
            .HasComment("프로모션 종료 날짜");

        builder.Property(a => a.ImagePath)
            .HasMaxLength(200)
            .IsRequired()
            .HasComment("이미지 경로");
    }
}