using AutoTrading.Domain.Entities;
using Action = AutoTrading.Domain.Entities.Action;

namespace AutoTrading.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }

    DbSet<Stock> Stocks { get; }

    DbSet<CodeCategory> CodeCategories { get; }

    DbSet<Code> Codes { get; }


    DbSet<AccountDetail> AccountDetails { get; }

    DbSet<Account> Accounts { get; }

    DbSet<UserRole> UserRoles { get; }

    DbSet<Role> Roles { get; }
    
    DbSet<Action> Actions { get; }
    
    DbSet<ActionRole> ActionRoles { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}