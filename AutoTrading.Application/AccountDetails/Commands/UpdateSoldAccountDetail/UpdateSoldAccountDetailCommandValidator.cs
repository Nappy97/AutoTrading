namespace AutoTrading.Application.AccountDetails.Commands.UpdateSoldAccountDetail;

public class UpdateSoldAccountDetailCommandValidator : AbstractValidator<UpdateSoldAccountDetailCommand>
{
    public UpdateSoldAccountDetailCommandValidator()
    {
        RuleFor(a => a.Id)
            .GreaterThanOrEqualTo(0)
            .NotEmpty();

        RuleFor(a => a.SoledPrice)
            .GreaterThanOrEqualTo(0)
            .NotEmpty();

        RuleFor(a => a.SoledQuantity)
            .GreaterThanOrEqualTo(0)
            .NotEmpty();

        RuleFor(a => a.SoledAt)
            .NotEmpty();
    }
}