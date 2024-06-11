#region
using System.Text;
using AutoTrading.Domain.Entities;
using AutoTrading.Infrastructure.Data;

#endregion

namespace AutoTrading.Tool;

public class EnumGeneratorRunner : ITool
{
    public string PathToWrite => @"d:\SideProject\Stock\AutoTrading\AutoTrading.Shared\Generated\E.generated.cs";

    public const string OuterTemplate = """
                                        namespace AutoTrading.Shared.Generated;
                                        
                                        public class E
                                        {{
                                            {0}
                                        }}
                                        """;

    public const string CategoryTemplate = """
                                        public enum {0}
                                        {{
                                            {1}
                                        }}
                                        """;

    public const string CodeTemplate = """
                                            {0} = {1},
                                        """;

    private List<CodeCategory> _categories;

    private List<Code> _codes;

    private ApplicationDbContext _context;

    public void Run()
    {
        _context = Program.AddDbContext();
        _categories = _context.CodeCategories.ToList();
        _codes = _context.Codes.ToList();
        
        StringBuilder categoryBuilder = new();

        foreach (var category in _categories.Where(x => x.CodeCategoryId != 0))
        {
            StringBuilder codeBuilder = new();

            var codes = _codes.FindAll(x => x.CodeCategoryId == category.CodeCategoryId);
            foreach (var code in codes)
                codeBuilder.AppendFormat(CodeTemplate, code.Text.Clean(), code.CodeId);

            categoryBuilder.AppendFormat(CategoryTemplate, category.Text.Clean(), codeBuilder);
        }

        string text = string.Format(OuterTemplate, categoryBuilder);

        File.WriteAllText(PathToWrite, text);
    }

    public string Description() => "열거형 생성";
}