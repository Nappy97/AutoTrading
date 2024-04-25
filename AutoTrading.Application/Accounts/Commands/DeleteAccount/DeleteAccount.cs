using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Events.AccountEvents;

namespace AutoTrading.Application.Accounts.Commands.DeleteAccount;

public record DeleteAccountCommand(long Id) : IRequest;

public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteAccountCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Accounts
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Accounts.Remove(entity);
        
        entity.AddDomainEvent(new AccountDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}