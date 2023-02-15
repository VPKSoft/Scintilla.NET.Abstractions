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

using ScintillaNet.Abstractions.Interfaces.Collections;
using ScintillaNet.Abstractions.Interfaces.EventArguments;
using ScintillaNet.Abstractions.Interfaces.EventArguments.Base;

namespace ScintillaNet.Abstractions.EventArguments;

/// <summary>
/// Provides data for the Scintilla.AutoCSelectionChange event.
/// </summary>
public class AutoCSelectionChangeEventArgsBase : ScintillaEventArgs, IAutoCSelectionChangeEventArgs, IPosition
{
    /// <summary>
    /// Gets the pointer to the selected auto-completion text.
    /// </summary>
    public IntPtr TextPtr { get; }

    /// <summary>
    /// Gets the zero-based byte position within the document where the list was displayed.
    /// </summary>
    public int BytePosition { get; }

    /// <summary>
    /// Gets the line collection general members.
    /// </summary>
    /// <value>The line collection  general members.</value>
    public IScintillaLineCollectionGeneral LineCollectionGeneral { get; }

    private int? position;
    private string? text;

    /// <summary>
    /// Gets the list type of the user list or 0 for an auto-completion.
    /// </summary>
    /// <returns>The list type of the user list or 0 for an auto-completion.</returns>
    public int ListType { get; }

    /// <summary>
    /// Gets the position where the list was displayed at.
    /// </summary>
    /// <returns>The zero-based document position where the list was displayed.</returns>
    public int Position
    {
        get
        {
            position ??= LineCollectionGeneral.ByteToCharPosition(BytePosition);

            return (int)position;
        }
    }

    /// <summary>
    /// Gets the text of the selected auto-completion item.
    /// </summary>
    /// <returns>The selected auto-completion item text.</returns>
    public unsafe string Text
    {
        get
        {
            if (text == null)
            {
                var len = 0;
                while (((byte*)TextPtr)[len] != 0)
                {
                    len++;
                }

                text = HelpersGeneral.GetString(TextPtr, len, ScintillaApi.Encoding);
            }

            return text;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AutoCSelectionChangeEventArgsBase" /> class.
    /// </summary>
    /// <param name="scintilla">The <see cref="scintilla" /> control that generated this event.</param>
    /// <param name="lineCollectionGeneral">A reference to Scintilla's line collection.</param>/// 
    /// <param name="text">A pointer to the selected auto-completion text.</param>
    /// <param name="bytePosition">The zero-based byte position within the document where the list was displayed.</param>
    /// <param name="listType">The list type of the user list, or 0 for an auto-completion.</param>
    protected AutoCSelectionChangeEventArgsBase(IScintillaApi scintilla, 
        IScintillaLineCollectionGeneral lineCollectionGeneral,
        IntPtr text, 
        int bytePosition, 
        int listType) : base(scintilla)
    {
        LineCollectionGeneral = lineCollectionGeneral;
        TextPtr = text;
        BytePosition = bytePosition;
        ListType = listType;
    }
}