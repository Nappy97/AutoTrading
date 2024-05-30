namespace AutoTrading.Application.Actions.Queries.GetActions;

public class ActionRolesVm
{
    public IReadOnlyCollection<ActionDto> Lists { get; init; } = Array.Empty<ActionDto>();
}