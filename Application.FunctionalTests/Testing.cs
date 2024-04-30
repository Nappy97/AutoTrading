using Microsoft.Extensions.DependencyInjection;

namespace Application.FunctionalTests;

[SetUpFixture]
public partial class Testing
{
    /*private static ITestDatabase _database;
    private static CustomWebApplicationFactory _factory = null!;
    private static IServiceScopeFactory _scopeFactory = null!;
    private static long _userId;

    [OneTimeSetUp]
    public async Task RunBeforeAnyTests()
    {
        _database = await TestDatabaseFactory.CreateAsync();

        _factory = new CustomWebApplicationFactory(_database.GetConnection());
        
        _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
    }*/
}