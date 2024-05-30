using AutoTrading.Application.Common.Interfaces;

namespace AutoTrading.Application.Accounts.Commands.UpdateAccount;

public record UpdateAccountCommand : IRequest
{
    public long Id { get; init; }

    public bool Enabled { get; init; }

    public string? Memo { get; init; }

    public int CurrentAmount { get; init; }

    public int CurrentCurrency { get; init; }
}

public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateAccountCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Accounts
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Enabled = request.Enabled;
        entity.Memo = request.Memo;
        entity.CurrentAmount = request.CurrentAmount;
        entity.CurrentCurrency = request.CurrentCurrency;

        await _context.SaveChangesAsync(cancellationToken);
    }
}