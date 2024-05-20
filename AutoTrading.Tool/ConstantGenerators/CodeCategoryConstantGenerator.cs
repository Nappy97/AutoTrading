#region

using AutoTrading.Domain.Entities;

#endregion

namespace AutoTrading.Tool.ConstantGenerators;

internal class CodeCategoryConstantGenerator : BaseConstantGenerator<CodeCategory>
{
    protected override string EntityName => nameof(CodeCategory);

    protected override List<CodeCategory> Load() => _context.CodeCategories.Where(x => x.Id != 0).ToList();

    protected override string GetLiteral(CodeCategory item) => $"{item.Text.Clean()}_{item.Id}";

    protected override string GetValue(CodeCategory item) => $"{item.Id}";
}