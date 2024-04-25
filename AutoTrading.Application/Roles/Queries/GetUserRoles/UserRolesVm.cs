namespace AutoTrading.Application.Roles.Queries.GetUserRoles;

public class UserRolesVm
{
    public IReadOnlyCollection<RoleDto> Lists { get; init; } = Array.Empty<RoleDto>();
}