using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Application.Common.Mappings;
using AutoTrading.Application.Common.Models;
using AutoTrading.Application.Stocks.Queries.GetStocksWithPagination;

namespace AutoTrading.Application.Promotions.Queries.GetMainPromotion;

public record GetPromotionsQuery : IRequest<List<PromotionBriefDto>>;

public class GetPromotionsQueryHandler : IRequestHandler<GetPromotionsQuery, List<PromotionBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPromotionsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<PromotionBriefDto>> Handle(GetPromotionsQuery request,
        CancellationToken cancellationToken)
    {
        var today = DateTime.Now;
        return await _context.Promotions
            .Where(x => x.StartedAt <= today && x.FinishedAt >= today)
            .OrderBy(x => x.Id)
            .ProjectTo<PromotionBriefDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}