using System.Text;

namespace AutoTrading.Tool;

internal static class StringExtension
{
    private const string CharsToRemove = " /().,+-♥♡[]&▩▨▧▦▥▤▣□>＊＆#・·_:";

    internal static string Clean(this string literal)
    {
        StringBuilder builder = new(literal);

        foreach (var charToRemove in CharsToRemove)
            builder.Replace(charToRemove.ToString(), string.Empty);

        var firstChar = builder[0];
        if (char.IsDigit(firstChar))
            builder.Insert(0, "_");

        return builder.ToString();
    }
}