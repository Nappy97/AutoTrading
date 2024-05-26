using AutoTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoTrading.Infrastructure.Data.Configurations;

public class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(50)
            .HasComment("주식 이름");

        builder.Property(s => s.StockCode)
            .IsRequired()
            .HasMaxLength(30)
            .HasComment("거래를 위한 상품코드");

        builder.Property(s => s.Enabled)
            .IsRequired()
            .HasComment("자동매매 포함 여부");

        builder.Property(s => s.NationalityCode)
            .IsRequired()
            .HasMaxLength(5)
            .HasComment("[11] 주식 상장 국가");

        builder.Property(s => s.LocationCode)
            .IsRequired()
            .HasMaxLength(5)
            .HasComment("[12] 주식 상장 위치(코스피, 코스닥)");

        builder.Property(s => s.Memo)
            .IsRequired()
            .HasDefaultValue(string.Empty)
            .HasComment("특이사항");
    }
}