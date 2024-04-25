using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;
using AutoTrading.Domain.Events.AccountEvents;

namespace AutoTrading.Application.Accounts.Commands.CreateAccount;

public record CreateAccountCommand : IRequest<long>
{
    public long UserId { get; init; }
    public int StockFirmCode { get; init; }
    public int AccountTypeCode { get; init; }
    public string? AccountNumber { get; init; }
}

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, long>
{
    private readonly IApplicationDbContext _context;

    public CreateAccountCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<long> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var entity = new Account
        {
            UserId = request.UserId,
            StockFirmCode = request.StockFirmCode,
            AccountTypeCode = request.AccountTypeCode,
            AccountNumber = request.AccountNumber
        };

        entity.AddDomainEvent(new AccountCreatedEvent(entity));

        _context.Accounts.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}