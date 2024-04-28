using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.UserRoles.Queries.GetUserRolesWithPagination;

public class UserRolesBriefDto
{
    public long UserId { get; init; }

    public long RoleId { get; init; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UserRole, UserRolesBriefDto>();
        }
    }
}