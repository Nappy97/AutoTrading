using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Users.Queries;

public record GetUserByUserIdQuery : IRequest<User?>
{
    public long UserId { get; init; }
}

public class GetUserByUserIdQueryHandler : IRequestHandler<GetUserByUserIdQuery, User?>
{
    private readonly IApplicationDbContext _context;

    public GetUserByUserIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<User?> Handle(GetUserByUserIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Users.Where(x => x.Id == request.UserId).FirstOrDefaultAsync(cancellationToken);
    }
}