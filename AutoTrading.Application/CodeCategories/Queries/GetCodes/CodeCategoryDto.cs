using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.CodeCategories.Queries.GetCodes;

public class CodeCategoryDto
{
    public CodeCategoryDto()
    {
        Codes = Array.Empty<CodeDto>();
    }

    public long CodeCategoryId { get; init; }
    
    public string? Text { get; init; }
    
    public IReadOnlyCollection<CodeDto> Codes { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CodeCategory, CodeCategoryDto>();
        }
    }
}