namespace AutoTrading.Domain.Entities;

public class Code : BaseAuditableEntity
{
    public long CodeCategoryId { get; set; }
    public string? Text { get; set; }
    public bool Enabled { get; set; }
    public string? Memo { get; set; }
    public CodeCategory CodeCategory { get; set; } = null!;
}