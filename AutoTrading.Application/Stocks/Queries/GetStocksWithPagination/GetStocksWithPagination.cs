using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Application.Common.Mappings;
using AutoTrading.Application.Common.Models;

namespace AutoTrading.Application.Stocks.Queries.GetStocksWithPagination;

public record GetStocksWithPaginationQuery : IRequest<PaginatedList<StockBriefDto>>
{
    public int PageNumber { get; init; } = 1;

    public int PageSize { get; init; } = 10;
}

public class GetStocksWithPaginationQueryHandler :
    IRequestHandler<GetStocksWithPaginationQuery, PaginatedList<StockBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetStocksWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<StockBriefDto>> Handle(GetStocksWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Stocks
            .OrderBy(x => x.Name)
            .ProjectTo<StockBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}