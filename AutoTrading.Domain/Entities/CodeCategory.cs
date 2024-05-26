namespace AutoTrading.Domain.Entities;

public class CodeCategory : BaseEntity
{
    public int CodeCategoryId { get; set; }
    
    public string? Text { get; set; }
    
    public ICollection<Code> Codes { get; private set; } = new List<Code>();
}