using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Application.Common.Security;

namespace AutoTrading.Application.CodeCategories.Queries.GetCodes;

[Authorize]
public record GetCodesQuery : IRequest<CodesVm>;

public class GetCodesQueryHandler : IRequestHandler<GetCodesQuery, CodesVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCodesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CodesVm> Handle(GetCodesQuery request, CancellationToken cancellationToken)
    {
        return new CodesVm
        {
            Lists = await _context.CodeCategories
                .AsNoTracking()
                .ProjectTo<CodeCategoryDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Id)
                .ToListAsync(cancellationToken)
        };
    }
}