namespace AutoTrading.Domain.Entities;

public class CodeCategory : BaseAuditableEntity
{
    public string? Text { get; set; }

    public ICollection<Code> Codes { get; private set; } = new List<Code>();
}