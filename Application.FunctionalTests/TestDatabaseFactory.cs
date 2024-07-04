namespace Application.FunctionalTests;

public static class TestDatabaseFactory
{
    public static async Task<ITestDatabase> CreateAsync()
    {
        var database = new TestContainersTestDatabase();

        await database.InitializeAsync();

        return database;
    }
}