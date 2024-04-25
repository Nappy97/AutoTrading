using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;
using AutoTrading.Domain.Events.CodeCategoryEvents;

namespace AutoTrading.Application.CodeCategories.Commands.CreateCodeCategory;

public record CreateCodeCategoryCommand : IRequest<long>
{
    public long Id { get; init; }
    public string? Text { get; init; }
}

public class CreateCodeCategoryCommandHandler : IRequestHandler<CreateCodeCategoryCommand, long>
{
    private readonly IApplicationDbContext _context;

    public CreateCodeCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<long> Handle(CreateCodeCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = new CodeCategory
        {
            Id = request.Id,
            Text = request.Text
        };

        entity.AddDomainEvent(new CodeCategoryCreatedEvent(entity));

        _context.CodeCategories.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}