using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Application.Common.Security;

namespace AutoTrading.Application.Actions.Queries.GetActions;

[Authorize]
public record GetActionRolesQuery : IRequest<ActionRolesVm>;

public class GetActionRolesQueryHandler : IRequestHandler<GetActionRolesQuery, ActionRolesVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetActionRolesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ActionRolesVm> Handle(GetActionRolesQuery request, CancellationToken cancellationToken)
    {
        return new ActionRolesVm
        {
            Lists = await _context.Actions
                .AsNoTracking()
                .ProjectTo<ActionDto>(_mapper.ConfigurationProvider)
                .OrderBy(a => a.Id)
                .ToListAsync(cancellationToken)
        };
    }
}