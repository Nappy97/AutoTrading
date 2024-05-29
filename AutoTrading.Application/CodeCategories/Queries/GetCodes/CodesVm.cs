namespace AutoTrading.Application.CodeCategories.Queries.GetCodes;

public class CodesVm
{
    public IReadOnlyCollection<CodeCategoryDto> Lists { get; init; } = Array.Empty<CodeCategoryDto>();
}