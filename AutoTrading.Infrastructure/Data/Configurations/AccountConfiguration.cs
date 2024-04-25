using AutoTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoTrading.Infrastructure.Data.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.Property(a => a.StockFirmCode)
            .HasMaxLength(5)
            .IsRequired()
            .HasComment("[13] 증권사 이름");

        builder.Property(a => a.AccountTypeCode)
            .HasMaxLength(5)
            .IsRequired()
            .HasComment("[14] 계좌 종류");

        builder.Property(a => a.AccountNumber)
            .HasMaxLength(100)
            .IsRequired()
            .HasComment("계좌번호");

        builder.Property(a => a.Enabled)
            .IsRequired()
            .HasComment("사용가능여부");

        builder.Property(a => a.CurrentAmount)
            .IsRequired()
            .HasComment("현재 계좌 평가금액");

        builder.Property(a => a.CurrentCurrency)
            .IsRequired()
            .HasComment("현재 현금 보유");

        builder.Property(a => a.Memo)
            .IsRequired()
            .HasComment("특이사항");
    }
}