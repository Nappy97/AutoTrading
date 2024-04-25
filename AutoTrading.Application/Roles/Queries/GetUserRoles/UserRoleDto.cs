using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Roles.Queries.GetUserRoles;

public class UserRoleDto
{
    public long UserId { get; init; }
    public long RoleId { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UserRole, UserRoleDto>();
        }
    }
}