using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Application.Common.Mappings;
using AutoTrading.Application.Common.Models;

namespace AutoTrading.Application.AccountDetails.Queries.GetAccountDetailsWithPagination;

public record GetAccountDetailsWithPaginationQuery : IRequest<PaginatedList<AccountDetailBriefDto>>
{
    public long UserId { get; init; }
    
    public long AccountId { get; init; }

    public int PageNumber { get; init; } = 1;

    public int PageSize { get; init; } = 10;
}

public class GetAccountDetailsWithPaginationQueryHandler : IRequestHandler<GetAccountDetailsWithPaginationQuery, PaginatedList<AccountDetailBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAccountDetailsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<PaginatedList<AccountDetailBriefDto>> Handle(GetAccountDetailsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.AccountDetails
            .Where(x => x.AccountId == request.AccountId && x.Account.UserId == request.UserId)
            .OrderBy(x => x.Id)
            .ProjectTo<AccountDetailBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}