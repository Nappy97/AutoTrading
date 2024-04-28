using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Application.Common.Mappings;
using AutoTrading.Application.Common.Models;

namespace AutoTrading.Application.UserRoles.Queries.GetUserRolesWithPagination;

public record GetUserRolesWithPaginationQuery : IRequest<PaginatedList<UserRolesBriefDto>>
{
    public long? UserId { get; init; }

    public long? RoleId { get; init; }

    public int PageNumber { get; init; } = 1;

    public int PageSize { get; init; } = 10;
}

public class
    GetUserRolesWithPaginationQueryHandler : IRequestHandler<GetUserRolesWithPaginationQuery,
    PaginatedList<UserRolesBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUserRolesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<PaginatedList<UserRolesBriefDto>> Handle(GetUserRolesWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.UserRoles
            .Where(x =>
                (!request.UserId.HasValue || x.UserId == request.UserId.Value) &&
                (!request.RoleId.HasValue || x.RoleId == request.RoleId.Value))
            .OrderBy(x => x.RoleId)
            .ProjectTo<UserRolesBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        // var query = from x in _context.UserRoles
        //     select x;
        //
        // if (request.UserId.HasValue)
        //     query = query.Where(x => x.UserId == request.UserId.Value);
        //
        // if (request.RoleId.HasValue)
        //     query = query.Where(x => x.RoleId == request.RoleId.Value);
        //
        // return await query
        //     .OrderBy(x => x.RoleId)
        //     .ProjectTo<UserRolesBriefDto>(_mapper.ConfigurationProvider)
        //     .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}