using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Constants;
using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Users.Commands.CreateUser;

public record CreateUserCommand : IRequest<bool>
{
    public string? UserName { get; init; }

    public string? Password { get; init; }

    public string? ConfirmPassword { get; init; }

    public string? Name { get; init; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public CreateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = new User
        {
            UserName = request.UserName,
            Password = request.Password,
            Name = request.Name
        };

        _context.Users.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}