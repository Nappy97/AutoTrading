using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Codes.Queries.GetCodesWithPagination;

public class CodeBriefDto
{
    public long Id { get; init; }

    public long CodeCategoryId { get; init; }

    public string? Text { get; init; }

    public bool Enabled { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Code, CodeBriefDto>();
        }
    }
}