namespace AutoTrading.Domain.Entities;

public class Action : BaseEntity
{
    public string? Name { get; set; }

    public string? Memo { get; set; }

    public ICollection<ActionRole> ActionRoles { get; private set; } = new List<ActionRole>();
}