using System.Reflection;
using AutoTrading.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AutoTrading.Tool;

internal static class Program
{
    public static ApplicationDbContext AddDbContext()
    {
        var config = GetConfiguration();
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseNpgsql(config["ConnectionStrings:DefaultConnection"])
            .Options;

        return new ApplicationDbContext(options);
    }
    
    private static IConfiguration GetConfiguration()
    {
        var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
#if DEBUG
                .AddJsonFile("appsettings.Development.json", true)
#elif STAGING
            .AddJsonFile("appsettings.Staging.json", true)
#endif
            ;

        return builder.Build();
    }
    private static void Main(string[] args)
    {
        var tools = CreateToolInstances();
        for (var i = 0; i < tools.Count; i++)
            Console.WriteLine($"{i + 1}. {tools[i].GetType().Name} : {tools[i].Description()}");

        Console.WriteLine($"Which one? (1 - {tools.Count})");

        try
        {
            var input = int.Parse(Console.ReadLine());
            tools[input - 1].Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private static List<ITool> CreateToolInstances()
    {
        List<ITool> instances = [];
        var assembly = Assembly.GetExecutingAssembly();
        var types = assembly.GetTypes().AsEnumerable();
        foreach (var type in types)
        {
            if (type == typeof(ITool))
                continue;

            if (typeof(ITool).IsAssignableFrom(type) is false)
                continue;

            var instance = Activator.CreateInstance(type) as ITool;
            if (instance != null)
                instances.Add(instance);
        }

        return instances;
    }
}