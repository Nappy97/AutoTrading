namespace AutoTrading.Domain.Entities;

public class Code : BaseEntity
{
    public int CodeId { get; set; }
    public int CodeCategoryId { get; set; }
    public string? Text { get; set; }
    public bool Enabled { get; set; } = true;
    public string? Memo { get; set; }
    public CodeCategory CodeCategory { get; set; } = null!;
}