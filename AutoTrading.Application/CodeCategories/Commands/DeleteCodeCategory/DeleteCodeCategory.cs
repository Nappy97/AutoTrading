using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Events.CodeCategoryEvents;

namespace AutoTrading.Application.CodeCategories.Commands.DeleteCodeCategory;

public record DeleteCodeCategoryCommand(long Id) : IRequest;

public class DeleteCodeCategoryCommandHandler : IRequestHandler<DeleteCodeCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCodeCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteCodeCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.CodeCategories
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.CodeCategories.Remove(entity);

        entity.AddDomainEvent(new CodeCategoryDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}