using AutoTrading.Domain.Constants;
using Microsoft.AspNetCore.Identity;

namespace AutoTrading.Domain.Entities;

public class User : IdentityUser<long>
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public DateTime? LastLoggedAt { get; set; }
    public string? Name { get; set; }
    public int AccessFailedCount { get; set; }
    public long UserRoleId { get; set; }
    public ICollection<UserRole> UserRoles { get; private set; } = new List<UserRole>();
}