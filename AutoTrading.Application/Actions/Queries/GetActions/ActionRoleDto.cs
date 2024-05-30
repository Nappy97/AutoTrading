using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Actions.Queries.GetActions;

public class ActionRoleDto
{
    public long ActionId { get; init; }
    public long RoleId { get; init; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ActionRole, ActionRoleDto>();
        }
    }
}