using AutoTrading.Application.CodeCategories.Queries.GetCodes;
using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Application.Common.Security;

namespace AutoTrading.Application.Roles.Queries.GetUserRoles;

[Authorize]
public record GetUserRolesQuery : IRequest<UserRolesVm>;

public class GetUserRolesQueryHandler : IRequestHandler<GetUserRolesQuery, UserRolesVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUserRolesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserRolesVm> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
    {
        return new UserRolesVm
        {
            Lists = await _context.Roles
                .AsNoTracking()
                .ProjectTo<RoleDto>(_mapper.ConfigurationProvider)
                .OrderBy(r => r.Id)
                .ToListAsync(cancellationToken)
        };
    }
}