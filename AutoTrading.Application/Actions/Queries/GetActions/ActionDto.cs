using Action = AutoTrading.Domain.Entities.Action;

namespace AutoTrading.Application.Actions.Queries.GetActions;

public class ActionDto
{
    public ActionDto()
    {
        ActionRoles = Array.Empty<ActionRoleDto>();
    }

    public long Id { get; init; }

    public string? Name { get; init; }

    public string? Memo { get; init; }
    
    public IReadOnlyCollection<ActionRoleDto> ActionRoles { get; init; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Action, ActionDto>();
        }
    }
}