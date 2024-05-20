#region

using System.Reflection;
using AutoTrading.Tool.ConstantGenerators;

#endregion

namespace AutoTrading.Tool;

public class ConstantGeneratorRunner : ITool
{
    public void Run()
    {
        var types = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsSubclassOf(typeof(ConstantGenerator)) && x.IsGenericType is false);

        var generators = types.Select(Activator.CreateInstance).Cast<ConstantGenerator>();

        foreach (var generator in generators)
        {
            generator.Generate();

            Console.WriteLine($"{generator} has been generated");
        }
    }

    public string Description() => "상수 생성";
}