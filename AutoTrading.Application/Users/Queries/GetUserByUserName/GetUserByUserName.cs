using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Users.Queries.GetUserByUserName;

public record GetUserByUserNameQuery : IRequest<User?>
{
    public string? UserName { get; init; }
}

public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameQuery, User?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUserByUserNameQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<User?> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
    {
        return await _context.Users.Where(x => x.UserName == request.UserName).FirstOrDefaultAsync(cancellationToken);
    }
}