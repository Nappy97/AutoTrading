using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Entities;
using AutoTrading.Domain.Events.CodeEvents;

namespace AutoTrading.Application.Codes.Commands.CreateCode;

public record CreateCodeCommand : IRequest<long>
{
    public long Id { get; init; }

    public string? Text { get; init; }

    public long CodeCategoryId { get; init; }
}

public class CreateCodeCommandHandler : IRequestHandler<CreateCodeCommand, long>
{
    private readonly IApplicationDbContext _context;

    public CreateCodeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<long> Handle(CreateCodeCommand request, CancellationToken cancellationToken)
    {
        var entity = new Code
        {
            Id = request.Id,
            CodeCategoryId = request.CodeCategoryId,
            Text = request.Text
            // TODO: Code Category 설명추가
        };

        entity.AddDomainEvent(new CodeCreatedEvent(entity));

        _context.Codes.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}