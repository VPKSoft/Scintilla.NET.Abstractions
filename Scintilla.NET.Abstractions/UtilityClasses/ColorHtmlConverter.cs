#region License
/*
MIT License

Copyright(c) 2023 Petteri Kautonen

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion

using System.Globalization;

namespace ScintillaNet.Abstractions.UtilityClasses;

/// <summary>
/// An utility class to convert colors to HTML format and from HTML format.
/// </summary>
public static class ColorHtmlConverter
{
    /// <summary>
    /// Converts the specified HTML color to <see cref="int"/>.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The specified value converted into <see cref="int"/>.</returns>
    /// <exception cref="ArgumentException">The value must be a HTML color code.</exception>
    public static int HtmlColorToInt(string value)
    {
        if (!value.StartsWith("#"))
        {
            throw new ArgumentException("The value must be a HTML color code.");
        }

        value = value[1..];

        try
        {
            var r = int.Parse(value[..2], NumberStyles.HexNumber);
            var g = int.Parse(value[2..4], NumberStyles.HexNumber) << 8;
            var b = int.Parse(value[4..6], NumberStyles.HexNumber) << 16;
            var intColor = r | g | b | (255 << 24); // 255 for full opacity.
            return intColor;
        }
        catch
        {
            throw new ArgumentException("The value must be a HTML color code.");
        }
    }

    /// <summary>
    /// Converts the specified integer color value to HTML color string.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The specified value converted into <see cref="string"/> representing the HTML color.</returns>
    public static string IntToHtmlColor(int value)
    {
        var b = (value >> 16) & 0xFF;
        var g = (value >> 8) & 0xFF;
        var r = value & 0xFF;

        return $"#{r:X2}{g:X2}{b:X2}".ToLowerInvariant();
    }
}