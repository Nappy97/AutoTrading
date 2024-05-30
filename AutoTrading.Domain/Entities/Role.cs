namespace AutoTrading.Domain.Entities;

public class Role : BaseEntity
{
    public string? Name { get; set; }
    public ICollection<UserRole> Roles { get; private set; } = new List<UserRole>();
    public ICollection<ActionRole> ActionRoles { get; private set; } = new List<ActionRole>();
}