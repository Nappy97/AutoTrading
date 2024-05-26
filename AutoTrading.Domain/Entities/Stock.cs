namespace AutoTrading.Domain.Entities;

public class Stock : BaseEntity
{
    /// <summary>
    /// 주식 이름
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 거래를 위한 상품코드
    /// </summary>
    public string? StockCode { get; set; }

    /// <summary>
    /// 자동매매 포함 여부
    /// </summary>
    public bool Enabled { get; set; } = true;

    /// <summary>
    /// [11] 주식 상장 국가
    /// </summary>
    public int NationalityCode { get; set; }

    /// <summary>
    /// [12] 주식 상장 위치(코스피, 코스닥)
    /// </summary>
    public int LocationCode { get; set; }

    /// <summary>
    /// 특이사항
    /// </summary>
    public string? Memo { get; set; }
    
    public ICollection<AccountDetail> AccountDetails { get; private set; } = new List<AccountDetail>();
}