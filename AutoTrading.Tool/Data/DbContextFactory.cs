using AutoTrading.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace AutoTrading.Tool;

internal static class DbContextFactory
{
    public static string ConnectionString { get; private set; }
    
    public static void SetConnectionString(string connectionString)
    {
        ConnectionString = connectionString;
    }


    private static PooledDbContextFactory<ApplicationDbContext> _factory;

    public static ApplicationDbContext Create()
    {
        if (_factory == null)
            InitializeFactory();

        return _factory!.CreateDbContext();
    }

    private static void InitializeFactory()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        // 콘솔에 로그 출력
#if DEBUG
        // optionsBuilder.UseLoggerFactory(EasyRepickContextLoggerFactory.GetInstance(
        //     nameof(LogPath.Console),
        //     nameof(LogPath.Debug)));
        // @"EasyRepickContext.log"));

        optionsBuilder.EnableDetailedErrors();
#endif

        // 엔터티 상태를 트랙킹하지 않음
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        // QuerySplittingBehavior
        var querySplittingBehavior = QuerySplittingBehavior.SplitQuery;

        var options = optionsBuilder
            .UseNpgsql(
                ConnectionString,
                x => x.UseQuerySplittingBehavior(querySplittingBehavior))
            .Options;

        _factory = new PooledDbContextFactory<ApplicationDbContext>(options);
    }
}