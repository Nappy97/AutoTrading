﻿using AutoTrading.Domain.Entities;
using AutoTrading.Infrastructure.Data;

namespace AutoTrading.Tool;

public class InitializerRoles : ITool
{
    private ApplicationDbContext _context;

    public void Run()
    {
        _context = Program.AddDbContext();

        var rolesEntities = new List<Role>
        {
            new() { Id = 1, Name = "관리자" },
            new() { Id = 2, Name = "유료사용자A" },
            new() { Id = 3, Name = "일반사용자" }
        };

        _context.Roles.AddRange(rolesEntities);

        _context.SaveChanges();
    }

    public string Description() => $"{nameof(Role)} initialize";
}