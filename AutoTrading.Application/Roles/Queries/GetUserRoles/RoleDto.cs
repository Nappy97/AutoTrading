using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Roles.Queries.GetUserRoles;

public class RoleDto
{
    public RoleDto()
    {
        UserRoles = Array.Empty<UserRoleDto>();
    }

    public long Id { get; init; }
    
    public string? Name { get; init; }
    
    public IReadOnlyCollection<UserRoleDto> UserRoles { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Role, RoleDto>();
        }
    }
}