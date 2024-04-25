using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }

    DbSet<Stock> Stocks { get; }

    DbSet<CodeCategory> CodeCategories { get; }

    DbSet<Code> Codes { get; }


    DbSet<AccountDetail> AccountDetails { get; }

    DbSet<Account> Accounts { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}