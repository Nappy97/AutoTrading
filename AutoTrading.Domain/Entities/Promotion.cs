namespace AutoTrading.Domain.Entities;

public class Promotion : BaseAuditableEntity
{
    public string? PromotionName { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? FinishedAt { get; set; }
    public string? ImagePath { get; set; }
}