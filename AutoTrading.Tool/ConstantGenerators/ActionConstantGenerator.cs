using Action = AutoTrading.Domain.Entities.Action;

namespace AutoTrading.Tool.ConstantGenerators;

public class ActionConstantGenerator : BaseConstantGenerator<Action>
{
    protected override string EntityName => nameof(Action);
    protected override List<Action> Load() => _context.Actions.ToList();

    protected override string GetLiteral(Action item) => $"{item.Name!.Clean()}_{item.Id}";

    protected override string GetValue(Action item) => $"{item.Id}";
}