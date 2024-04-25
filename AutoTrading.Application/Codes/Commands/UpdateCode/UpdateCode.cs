using AutoTrading.Application.Common.Interfaces;

namespace AutoTrading.Application.Codes.Commands.UpdateCode;

public record UpdateCodeCommand : IRequest
{
    public long Id { get; init; }

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
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Text = request.Text;
        entity.Enabled = request.Enabled;

        await _context.SaveChangesAsync(cancellationToken);
    }
}