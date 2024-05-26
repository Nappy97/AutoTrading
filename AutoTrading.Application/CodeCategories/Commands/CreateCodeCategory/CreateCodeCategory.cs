using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;
using AutoTrading.Domain.Events.CodeCategoryEvents;

namespace AutoTrading.Application.CodeCategories.Commands.CreateCodeCategory;

public record CreateCodeCategoryCommand : IRequest<int>
{
    public int CodeCategoryId { get; init; }
    public string? Text { get; init; }
}

public class CreateCodeCategoryCommandHandler : IRequestHandler<CreateCodeCategoryCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCodeCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCodeCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = new CodeCategory
        {
            CodeCategoryId = request.CodeCategoryId,
            Text = request.Text
        };

        entity.AddDomainEvent(new CodeCategoryCreatedEvent(entity));

        _context.CodeCategories.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.CodeCategoryId;
    }
}