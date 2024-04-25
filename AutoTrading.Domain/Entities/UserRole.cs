﻿namespace AutoTrading.Domain.Entities;

public class UserRole : BaseEntity
{
    public long UserId { get; set; }
    public long RoleId { get; set; }
    public User User { get; set; } = null!;
    public Role Role { get; set; } = null!;
}