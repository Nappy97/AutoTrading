#region

using AutoTrading.Domain.Entities;

#endregion

namespace AutoTrading.Tool.ConstantGenerators;

internal class CodeConstantGenerator : BaseConstantGenerator<Code>
{
    protected override string EntityName => "C";

    protected override List<Code> Load() 
        => _context.Codes.Where(x => x.Id != 0).ToList();

    protected override string GetLiteral(Code item)
    {
        long prefix = item.Id / 100;
        return $"_{prefix}_{item.Text.Clean()}";
    }

    protected override string GetValue(Code item) => $"{item.Id}";
}