using AutoTrading.Application.Stocks.Commands.UpdateStock;

namespace AutoTrading.Application.Promotions.Commands.UpdatePromotion;

public class UpdatePromotionCommandValidator : AbstractValidator<UpdatePromotionCommand>
{
    public UpdatePromotionCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty()
            .GreaterThanOrEqualTo(1);

        RuleFor(p => p.PromotionName)
            .MaximumLength(200)
            .NotEmpty();

        RuleFor(p => p.StartedAt)
            .NotEmpty();

        RuleFor(p => p.FinishedAt)
            .GreaterThanOrEqualTo(DateTime.Today)
            .NotEmpty();
        
        RuleFor(p => p.ImagePath)
            .MaximumLength(200)
            .NotEmpty();
    }
}