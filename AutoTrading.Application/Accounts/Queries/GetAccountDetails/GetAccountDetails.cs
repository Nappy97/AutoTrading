using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Application.Common.Security;

namespace AutoTrading.Application.Accounts.Queries.GetAccountDetails;

[Authorize]
public record GetAccountDetailsQuery : IRequest<AccountDetailsVm>;

public class GetAccountDetailsQueryHandler : IRequestHandler<GetAccountDetailsQuery, AccountDetailsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAccountDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AccountDetailsVm> Handle(GetAccountDetailsQuery request, CancellationToken cancellationToken)
    {
        return new AccountDetailsVm
        {
            Lists = await _context.Accounts
                .AsNoTracking()
                .ProjectTo<AccountDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Id)
                .ToListAsync(cancellationToken)
        };
    }
}