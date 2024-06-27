using AutoTrading.Application.Roles.Commands.CreateRole;

namespace AutoTrading.Application.Promotions.Commands.CreatePromotion;

public class CreatePromotionCommandValidator : AbstractValidator<CreatePromotionCommand>
{
    public CreatePromotionCommandValidator()
    {
        RuleFor(p => p.PromotionName)
            .MaximumLength(200)
            .NotEmpty();

        RuleFor(p => p.StartedAt)
            .NotEmpty();

        RuleFor(p => p.FinishedAt)
            .NotEmpty()
            .GreaterThanOrEqualTo(DateTime.Today);

        RuleFor(p => p.ImagePath)
            .MaximumLength(200)
            .NotEmpty();
    }
}