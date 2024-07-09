using System.Security.Cryptography;
using System.Text;

namespace AutoTrading.Shared.Extensions;

public static class StringExtensions
{
    public static string Sha256Hash(this string data)
    {
        // var hash = SHA256.HashData(Encoding.ASCII.GetBytes(data));
        // var stringBuilder = new StringBuilder();
        // return hash.Select(x => stringBuilder.Append($"{x:x2}")).ToString()!;
        return "refreshToken";
    }
}