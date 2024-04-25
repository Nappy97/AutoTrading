namespace AutoTrading.Application.CodeCategories.Queries.GetCodes;

public class CodesVm
{
    // TODO: 코드 카테고리표 추가
    public IReadOnlyCollection<CodeCategoryDto> Lists { get; init; } = Array.Empty<CodeCategoryDto>();
}