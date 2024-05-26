using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;
using AutoTrading.Domain.Events.CodeEvents;

namespace AutoTrading.Application.Codes.Commands.CreateCode;

public record CreateCodeCommand : IRequest<int>
{
    public int CodeId { get; init; }

    public string? Text { get; init; }

    public int CodeCategoryId { get; init; }
}

public class CreateCodeCommandHandler : IRequestHandler<CreateCodeCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCodeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCodeCommand request, CancellationToken cancellationToken)
    {
        var entity = new Code
        {
            Id = request.CodeId,
            CodeCategoryId = request.CodeCategoryId,
            Text = request.Text
        };

        entity.AddDomainEvent(new CodeCreatedEvent(entity));

        _context.Codes.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.CodeId;
    }
}