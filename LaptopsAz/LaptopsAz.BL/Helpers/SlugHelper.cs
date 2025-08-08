using System.Text.RegularExpressions;

namespace LaptopsAz.BL.Helpers;

public static class SlugHelper
{
    public static string GenerateSlug(string phrase)
    {
        if (string.IsNullOrEmpty(phrase))
        {
            return string.Empty;
        }

        string str = phrase.ToLowerInvariant();

        str = str.Replace("ı", "i")
            .Replace("ğ", "g")
            .Replace("ü", "u")
            .Replace("ş", "s")
            .Replace("ö", "o")
            .Replace("ç", "c");

        str = Regex.Replace(str, @"[^a-z0-9\s-]", ""); 
        
        str = Regex.Replace(str, @"\s+", " ").Trim(); 
        str = str.Replace(" ", "-"); 

        str = str.Trim('-');

        return str;
    }
}