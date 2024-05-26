namespace AutoTrading.Application.CodeCategories.Commands.CreateCodeCategory;

public class CreateCodeCategoryCommandValidator : AbstractValidator<CreateCodeCategoryCommand>
{
    public CreateCodeCategoryCommandValidator()
    {
        RuleFor(v => v.CodeCategoryId)
            .GreaterThanOrEqualTo(0)
            .NotNull();

        RuleFor(v => v.Text)
            .MaximumLength(50)
            .NotEmpty();
    }
}