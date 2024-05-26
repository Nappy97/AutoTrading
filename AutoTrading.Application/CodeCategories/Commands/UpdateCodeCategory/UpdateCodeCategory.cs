using AutoTrading.Application.Common.Interfaces;

namespace AutoTrading.Application.CodeCategories.Commands.UpdateCodeCategory;

public record UpdateCodeCategoryCommand : IRequest 
{
    public int CodeCategoryId { get; init; }

    public string? Text { get; set; }
}

public class UpdateCodeCategoryCommandHandler : IRequestHandler<UpdateCodeCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCodeCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCodeCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.CodeCategories
            .FindAsync([request.CodeCategoryId], cancellationToken);

        Guard.Against.NotFound(request.CodeCategoryId, entity);

        entity.Text = request.Text;

        await _context.SaveChangesAsync(cancellationToken);
    }
}