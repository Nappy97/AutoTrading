using AutoTrading.Application.Common.Interfaces;

namespace AutoTrading.Application.Codes.Commands.UpdateCode;

public record UpdateCodeCommand : IRequest
{
    public int CodeId { get; init; }

    public string? Text { get; init; }

    public bool Enabled { get; init; }
}

public class UpdateCodeCommandHandler : IRequestHandler<UpdateCodeCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCodeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCodeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Codes
            .FindAsync([request.CodeId], cancellationToken);

        Guard.Against.NotFound(request.CodeId, entity);

        entity.Text = request.Text;
        entity.Enabled = request.Enabled;

        await _context.SaveChangesAsync(cancellationToken);
    }
}