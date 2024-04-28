using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Constants;
using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Users.Commands.CreateUser;

public record CreateUserCommand : IRequest<long>
{
    public string? UserName { get; init; }

    public string? Password { get; init; }

    public string? Name { get; init; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
{
    private readonly IApplicationDbContext _context;

    public CreateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = new User
        {
            UserName = request.UserName,
            Password = request.Password,
            Name = request.Name
        };

        _context.Users.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}