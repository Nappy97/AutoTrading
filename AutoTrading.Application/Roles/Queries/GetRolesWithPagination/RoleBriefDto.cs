using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Roles.Queries.GetRolesWithPagination;

public class RoleBriefDto
{
    public long Id { get; init; }

    public string? Name { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Role, RoleBriefDto>();
        }
    }
}