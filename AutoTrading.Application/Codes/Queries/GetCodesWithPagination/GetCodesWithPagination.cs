using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Application.Common.Mappings;
using AutoTrading.Application.Common.Models;

namespace AutoTrading.Application.Codes.Queries.GetCodesWithPagination;

public record GetCodesWithPaginationQuery : IRequest<PaginatedList<CodeBriefDto>>
{
    public long CodeCategoryId { get; init; }

    public int PageNumber { get; init; } = 1;

    public int PageSize { get; init; } = 10;
}

public class
    GetCodesWithPaginationQueryHandler : IRequestHandler<GetCodesWithPaginationQuery, PaginatedList<CodeBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCodesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CodeBriefDto>> Handle(GetCodesWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Codes
            .Where(x => x.CodeCategoryId == request.CodeCategoryId)
            .OrderBy(x => x.Id)
            .ProjectTo<CodeBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}