using AutoTrading.Application.Common.Interfaces;

namespace AutoTrading.Application.Users.Queries.ExistsSameUserName;

public record ExistsSameUserNameQuery : IRequest<bool>
{
    public string? UserName { get; init; }
}

public class ExistsSameUserNameQueryHandler : IRequestHandler<ExistsSameUserNameQuery, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ExistsSameUserNameQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(ExistsSameUserNameQuery request, CancellationToken cancellationToken)
    {
        return await _context.Users.AnyAsync(x => x.UserName == request.UserName, cancellationToken);
    }
}