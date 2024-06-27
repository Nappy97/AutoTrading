using AutoTrading.Domain.Entities;

namespace AutoTrading.Application.Promotions.Queries.GetMainPromotion;

public class PromotionBriefDto
{
    public long Id { get; init; }

    public string? PromotionName { get; init; }

    public DateTime? StartedAt { get; init; }

    public DateTime? FinishedAt { get; init; }

    public string? ImagePath { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Promotion, PromotionBriefDto>();
        }
    }
}