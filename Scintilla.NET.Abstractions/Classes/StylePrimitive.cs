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
using ScintillaNet.Abstractions.Collections;
using ScintillaNet.Abstractions.Interfaces.Collections;
using ScintillaNet.Abstractions.UtilityClasses;

namespace ScintillaNet.Abstractions.Classes;

/// <summary>
/// A style definition in a Scintilla control with only primitive members.
/// </summary>
public class StylePrimitive : StyleBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StylePrimitive"/> class.
    /// </summary>
    /// <param name="scintilla">The scintilla.</param>
    /// <param name="index">The index.</param>
    public StylePrimitive(IScintillaApi scintilla, int index) : base(scintilla, index)
    {
    }

    /// <summary>
    /// Gets or sets the background color of the style.
    /// </summary>
    /// <returns>A string representing the style background color. The default is White. The color is in HTML format.</returns>
    /// <remarks>Alpha color values are ignored.</remarks>
    public string BackColor 
    {
        get
        {
            var color = ScintillaApi.DirectMessage(ScintillaConstants.SCI_STYLEGETBACK, new IntPtr(Index), IntPtr.Zero).ToInt32();
            return ColorHtmlConverter.IntToHtmlColor(color);
        }
        set
        {
            var color = ColorHtmlConverter.HtmlColorToInt(value);
            ScintillaApi.DirectMessage(ScintillaConstants.SCI_STYLESETBACK, new IntPtr(Index), new IntPtr(color));
        }
    }

    /// <inheritdoc cref="IScintillaStyle{TColor}.ForeColor"/>
    public string ForeColor
    {
        get
        {
            var color = ScintillaApi.DirectMessage(ScintillaConstants.SCI_STYLEGETFORE, new IntPtr(Index), IntPtr.Zero).ToInt32();
            return ColorHtmlConverter.IntToHtmlColor(color);
        }
        set
        {
            var color = ColorHtmlConverter.HtmlColorToInt(value);
            ScintillaApi.DirectMessage(ScintillaConstants.SCI_STYLESETFORE, new IntPtr(Index), new IntPtr(color));
        }
    }
}