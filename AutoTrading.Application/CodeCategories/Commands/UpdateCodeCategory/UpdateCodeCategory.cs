using AutoTrading.Application.Common.Interfaces;

namespace AutoTrading.Application.CodeCategories.Commands.UpdateCodeCategory;

public record UpdateCodeCategoryCommand : IRequest 
{
    public long Id { get; init; }

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
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Text = request.Text;

        await _context.SaveChangesAsync(cancellationToken);
    }
}