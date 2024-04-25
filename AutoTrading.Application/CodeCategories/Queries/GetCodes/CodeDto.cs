using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.CodeCategories.Queries.GetCodes;

public class CodeDto
{
    public long Id { get; init; }
    public long CodeCategoryId { get; init; }
    public string? Text { get; init; }
    public bool Enabled { get; init; }
    public string? Memo { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Code, CodeDto>();
        }
    }
}