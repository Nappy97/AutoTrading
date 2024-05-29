using AutoTrading.Application.Common.Interfaces;
using AutoTrading.Domain.Events.ActionEvent;
using Action = AutoTrading.Domain.Entities.Action;

namespace AutoTrading.Application.Actions.Commands.CreateAction;

public record CreateActionCommand : IRequest<long>
{
    public string? Name { get; init; }

    public string? Memo { get; set; }
}

public class CreateActionCommandHandler : IRequestHandler<CreateActionCommand, long>
{
    private readonly IApplicationDbContext _context;

    public CreateActionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<long> Handle(CreateActionCommand request, CancellationToken cancellationToken)
    {
        var entity = new Action
        {
            Name = request.Name,
            Memo = request.Memo
        };
        
        entity.AddDomainEvent(new ActionCreatedEvent(entity));

        _context.Actions.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}