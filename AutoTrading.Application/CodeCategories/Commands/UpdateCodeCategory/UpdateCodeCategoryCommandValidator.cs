namespace AutoTrading.Application.CodeCategories.Commands.UpdateCodeCategory;

public class UpdateCodeCategoryCommandValidator : AbstractValidator<UpdateCodeCategoryCommand>
{
    public UpdateCodeCategoryCommandValidator()
    {
        RuleFor(v => v.Id)
            .GreaterThanOrEqualTo(0)
            .NotEmpty();

        RuleFor(v => v.Text)
            .MaximumLength(50)
            .NotEmpty();
    }
}