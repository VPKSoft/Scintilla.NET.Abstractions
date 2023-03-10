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

using ScintillaNet.Abstractions.Interfaces.EventArguments.Base;

namespace ScintillaNet.Abstractions.Interfaces.EventArguments;

/// <summary>
/// Provides data for the Scintilla.AutoCSelectionChange event.
/// </summary>
public interface IAutoCSelectionChangeEventArgs : IBytePosition
{
    /// <summary>
    /// Gets the list type of the user list or 0 for an auto-completion.
    /// </summary>
    /// <returns>The list type of the user list or 0 for an auto-completion.</returns>
    int ListType { get; }

    /// <summary>
    /// Gets the position where the list was displayed at.
    /// </summary>
    /// <returns>The zero-based document position where the list was displayed.</returns>
    int Position { get; }

    /// <summary>
    /// Gets the text of the selected auto-completion item.
    /// </summary>
    /// <returns>The selected auto-completion item text.</returns>
    string Text { get; }
}