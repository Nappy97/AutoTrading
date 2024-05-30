using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.ActionRoles.Queries.GetActionRolesWithPagination;

public class ActionRolesBriefDto
{
    public long ActionId { get; init; }

    public long RoleId { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ActionRole, ActionRolesBriefDto>();
        }
    }
}