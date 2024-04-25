using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.CodeCategories.Queries.GetCodes;

public class CodeCategoryDto
{
    public CodeCategoryDto()
    {
        Items = Array.Empty<CodeDto>();
    }

    public long Id { get; init; }
    
    public string? Text { get; init; }
    
    public IReadOnlyCollection<CodeDto> Items { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CodeCategory, CodeCategoryDto>();
        }
    }
}