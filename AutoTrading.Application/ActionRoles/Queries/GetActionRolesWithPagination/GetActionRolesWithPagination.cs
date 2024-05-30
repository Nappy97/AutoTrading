using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Application.Common.Mappings;
using AutoTrading.Application.Common.Models;

namespace AutoTrading.Application.ActionRoles.Queries.GetActionRolesWithPagination;

public record GetActionRolesWithPaginationQuery : IRequest<PaginatedList<ActionRolesBriefDto>>
{
    public long? ActionId { get; init; }

    public long? RoleId { get; init; }

    public int PageNumber { get; init; } = 1;

    public int PageSize { get; init; } = 10;
}

public class
    GetActionRolesWithPaginationHandler : IRequestHandler<GetActionRolesWithPaginationQuery,
    PaginatedList<ActionRolesBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetActionRolesWithPaginationHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ActionRolesBriefDto>> Handle(GetActionRolesWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        // 아님 말고?
        return await _context.ActionRoles
            .Where(x =>
                (!request.ActionId.HasValue || x.ActionId == request.ActionId.Value) &&
                (!request.RoleId.HasValue || x.RoleId == request.RoleId.Value))
            .OrderBy(x => x.RoleId)
            .ProjectTo<ActionRolesBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}