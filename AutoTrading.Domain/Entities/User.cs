using AutoTrading.Domain.Constants;

namespace AutoTrading.Domain.Entities;

public class User : BaseEntity
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    
    public RoleLevel Role { get; set; }
}