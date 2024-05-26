#region

using System.Text;
using AutoTrading.Infrastructure.Data;
using AutoTrading.Tool;
using File = System.IO.File;

#endregion

namespace AutoTrading.Tool.ConstantGenerators;

public abstract class ConstantGenerator
{
    public abstract string Generate();
}

public abstract class BaseConstantGenerator<T> : ConstantGenerator
{
    protected abstract string EntityName { get; }
    protected abstract List<T> Load();
    protected abstract string GetLiteral(T item);
    protected abstract string GetValue(T item);
    protected virtual string BuildPrimaryLine(T item) => $"public const int {GetLiteral(item)} = {GetValue(item)};";
    protected virtual string BuildSecondaryLine(T item) => string.Empty;
    protected virtual string BuildTernaryLine(T item) => string.Empty;
    private string PathToWrite => @$"d:\SideProject\Stock\AutoTrading\AutoTrading.Shared\Generated\{EntityName}.generated.cs";

    protected ApplicationDbContext _context => Program.AddDbContext();


    public override string Generate()
    {
        StringBuilder builder = new StringBuilder();

        try
        {
            List<T> list = Load();

            foreach (T item in list)
                builder.AppendLine(BuildPrimaryLine(item));

            builder.AppendLine();

            foreach (T item in list)
                builder.AppendLine(BuildSecondaryLine(item));

            builder.AppendLine();

            foreach (T item in list)
                builder.AppendLine(BuildTernaryLine(item));

            string lines = builder.ToString();
            string content = $$"""
                               // 이 파일은 [{{DateTime.Now}}]에 도구에 의해 생성된 파일입니다.

                               namespace AutoTrading.Shared;
                               
                                   public partial class {{EntityName}}
                                   {
                                       {{lines}}
                                   }

                               """;

            File.WriteAllText(PathToWrite, content);

            return null;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}