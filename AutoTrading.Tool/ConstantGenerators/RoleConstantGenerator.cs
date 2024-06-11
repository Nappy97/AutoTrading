using AutoTrading.Domain.Entities;

namespace AutoTrading.Tool.ConstantGenerators;

internal class RoleConstantGenerator : BaseConstantGenerator<Role>
{
    protected override string EntityName => nameof(Role);
    protected override List<Role> Load() => _context.Roles.ToList();

    protected override string GetLiteral(Role item) => $"{item.Name!.Clean()}_{item.Id}";

    protected override string GetValue(Role item) => $"{item.Id}";
    
    protected override string BuildSecondaryLine(Role item) 
        => $@"public const string {item.Name!.Clean()} = ""{item.Name}"";";
}