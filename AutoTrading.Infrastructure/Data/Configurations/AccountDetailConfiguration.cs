using AutoTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoTrading.Infrastructure.Data.Configurations;

public class AccountDetailConfiguration : IEntityTypeConfiguration<AccountDetail>
{
    public void Configure(EntityTypeBuilder<AccountDetail> builder)
    {
        builder.Property(a => a.PurchasedPrice)
            .IsRequired()
            .HasComment("개당 구매 가격");

        builder.Property(a => a.PurchasedQuantity)
            .IsRequired()
            .HasComment("구매 수량");

        builder.Property(a => a.PurchasedAt)
            .IsRequired()
            .HasComment("구매 시간");

        builder.Property(a => a.SoldPrice)
            .HasComment("개당 판매 가격");

        builder.Property(a => a.SoldQuantity)
            .HasComment("판매 수량");

        builder.Property(a => a.SoldAt)
            .HasComment("판매 시각");

        builder.Property(a => a.Profit)
            .HasComment("수익");

        builder.Property(a => a.Memo)
            .IsRequired()
            .HasMaxLength(200)
            .HasComment("메모");

        builder.Property(a => a.TradeCode)
            .IsRequired()
            .HasMaxLength(5)
            .HasComment("[15] 매매 구분");
    }
}