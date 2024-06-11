using AutoTrading.Domain.Entities;
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
            new() { Name = "관리자" },
            new() { Name = "유료사용자A" }
        };

        _context.Roles.AddRange(rolesEntities);

        _context.SaveChanges();
    }

    public string Description() => $"{nameof(Role)} initialize";
}