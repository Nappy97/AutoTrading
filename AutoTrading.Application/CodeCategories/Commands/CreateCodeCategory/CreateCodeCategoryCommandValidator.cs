﻿namespace AutoTrading.Application.CodeCategories.Commands.CreateCodeCategory;

public class CreateCodeCategoryCommandValidator : AbstractValidator<CreateCodeCategoryCommand>
{
    public CreateCodeCategoryCommandValidator()
    {
        RuleFor(v => v.Id)
            .GreaterThanOrEqualTo(0)
            .NotEmpty();

        RuleFor(v => v.Text)
            .MaximumLength(50)
            .NotEmpty();
    }
}