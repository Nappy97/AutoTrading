using AutoTrading.Infrastructure.Data;
using Action = AutoTrading.Domain.Entities.Action;

namespace AutoTrading.Tool;

public class InitializerActions : ITool
{
    private ApplicationDbContext _context;

    public void Run()
    {
        _context = Program.AddDbContext();

        var actionsEntities = new List<Action>
        {
            new() { Id = 1, Name = "수정" }
        };

        _context.Actions.AddRange(actionsEntities);

        _context.SaveChanges();
    }

    public string Description() => $"{nameof(Action)} initialize";
}