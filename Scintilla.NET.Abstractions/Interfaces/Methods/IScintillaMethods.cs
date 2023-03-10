#region License
/*
MIT License

Copyright(c) 2022 Petteri Kautonen

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

using ScintillaNet.Abstractions.Classes;
using ScintillaNet.Abstractions.Collections;
using ScintillaNet.Abstractions.Enumerations;
using ScintillaNet.Abstractions.Structs;

namespace ScintillaNet.Abstractions.Interfaces.Methods;

/// <summary>
/// Interface for Scintilla control methods without generic types.
/// </summary>
public interface IScintillaMethods
{
        /// <summary>
    /// Increases the reference count of the specified document by 1.
    /// </summary>
    /// <param name="document">The document reference count to increase.</param>
    void AddRefDocument(Document document);

    /// <summary>
    /// Adds an additional selection range to the existing main selection.
    /// </summary>
    /// <param name="caret">The zero-based document position to end the selection.</param>
    /// <param name="anchor">The zero-based document position to start the selection.</param>
    /// <remarks>A main selection must first have been set by a call to <see cref="SetSelection" />.</remarks>
    void AddSelection(int caret, int anchor);

    /// <summary>
    /// Inserts the specified text at the current caret position.
    /// </summary>
    /// <param name="text">The text to insert at the current caret position.</param>
    /// <remarks>The caret position is set to the end of the inserted text, but it is not scrolled into view.</remarks>
    void AddText(string text);

    /// <summary>
    /// Allocates some number of sub-styles for a particular base style. Substyles are allocated contiguously.
    /// </summary>
    /// <param name="styleBase">The lexer style integer</param>
    /// <param name="numberStyles">The amount of sub-styles to allocate</param>
    /// <returns>Returns the first sub-style number allocated.</returns>
    int AllocateSubStyles(int styleBase, int numberStyles);

    /// <summary>
    /// Removes the annotation text for every <see cref="LineBase" /> in the document.
    /// </summary>
    void AnnotationClearAll();

    /// <summary>
    /// Adds the specified text to the end of the document.
    /// </summary>
    /// <param name="text">The text to add to the document.</param>
    /// <remarks>The current selection is not changed and the new text is not scrolled into view.</remarks>
    void AppendText(string text);

    /// <summary>
    /// Cancels any displayed auto-completion list.
    /// </summary>
    /// <seealso cref="AutoCStops" />
    void AutoCCancel();

    /// <summary>
    /// Triggers completion of the current auto-completion word.
    /// </summary>
    void AutoCComplete();

    /// <summary>
    /// Selects an item in the auto-completion list.
    /// </summary>
    /// <param name="select">
    /// The auto-completion word to select.
    /// If found, the word in the auto-completion list is selected and the index can be obtained by calling <see cref="IScintillaProperties.AutoCCurrent" />.
    /// If not found, the behavior is determined by <see cref="IScintillaProperties.AutoCAutoHide" />.
    /// </param>
    /// <remarks>
    /// Comparisons are performed according to the <see cref="IScintillaProperties.AutoCIgnoreCase" /> property
    /// and will match the first word starting with <paramref name="select" />.
    /// </remarks>
    /// <seealso cref="IScintillaProperties.AutoCCurrent" />
    /// <seealso cref="IScintillaProperties.AutoCAutoHide" />
    /// <seealso cref="IScintillaProperties.AutoCIgnoreCase" />
    void AutoCSelect(string select);

    /// <summary>
    /// Sets the characters that, when typed, cause the auto-completion item to be added to the document.
    /// </summary>
    /// <param name="chars">A string of characters that trigger auto-completion. The default is null.</param>
    /// <remarks>Common fillup characters are '(', '[', and '.' depending on the language.</remarks>
    void AutoCSetFillUps(string chars);

    /// <summary>
    /// Displays an auto completion list.
    /// </summary>
    /// <param name="lenEntered">The number of characters already entered to match on.</param>
    /// <param name="list">A list of auto-completion words separated by the <see cref="IScintillaProperties.AutoCSeparator" /> character.</param>
    void AutoCShow(int lenEntered, string list);

    /// <summary>
    /// Specifies the characters that will automatically cancel auto-completion without the need to call <see cref="AutoCCancel" />.
    /// </summary>
    /// <param name="chars">A String of the characters that will cancel auto-completion. The default is empty.</param>
    /// <remarks>Characters specified should be limited to printable ASCII characters.</remarks>
    void AutoCStops(string chars);

    /// <summary>
    /// Marks the beginning of a set of actions that should be treated as a single undo action.
    /// </summary>
    /// <remarks>A call to <see cref="BeginUndoAction" /> should be followed by a call to <see cref="EndUndoAction" />.</remarks>
    /// <seealso cref="EndUndoAction" />
    void BeginUndoAction();

    /// <summary>
    /// Styles the specified character position with the <see cref="StyleConstants.BraceBad" /> style when there is an unmatched brace.
    /// </summary>
    /// <param name="position">The zero-based document position of the unmatched brace character or <seealso cref="ApiConstants.InvalidPosition"/> to remove the highlight.</param>
    void BraceBadLight(int position);

    /// <summary>
    /// Styles the specified character positions with the <see cref="StyleConstants.BraceLight" /> style.
    /// </summary>
    /// <param name="position1">The zero-based document position of the open brace character.</param>
    /// <param name="position2">The zero-based document position of the close brace character.</param>
    /// <remarks>Brace highlighting can be removed by specifying <see cref="ApiConstants.InvalidPosition" /> for <paramref name="position1" /> and <paramref name="position2" />.</remarks>
    /// <seealso cref="IScintillaProperties.HighlightGuide" />
    void BraceHighlight(int position1, int position2);

    /// <summary>
    /// Finds a corresponding matching brace starting at the position specified.
    /// The brace characters handled are '(', ')', '[', ']', '{', '}', '&lt;', and '&gt;'.
    /// </summary>
    /// <param name="position">The zero-based document position of a brace character to start the search from for a matching brace character.</param>
    /// <returns>The zero-based document position of the corresponding matching brace or <see cref="ApiConstants.InvalidPosition" /> it no matching brace could be found.</returns>
    /// <remarks>A match only occurs if the style of the matching brace is the same as the starting brace. Nested braces are handled correctly.</remarks>
    int BraceMatch(int position);

    /// <summary>
    /// Cancels the display of a call tip window.
    /// </summary>
    void CallTipCancel();

    /// <summary>
    /// Sets the specified range of the call tip text to display in a highlighted style.
    /// </summary>
    /// <param name="hlStart">The zero-based index in the call tip text to start highlighting.</param>
    /// <param name="hlEnd">The zero-based index in the call tip text to stop highlighting (exclusive).</param>
    void CallTipSetHlt(int hlStart, int hlEnd);

    /// <summary>
    /// Determines whether to display a call tip above or below text.
    /// </summary>
    /// <param name="above">true to display above text; otherwise, false. The default is false.</param>
    void CallTipSetPosition(bool above);

    /// <summary>
    /// Displays a call tip window.
    /// </summary>
    /// <param name="posStart">The zero-based document position where the call tip window should be aligned.</param>
    /// <param name="definition">The call tip text.</param>
    /// <remarks>
    /// Call tips can contain multiple lines separated by '\n' characters. Do not include '\r', as this will most likely print as an empty box.
    /// The '\t' character is supported and the size can be set by using <see cref="CallTipTabSize" />.
    /// </remarks>
    void CallTipShow(int posStart, string definition);

    /// <summary>
    /// Sets the call tip tab size in pixels.
    /// </summary>
    /// <param name="tabSize">The width in pixels of a tab '\t' character in a call tip. Specifying 0 disables special treatment of tabs.</param>
    void CallTipTabSize(int tabSize);

    /// <summary>
    /// Indicates to the current <see cref="Lexer" /> that the internal lexer state has changed in the specified
    /// range and therefore may need to be redrawn.
    /// </summary>
    /// <param name="startPos">The zero-based document position at which the lexer state change starts.</param>
    /// <param name="endPos">The zero-based document position at which the lexer state change ends.</param>
    void ChangeLexerState(int startPos, int endPos);

    /// <summary>
    /// Finds the closest character position to the specified display point.
    /// </summary>
    /// <param name="x">The x pixel coordinate within the client rectangle of the control.</param>
    /// <param name="y">The y pixel coordinate within the client rectangle of the control.</param>
    /// <returns>The zero-based document position of the nearest character to the point specified.</returns>
    int CharPositionFromPoint(int x, int y);

    /// <summary>
    /// Finds the closest character position to the specified display point or returns -1
    /// if the point is outside the window or not close to any characters.
    /// </summary>
    /// <param name="x">The x pixel coordinate within the client rectangle of the control.</param>
    /// <param name="y">The y pixel coordinate within the client rectangle of the control.</param>
    /// <returns>The zero-based document position of the nearest character to the point specified when near a character; otherwise, -1.</returns>
    int CharPositionFromPointClose(int x, int y);

    /// <summary>
    /// Explicitly sets the current horizontal offset of the caret as the X position to track
    /// when the user moves the caret vertically using the up and down keys.
    /// </summary>
    /// <remarks>
    /// When not set explicitly, Scintilla automatically sets this value each time the user moves
    /// the caret horizontally.
    /// </remarks>
    void ChooseCaretX();

    /// <summary>
    /// Removes the selected text from the document.
    /// </summary>
    void Clear();

    /// <summary>
    /// Deletes all document text, unless the document is read-only.
    /// </summary>
    void ClearAll();

    /// <summary>
    /// Removes all the key definition command mappings.
    /// </summary>
    void ClearAllCmdKeys();

    /// <summary>
    /// Removes all styling from the document and resets the folding state.
    /// </summary>
    void ClearDocumentStyle();

    /// <summary>
    /// Removes all images registered for auto-completion lists.
    /// </summary>
    void ClearRegisteredImages();

    /// <summary>
    /// Sets a single empty selection at the start of the document.
    /// </summary>
    void ClearSelections();

    /// <summary>
    /// Requests that the current lexer restyle the specified range.
    /// </summary>
    /// <param name="startPos">The zero-based document position at which to start styling.</param>
    /// <param name="endPos">The zero-based document position at which to stop styling (exclusive).</param>
    /// <remarks>This will also cause fold levels in the range specified to be reset.</remarks>
    void Colorize(int startPos, int endPos);

    /// <summary>
    /// Changes all end-of-line characters in the document to the format specified.
    /// </summary>
    /// <param name="eolMode">One of the <see cref="Eol" /> enumeration values.</param>
    void ConvertEols(Eol eolMode);

    /// <summary>
    /// Copies the selected text from the document and places it on the clipboard.
    /// </summary>
    void Copy();

    /// <summary>
    /// Copies the selected text from the document and places it on the clipboard.
    /// </summary>
    /// <param name="format">One of the <see cref="CopyFormat" /> enumeration values.</param>
    void Copy(CopyFormat format);

    /// <summary>
    /// Copies the selected text from the document and places it on the clipboard.
    /// If the selection is empty the current line is copied.
    /// </summary>
    /// <remarks>
    /// If the selection is empty and the current line copied, an extra "MSDEVLineSelect" marker is added to the
    /// clipboard which is then used in <see cref="Paste" /> to paste the whole line before the current line.
    /// </remarks>
    void CopyAllowLine();

    /// <summary>
    /// Copies the selected text from the document and places it on the clipboard.
    /// If the selection is empty the current line is copied.
    /// </summary>
    /// <param name="format">One of the <see cref="CopyFormat" /> enumeration values.</param>
    /// <remarks>
    /// If the selection is empty and the current line copied, an extra "MSDEVLineSelect" marker is added to the
    /// clipboard which is then used in <see cref="Paste" /> to paste the whole line before the current line.
    /// </remarks>
    void CopyAllowLine(CopyFormat format)
;

    /// <summary>
    /// Copies the specified range of text to the clipboard.
    /// </summary>
    /// <param name="start">The zero-based character position in the document to start copying.</param>
    /// <param name="end">The zero-based character position (exclusive) in the document to stop copying.</param>
    void CopyRange(int start, int end)
;

    /// <summary>
    /// Copies the specified range of text to the clipboard.
    /// </summary>
    /// <param name="start">The zero-based character position in the document to start copying.</param>
    /// <param name="end">The zero-based character position (exclusive) in the document to stop copying.</param>
    /// <param name="format">One of the <see cref="CopyFormat" /> enumeration values.</param>
    void CopyRange(int start, int end, CopyFormat format)
;

    /// <summary>
    /// Create a new, empty document.
    /// </summary>
    /// <returns>A new <see cref="Document" /> with a reference count of 1.</returns>
    /// <remarks>You are responsible for ensuring the reference count eventually reaches 0 or memory leaks will occur.</remarks>
    Document CreateDocument();

    /// <summary>
    /// Creates an <see cref="ILoader" /> object capable of loading a <see cref="Document" /> on a background (non-UI) thread.
    /// </summary>
    /// <param name="length">The initial number of characters to allocate.</param>
    /// <returns>A new <see cref="ILoader" /> object, or null if the loader could not be created.</returns>
    ILoader CreateLoader(int length);

    /// <summary>
    /// Cuts the selected text from the document and places it on the clipboard.
    /// </summary>
    void Cut();

    /// <summary>
    /// Deletes a range of text from the document.
    /// </summary>
    /// <param name="position">The zero-based character position to start deleting.</param>
    /// <param name="length">The number of characters to delete.</param>
    void DeleteRange(int position, int length);

    /// <summary>
    /// Retrieves a description of keyword sets supported by the current <see cref="Lexer" />.
    /// </summary>
    /// <returns>A String describing each keyword set separated by line breaks for the current lexer.</returns>
    string DescribeKeywordSets();

    /// <summary>
    /// Retrieves a brief description of the specified property name for the current <see cref="Lexer" />.
    /// </summary>
    /// <param name="name">A property name supported by the current <see cref="Lexer" />.</param>
    /// <returns>A String describing the lexer property name if found; otherwise, String.Empty.</returns>
    /// <remarks>A list of supported property names for the current <see cref="Lexer" /> can be obtained by calling <see cref="PropertyNames" />.</remarks>
    string DescribeProperty(string name);


    /// <summary>
    /// Returns the zero-based document line index from the specified display line index.
    /// </summary>
    /// <param name="displayLine">The zero-based display line index.</param>
    /// <returns>The zero-based document line index.</returns>
    /// <seealso cref="LineBase.DisplayIndex" />
    int DocLineFromVisible(int displayLine);

    /// <summary>
    /// If there are multiple selections, removes the specified selection.
    /// </summary>
    /// <param name="selection">The zero-based selection index.</param>
    /// <seealso cref="IScintillaCollectionProperties{TMarkers,TStyles,TIndicators,TLines,TMargins,TSelections,TMarker,TStyle,TIndicator,TLine,TMargin,TSelection,TBitmap,TColor}.Selections" />
    void DropSelection(int selection);

    /// <summary>
    /// Clears any undo or redo history.
    /// </summary>
    /// <remarks>This will also cause <see cref="IScintillaEvents.SavePointReached" /> event.</remarks>
    void EmptyUndoBuffer();

    /// <summary>
    /// Marks the end of a set of actions that should be treated as a single undo action.
    /// </summary>
    /// <seealso cref="BeginUndoAction" />
    void EndUndoAction();

    /// <summary>
    /// Performs the specified Scintilla >command.
    /// </summary>
    /// <param name="sciCommand">The command to perform.</param>
    void ExecuteCmd(Command sciCommand);

    /// <summary>
    /// Changes the appearance of fold text tags.
    /// </summary>
    /// <param name="style">One of the <see cref="FoldDisplayText" /> enumeration values.</param>
    /// <remarks>The text tag to display on a folded line can be set using <see cref="LineBase.ToggleFoldShowText" />.</remarks>
    /// <seealso cref="LineBase.ToggleFoldShowText" />.
    void FoldDisplayTextSetStyle(FoldDisplayText style);

    /// <summary>
    /// Frees all allocated sub-styles.
    /// </summary>
    void FreeSubStyles();

    /// <summary>
    /// Returns the character as the specified document position.
    /// </summary>
    /// <param name="position">The zero-based document position of the character to get.</param>
    /// <returns>The character at the specified <paramref name="position" />.</returns>
    int GetCharAt(int position);

    /// <summary>
    /// Returns the column number of the specified document position, taking the width of tabs into account.
    /// </summary>
    /// <param name="position">The zero-based document position to get the column for.</param>
    /// <returns>The number of columns from the start of the line to the specified document <paramref name="position" />.</returns>
    int GetColumn(int position);

    /// <summary>
    /// Returns the last document position likely to be styled correctly.
    /// </summary>
    /// <returns>The zero-based document position of the last styled character.</returns>
    int GetEndStyled();

    /// <summary>
    /// Gets the Primary style associated with the given Secondary style.
    /// </summary>
    /// <param name="style">The secondary style</param>
    /// <returns>For a secondary style, return the primary style, else return the argument.</returns>
    int GetPrimaryStyleFromStyle(int style);

    /// <summary>
    /// Lookup a property value for the current <see cref="Lexer" />.
    /// </summary>
    /// <param name="name">The property name to lookup.</param>
    /// <returns>
    /// A String representing the property value if found; otherwise, String.Empty.
    /// Any embedded property name macros as described in <see cref="SetProperty" /> will not be replaced (expanded).
    /// </returns>
    /// <seealso cref="GetPropertyExpanded" />
    string GetScintillaProperty(string name);

    /// <summary>
    /// Lookup a property value for the current <see cref="Lexer" /> and expand any embedded property macros.
    /// </summary>
    /// <param name="name">The property name to lookup.</param>
    /// <returns>
    /// A String representing the property value if found; otherwise, String.Empty.
    /// Any embedded property name macros as described in <see cref="SetProperty" /> will be replaced (expanded).
    /// </returns>
    /// <seealso cref="GetScintillaProperty" />
    string GetPropertyExpanded(string name);

    /// <summary>
    /// Lookup a property value for the current <see cref="Lexer" /> and convert it to an integer.
    /// </summary>
    /// <param name="name">The property name to lookup.</param>
    /// <param name="defaultValue">A default value to return if the property name is not found or has no value.</param>
    /// <returns>
    /// An Integer representing the property value if found;
    /// otherwise, <paramref name="defaultValue" /> if not found or the property has no value;
    /// otherwise, 0 if the property is not a number.
    /// </returns>
    int GetPropertyInt(string name, int defaultValue);

    /// <summary>
    /// Gets the style of the specified document position.
    /// </summary>
    /// <param name="position">The zero-based document position of the character to get the style for.</param>
    /// <returns>The zero-based <see cref="StyleBase{TColor}" /> index used at the specified <paramref name="position" />.</returns>
    int GetStyleAt(int position);

    /// <summary>
    /// Gets the lexer base style of a sub-style.
    /// </summary>
    /// <param name="subStyle">The integer index of the sub-style</param>
    /// <returns>Returns the base style, else returns the argument.</returns>
    int GetStyleFromSubStyle(int subStyle);

    /// <summary>
    /// Gets the length of the number of sub-styles allocated for a given lexer base style.
    /// </summary>
    /// <param name="styleBase">The lexer style integer</param>
    /// <returns>Returns the length of the sub-styles allocated for a base style.</returns>
    int GetSubStylesLength(int styleBase);

    /// <summary>
    /// Gets the start index of the sub-styles for a given lexer base style.
    /// </summary>
    /// <param name="styleBase">The lexer style integer</param>
    /// <returns>Returns the start of the sub-styles allocated for a base style.</returns>
    int GetSubStylesStart(int styleBase);

    /// <summary>
    /// Returns the capture group text of the most recent regular expression search.
    /// </summary>
    /// <param name="tagNumber">The capture group (1 through 9) to get the text for.</param>
    /// <returns>A String containing the capture group text if it participated in the match; otherwise, an empty string.</returns>
    /// <seealso cref="SearchInTarget" />
    string GetTag(int tagNumber);

    /// <summary>
    /// Gets a range of text from the document formatted as Hypertext Markup Language (HTML).
    /// </summary>
    /// <param name="position">The zero-based starting character position of the range to get.</param>
    /// <param name="length">The number of characters to get.</param>
    /// <returns>A string representing the text range formatted as HTML.</returns>
    string GetTextRangeAsHtml(int position, int length);

    ///<summary>
    /// Gets the word from the position specified.
    /// </summary>
    /// <param name="position">The zero-based document character position to get the word from.</param>
    /// <returns>The word at the specified position.</returns>
    string GetWordFromPosition(int position);

    /// <summary>
    /// Navigates the caret to the document position specified.
    /// </summary>
    /// <param name="position">The zero-based document character position to navigate to.</param>
    /// <remarks>Any selection is discarded.</remarks>
    void GotoPosition(int position);

    /// <summary>
    /// Hides the range of lines specified.
    /// </summary>
    /// <param name="lineStart">The zero-based index of the line range to start hiding.</param>
    /// <param name="lineEnd">The zero-based index of the line range to end hiding.</param>
    /// <seealso cref="ShowLines" />
    /// <seealso cref="LineBase.Visible" />
    void HideLines(int lineStart, int lineEnd);

    /// <summary>
    /// Returns a bitmap representing the 32 indicators in use at the specified position.
    /// </summary>
    /// <param name="position">The zero-based character position within the document to test.</param>
    /// <returns>A bitmap indicating which of the 32 indicators are in use at the specified <paramref name="position" />.</returns>
    uint IndicatorAllOnFor(int position);

    /// <summary>
    /// Removes the <see cref="IScintillaProperties.IndicatorCurrent" /> indicator (and user-defined value) from the specified range of text.
    /// </summary>
    /// <param name="position">The zero-based character position within the document to start clearing.</param>
    /// <param name="length">The number of characters to clear.</param>
    void IndicatorClearRange(int position, int length);

    /// <summary>
    /// Adds the <see cref="IScintillaProperties.IndicatorCurrent" /> indicator and <see cref="IScintillaProperties.IndicatorValue" /> value to the specified range of text.
    /// </summary>
    /// <param name="position">The zero-based character position within the document to start filling.</param>
    /// <param name="length">The number of characters to fill.</param>
    void IndicatorFillRange(int position, int length);

    /// <summary>
    /// Inserts text at the specified position.
    /// </summary>
    /// <param name="position">The zero-based character position to insert the text. Specify -1 to use the current caret position.</param>
    /// <param name="text">The text to insert into the document.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="position" /> less than zero and not equal to -1. -or-
    /// <paramref name="position" /> is greater than the document length.
    /// </exception>
    /// <remarks>No scrolling is performed.</remarks>
    void InsertText(int position, string text);

    /// <summary>
    /// Determines whether the specified <paramref name="start" /> and <paramref name="end" /> positions are
    /// at the beginning and end of a word, respectively.
    /// </summary>
    /// <param name="start">The zero-based document position of the possible word start.</param>
    /// <param name="end">The zero-based document position of the possible word end.</param>
    /// <returns>
    /// true if <paramref name="start" /> and <paramref name="end" /> are at the beginning and end of a word, respectively;
    /// otherwise, false.
    /// </returns>
    /// <remarks>
    /// This method does not check whether there is whitespace in the search range,
    /// only that the <paramref name="start" /> and <paramref name="end" /> are at word boundaries.
    /// </remarks>
    bool IsRangeWord(int start, int end);

    /// <summary>
    /// Returns the line that contains the document position specified.
    /// </summary>
    /// <param name="position">The zero-based document character position.</param>
    /// <returns>The zero-based document line index containing the character <paramref name="position" />.</returns>
    int LineFromPosition(int position);

    /// <summary>
    /// Scrolls the display the number of lines and columns specified.
    /// </summary>
    /// <param name="lines">The number of lines to scroll.</param>
    /// <param name="columns">The number of columns to scroll.</param>
    /// <remarks>
    /// Negative values scroll in the opposite direction.
    /// A column is the width in pixels of a space character in the <see cref="StyleConstants.Default" /> style.
    /// </remarks>
    void LineScroll(int lines, int columns);

    /// <summary>
    /// Loads a Scintilla compatible lexer from an external DLL.
    /// </summary>
    /// <param name="path">The path to the external lexer DLL.</param>
    void LoadLexerLibrary(string path);

    /// <summary>
    /// Searches the document for the marker handle and deletes the marker if found.
    /// </summary>
    /// <param name="markerHandle">The <see cref="MarkerHandle" /> created by a previous call to <see cref="LineBase.MarkerAdd" /> of the marker to delete.</param>
    void MarkerDeleteHandle(MarkerHandle markerHandle);

    /// <summary>
    /// Enable or disable highlighting of the current folding block.
    /// </summary>
    /// <param name="enabled">true to highlight the current folding block; otherwise, false.</param>
    void MarkerEnableHighlight(bool enabled);

    /// <summary>
    /// Searches the document for the marker handle and returns the line number containing the marker if found.
    /// </summary>
    /// <param name="markerHandle">The <see cref="MarkerHandle" /> created by a previous call to <see cref="LineBase.MarkerAdd" /> of the marker to search for.</param>
    /// <returns>If found, the zero-based line index containing the marker; otherwise, -1.</returns>
    int MarkerLineFromHandle(MarkerHandle markerHandle);

    /// <summary>
    /// Removes all the long line column indicators specified using <seealso cref="IScintillaMethodsColor{TColor}.MultiEdgeAddLine" />.
    /// </summary>
    /// <seealso cref="IScintillaMethodsColor{TColor}.MultiEdgeAddLine" />
    void MultiEdgeClearAll();

    /// <summary>
    /// Searches for all instances of the main selection within the <see cref="IScintillaProperties.TargetStart" /> and <see cref="IScintillaProperties.TargetEnd" />
    /// range and adds any matches to the selection.
    /// </summary>
    /// <remarks>
    /// The <see cref="SearchFlags" /> property is respected when searching, allowing additional
    /// selections to match on different case sensitivity and word search options.
    /// </remarks>
    /// <seealso cref="MultipleSelectAddNext" />
    void MultipleSelectAddEach();

    /// <summary>
    /// Searches for the next instance of the main selection within the <see cref="IScintillaProperties.TargetStart" /> and <see cref="IScintillaProperties.TargetEnd" />
    /// range and adds any match to the selection.
    /// </summary>
    /// <remarks>
    /// The <see cref="SearchFlags" /> property is respected when searching, allowing additional
    /// selections to match on different case sensitivity and word search options.
    /// </remarks>
    /// <seealso cref="MultipleSelectAddNext" />
    void MultipleSelectAddNext();

    /// <summary>
    /// Pastes the contents of the clipboard into the current selection.
    /// </summary>
    void Paste();

    /// <summary>
    /// Returns the X display pixel location of the specified document position.
    /// </summary>
    /// <param name="pos">The zero-based document character position.</param>
    /// <returns>The x-coordinate of the specified <paramref name="pos" /> within the client rectangle of the control.</returns>
    int PointXFromPosition(int pos);

    /// <summary>
    /// Returns the Y display pixel location of the specified document position.
    /// </summary>
    /// <param name="pos">The zero-based document character position.</param>
    /// <returns>The y-coordinate of the specified <paramref name="pos" /> within the client rectangle of the control.</returns>
    int PointYFromPosition(int pos);

    /// <summary>
    /// Retrieves a list of property names that can be set for the current <see cref="Lexer" />.
    /// </summary>
    /// <returns>A String of property names separated by line breaks.</returns>
    string PropertyNames();
    
    /// <summary>
    /// Retrieves the data type of the specified property name for the current <see cref="Lexer" />.
    /// </summary>
    /// <param name="name">A property name supported by the current <see cref="Lexer" />.</param>
    /// <returns>One of the <see cref="PropertyType" /> enumeration values. The default is <see cref="bool" />.</returns>
    /// <remarks>A list of supported property names for the current <see cref="Lexer" /> can be obtained by calling <see cref="PropertyNames" />.</remarks>
    PropertyType PropertyType(string name);

    /// <summary>
    /// Redoes the effect of an <see cref="Undo" /> operation.
    /// </summary>
    void Redo();

    /// <summary>
    /// Decreases the reference count of the specified document by 1.
    /// </summary>
    /// <param name="document">
    /// The document reference count to decrease.
    /// When a document's reference count reaches 0 it is destroyed and any associated memory released.
    /// </param>
    void ReleaseDocument(Document document)
;

    /// <summary>
    /// Replaces the current selection with the specified text.
    /// </summary>
    /// <param name="text">The text that should replace the current selection.</param>
    /// <remarks>
    /// If there is not a current selection, the text will be inserted at the current caret position.
    /// Following the operation the caret is placed at the end of the inserted text and scrolled into view.
    /// </remarks>
    void ReplaceSelection(string text)
;

    /// <summary>
    /// Replaces the target defined by <see cref="IScintillaProperties.TargetStart" /> and <see cref="IScintillaProperties.TargetEnd" /> with the specified <paramref name="text" />.
    /// </summary>
    /// <param name="text">The text that will replace the current target.</param>
    /// <returns>The length of the replaced text.</returns>
    /// <remarks>
    /// The <see cref="IScintillaProperties.TargetStart" /> and <see cref="IScintillaProperties.TargetEnd" /> properties will be updated to the start and end positions of the replaced text.
    /// The recommended way to delete text in the document is to set the target range to be removed and replace the target with an empty string.
    /// </remarks>
    int ReplaceTarget(string text)
;

    /// <summary>
    /// Replaces the target text defined by <see cref="IScintillaProperties.TargetStart" /> and <see cref="IScintillaProperties.TargetEnd" /> with the specified value after first substituting
    /// "\1" through "\9" macros in the <paramref name="text" /> with the most recent regular expression capture groups.
    /// </summary>
    /// <param name="text">The text containing "\n" macros that will be substituted with the most recent regular expression capture groups and then replace the current target.</param>
    /// <returns>The length of the replaced text.</returns>
    /// <remarks>
    /// The "\0" macro will be substituted by the entire matched text from the most recent search.
    /// The <see cref="IScintillaProperties.TargetStart" /> and <see cref="IScintillaProperties.TargetEnd" /> properties will be updated to the start and end positions of the replaced text.
    /// </remarks>
    /// <seealso cref="GetTag" />
    int ReplaceTargetRe(string text);


    /// <summary>
    /// Makes the next selection the main selection.
    /// </summary>
    void RotateSelection();

    /// <summary>
    /// Scrolls the current position into view, if it is not already visible.
    /// </summary>
    void ScrollCaret();

    /// <summary>
    /// Scrolls the specified range into view.
    /// </summary>
    /// <param name="start">The zero-based document start position to scroll to.</param>
    /// <param name="end">
    /// The zero-based document end position to scroll to if doing so does not cause the <paramref name="start" />
    /// position to scroll out of view.
    /// </param>
    /// <remarks>This may be used to make a search match visible.</remarks>
    void ScrollRange(int start, int end);

    /// <summary>
    /// Searches for the first occurrence of the specified text in the target defined by <see cref="IScintillaProperties.TargetStart" /> and <see cref="IScintillaProperties.TargetEnd" />.
    /// </summary>
    /// <param name="text">The text to search for. The interpretation of the text (i.e. whether it is a regular expression) is defined by the <see cref="SearchFlags" /> property.</param>
    /// <returns>The zero-based start position of the matched text within the document if successful; otherwise, -1.</returns>
    /// <remarks>
    /// If successful, the <see cref="IScintillaProperties.TargetStart" /> and <see cref="IScintillaProperties.TargetEnd" /> properties will be updated to the start and end positions of the matched text.
    /// Searching can be performed in reverse using a <see cref="IScintillaProperties.TargetStart" /> greater than the <see cref="IScintillaProperties.TargetEnd" />.
    /// </remarks>
    int SearchInTarget(string text);

    /// <summary>
    /// Selects all the text in the document.
    /// </summary>
    /// <remarks>The current position is not scrolled into view.</remarks>
    void SelectAll();

    /// <summary>
    /// Removes any selection and places the caret at the specified position.
    /// </summary>
    /// <param name="pos">The zero-based document position to place the caret at.</param>
    /// <remarks>The caret is not scrolled into view.</remarks>
    void SetEmptySelection(int pos);

    /// <summary>
    /// Sets the X caret policy.
    /// </summary>
    /// <param name="caretPolicy">a combination of <see cref="CaretPolicy"/> values.</param>
    /// <param name="caretSlop">the caretSlop value</param>
    void SetXCaretPolicy(CaretPolicy caretPolicy, int caretSlop);

    /// <summary>
    /// Sets the Y caret policy.
    /// </summary>
    /// <param name="caretPolicy">a combination of <see cref="CaretPolicy"/> values.</param>
    /// <param name="caretSlop">the caretSlop value</param>
    void SetYCaretPolicy(CaretPolicy caretPolicy, int caretSlop);

    /// <summary>
    /// Sets additional options for displaying folds.
    /// </summary>
    /// <param name="flags">A bitwise combination of the <see cref="FoldFlags" /> enumeration.</param>
    void SetFoldFlags(FoldFlags flags);

    /// <summary>
    /// Similar to <see cref="SetKeywords" /> but for sub-styles.
    /// </summary>
    /// <param name="style">The sub-style integer index</param>
    /// <param name="identifiers">A list of words separated by whitespace (space, tab, '\n', '\r') characters.</param>
    void SetIdentifiers(int style, string identifiers);

    /// <summary>
    /// Updates a keyword set used by the current <see cref="Lexer" />.
    /// </summary>
    /// <param name="set">The zero-based index of the keyword set to update.</param>
    /// <param name="keywords">
    /// A list of keywords pertaining to the current <see cref="Lexer" /> separated by whitespace (space, tab, '\n', '\r') characters.
    /// </param>
    /// <remarks>The keywords specified will be styled according to the current <see cref="Lexer" />.</remarks>
    /// <seealso cref="DescribeKeywordSets" />
    void SetKeywords(int set, string keywords);

    /// <summary>
    /// Passes the specified property name-value pair to the current <see cref="Lexer" />.
    /// </summary>
    /// <param name="name">The property name to set.</param>
    /// <param name="value">
    /// The property value. Values can refer to other property names using the syntax $(name), where 'name' is another property
    /// name for the current <see cref="Lexer" />. When the property value is retrieved by a call to <see cref="GetPropertyExpanded" />
    /// the embedded property name macro will be replaced (expanded) with that current property value.
    /// </param>
    /// <remarks>Property names are case-sensitive.</remarks>
    void SetProperty(string name, string value);

    /// <summary>
    /// Marks the document as unmodified.
    /// </summary>
    /// <seealso cref="IScintillaProperties.Modified" />
    void SetSavePoint();

    /// <summary>
    /// Sets the anchor and current position.
    /// </summary>
    /// <param name="anchorPos">The zero-based document position to start the selection.</param>
    /// <param name="currentPos">The zero-based document position to end the selection.</param>
    /// <remarks>
    /// A negative value for <paramref name="currentPos" /> signifies the end of the document.
    /// A negative value for <paramref name="anchorPos" /> signifies no selection (i.e. sets the <paramref name="anchorPos" />
    /// to the same position as the <paramref name="currentPos" />).
    /// The current position is scrolled into view following this operation.
    /// </remarks>
    void SetSel(int anchorPos, int currentPos);

    /// <summary>
    /// Sets a single selection from anchor to caret.
    /// </summary>
    /// <param name="caret">The zero-based document position to end the selection.</param>
    /// <param name="anchor">The zero-based document position to start the selection.</param>
    void SetSelection(int caret, int anchor);

    /// <summary>
    /// Styles the specified length of characters.
    /// </summary>
    /// <param name="length">The number of characters to style.</param>
    /// <param name="style">The <see cref="StyleBase{TColor}" /> definition index to assign each character.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="length" /> or <paramref name="style" /> is less than zero. -or-
    /// The sum of a preceding call to <see cref="StartStyling" /> or <see name="SetStyling" /> and <paramref name="length" /> is greater than the document length. -or-
    /// <paramref name="style" /> is greater than or equal to the number of style definitions.
    /// </exception>
    /// <remarks>
    /// The styling position is advanced by <paramref name="length" /> after each call allowing multiple
    /// calls to <see cref="SetStyling" /> for a single call to <see cref="StartStyling" />.
    /// </remarks>
    /// <seealso cref="StartStyling" />
    void SetStyling(int length, int style);

    /// <summary>
    /// Sets the <see cref="IScintillaProperties.TargetStart" /> and <see cref="IScintillaProperties.TargetEnd" /> properties in a single call.
    /// </summary>
    /// <param name="start">The zero-based character position within the document to start a search or replace operation.</param>
    /// <param name="end">The zero-based character position within the document to end a search or replace operation.</param>
    /// <seealso cref="IScintillaProperties.TargetStart" />
    /// <seealso cref="IScintillaProperties.TargetEnd" />
    void SetTargetRange(int start, int end);

    /// <summary>
    /// Shows the range of lines specified.
    /// </summary>
    /// <param name="lineStart">The zero-based index of the line range to start showing.</param>
    /// <param name="lineEnd">The zero-based index of the line range to end showing.</param>
    /// <seealso cref="HideLines" />
    /// <seealso cref="LineBase.Visible" />
    void ShowLines(int lineStart, int lineEnd);

    /// <summary>
    /// Prepares for styling by setting the styling <paramref name="position" /> to start at.
    /// </summary>
    /// <param name="position">The zero-based character position in the document to start styling.</param>
    /// <remarks>
    /// After preparing the document for styling, use successive calls to <see cref="SetStyling" />
    /// to style the document.
    /// </remarks>
    /// <seealso cref="SetStyling" />
    void StartStyling(int position);

    /// <summary>
    /// Resets all style properties to those currently configured for the <see cref="StyleConstants.Default" /> style.
    /// </summary>
    /// <seealso cref="StyleResetDefault" />
    void StyleClearAll();

    /// <summary>
    /// Resets the <see cref="StyleConstants.Default" /> style to its initial state.
    /// </summary>
    /// <seealso cref="StyleClearAll" />
    void StyleResetDefault();

    /// <summary>
    /// Moves the caret to the opposite end of the main selection.
    /// </summary>
    void SwapMainAnchorCaret();

    /// <summary>
    /// Sets the <see cref="IScintillaProperties.TargetStart" /> and <see cref="IScintillaProperties.TargetEnd" /> to the start and end positions of the selection.
    /// </summary>
    /// <seealso cref="TargetWholeDocument" />
    void TargetFromSelection();

    /// <summary>
    /// Sets the <see cref="IScintillaProperties.TargetStart" /> and <see cref="IScintillaProperties.TargetEnd" /> to the start and end positions of the document.
    /// </summary>
    /// <seealso cref="TargetFromSelection" />
    void TargetWholeDocument();

    /// <summary>
    /// Measures the width in pixels of the specified string when rendered in the specified style.
    /// </summary>
    /// <param name="style">The index of the <see cref="StyleBase{TColor}" /> to use when rendering the text to measure.</param>
    /// <param name="text">The text to measure.</param>
    /// <returns>The width in pixels.</returns>
    int TextWidth(int style, string text);

    /// <summary>
    /// Undoes the previous action.
    /// </summary>
    void Undo();

    /// <summary>
    /// Determines whether to show the right-click context menu.
    /// </summary>
    /// <param name="enablePopup">true to enable the popup window; otherwise, false.</param>
    /// <seealso cref="UsePopup(PopupMode)" />
    void UsePopup(bool enablePopup);

    /// <summary>
    /// Determines the conditions for displaying the standard right-click context menu.
    /// </summary>
    /// <param name="popupMode">One of the <seealso cref="PopupMode" /> enumeration values.</param>
    void UsePopup(PopupMode popupMode);

    /// <summary>
    /// Returns the position where a word ends, searching forward from the position specified.
    /// </summary>
    /// <param name="position">The zero-based document position to start searching from.</param>
    /// <param name="onlyWordCharacters">
    /// true to stop searching at the first non-word character regardless of whether the search started at a word or non-word character.
    /// false to use the first character in the search as a word or non-word indicator and then search for that word or non-word boundary.
    /// </param>
    /// <returns>The zero-based document postion of the word boundary.</returns>
    /// <seealso cref="WordStartPosition" />
    int WordEndPosition(int position, bool onlyWordCharacters);

    /// <summary>
    /// Returns the position where a word starts, searching backward from the position specified.
    /// </summary>
    /// <param name="position">The zero-based document position to start searching from.</param>
    /// <param name="onlyWordCharacters">
    /// true to stop searching at the first non-word character regardless of whether the search started at a word or non-word character.
    /// false to use the first character in the search as a word or non-word indicator and then search for that word or non-word boundary.
    /// </param>
    /// <returns>The zero-based document postion of the word boundary.</returns>
    /// <seealso cref="WordEndPosition" />
    int WordStartPosition(int position, bool onlyWordCharacters);

    /// <summary>
    /// Increases the zoom factor by 1 until it reaches 20 points.
    /// </summary>
    /// <seealso cref="IScintillaProperties.Zoom" />
    void ZoomIn();

    /// <summary>
    /// Decreases the zoom factor by 1 until it reaches -10 points.
    /// </summary>
    /// <seealso cref="IScintillaProperties.Zoom" />
    void ZoomOut();

    /// <summary>
    /// Sets the representation for a specified character string.
    /// </summary>
    /// <param name="encodedString">The encoded string. I.e. the Ohm character: Ω = \u2126.</param>
    /// <param name="representationString">The representation string for the <paramref name="encodedString"/>. I.e. "OHM".</param>
    /// <remarks>The <see cref="IScintillaProperties.ViewWhitespace"/> must be set to <see cref="WhitespaceMode.VisibleAlways"/> for this to work.</remarks>
    void SetRepresentation(string encodedString, string representationString);

    /// <summary>
    /// Sets the representation for a specified character string.
    /// </summary>
    /// <param name="encodedString">The encoded string. I.e. the Ohm character: Ω = \u2126.</param>
    /// <returns>The representation string for the <paramref name="encodedString"/>. I.e. "OHM".</returns>
    string GetRepresentation(string encodedString);

    /// <summary>
    /// Clears the representation from a specified character string.
    /// </summary>
    /// <param name="encodedString">The encoded string. I.e. the Ohm character: Ω = \u2126.</param>
    void ClearRepresentation(string encodedString);
}