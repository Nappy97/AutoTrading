using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Codes.Queries.GetCodesWithPagination;

public class CodeBriefDto
{
    public int CodeId { get; init; }

    public int CodeCategoryId { get; init; }

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