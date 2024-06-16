using System.Globalization;

namespace AutoTrading.Shared.Utilities;

public class NappyCultureInfo
{
    private static readonly CultureInfo _default;

    static NappyCultureInfo()
    {
        _default = new CultureInfo("ko-KR")
        {
            DateTimeFormat =
            {
                ShortDatePattern = "yyyy-MM-dd"
            },
            NumberFormat =
            {
                CurrencyDecimalDigits = 0,
                CurrencySymbol = string.Empty
            }
        };
    }

    public static CultureInfo Default => _default;
}