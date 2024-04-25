using System.Reflection;
using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoTrading.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();

    public DbSet<Stock> Stocks => Set<Stock>();

    public DbSet<CodeCategory> CodeCategories => Set<CodeCategory>();

    public DbSet<Code> Codes => Set<Code>();


    public DbSet<AccountDetail> AccountDetails => Set<AccountDetail>();

    public DbSet<Account> Accounts => Set<Account>();


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}