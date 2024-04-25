using AutoTrading.Application.Common.Interfaces;

namespace AutoTrading.Application.AccountDetails.Commands.CreateAccountDetail;

public class CreateAccountDetailCommandValidator : AbstractValidator<CreateAccountDetailCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateAccountDetailCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(a => a.AccountId)
            .NotEmpty()
            .MustAsync(async (a, accountId, cancellationToken) => await IsOwnAccount(a.UserId, accountId, cancellationToken))
            .WithMessage("'{PropertyName}'은 해당 유저의 계좌가 아닙니다.");

        RuleFor(a => a.AccountId)
            .GreaterThanOrEqualTo(0)
            .NotEmpty();

        RuleFor(a => a.PurchasedPrice)
            .GreaterThanOrEqualTo(0)
            .NotEmpty();

        RuleFor(a => a.PurchasedQuantity)
            .GreaterThanOrEqualTo(0)
            .NotEmpty();

        RuleFor(a => a.StockId)
            .GreaterThanOrEqualTo(0)
            .NotEmpty();
    }

    private async Task<bool> IsOwnAccount(long userId, long accountId, CancellationToken cancellationToken = default)
    {
        return await _context.Accounts
            .AnyAsync(account => account.Id == accountId && account.UserId == userId, cancellationToken);
    }
}