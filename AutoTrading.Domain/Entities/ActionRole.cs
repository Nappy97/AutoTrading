namespace AutoTrading.Domain.Entities;

public class ActionRole : BaseEntity
{
    public long ActionId { get; set; }
    
    public long RoleId { get; set; }

    public Action Action { get; set; } = null!;

    public Role Role { get; set; } = null!;
}