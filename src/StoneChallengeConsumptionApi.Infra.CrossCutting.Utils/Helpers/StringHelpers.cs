using System;

namespace StoneChallenge.CrossCutting.Utils.Helpers;

public static class StringHelpers
{
    public static string GetLastCharacters(this string text, int charactersCount)
    {
        int length = text.Length;
        int offset = Math.Max(0, length - charactersCount);
        return text[offset..];
    }
    
    public static string GetFirstCharacters(this string text, int charactersCount)
    {
        int length = text.Length;
        int offset = Math.Min(charactersCount, text.Length);
        return text[..offset];
    }
}