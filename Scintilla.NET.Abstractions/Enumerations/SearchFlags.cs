using ScintillaNet.Abstractions.Interfaces;

namespace ScintillaNet.Abstractions.Enumerations;

/// <summary>
/// Specifies the how patterns are matched when performing a search in a Scintilla control.
/// </summary>
/// <remarks>This enumeration has a FlagsAttribute attribute that allows a bitwise combination of its member values.</remarks>
[Flags]
public enum SearchFlags
{
    /// <summary>
    /// Matches every instance of the search string.
    /// </summary>
    None = 0,

    /// <summary>
    /// A match only occurs with text that matches the case of the search string.
    /// </summary>
    MatchCase = ScintillaConstants.SCFIND_MATCHCASE,

    /// <summary>
    /// A match only occurs if the characters before and after are not word characters.
    /// </summary>
    WholeWord = ScintillaConstants.SCFIND_WHOLEWORD,

    /// <summary>
    /// A match only occurs if the character before is not a word character.
    /// </summary>
    WordStart = ScintillaConstants.SCFIND_WORDSTART,

    /// <summary>
    /// The search string should be interpreted as a regular expression.
    /// Regular expressions will only match ranges within a single line, never matching over multiple lines.
    /// </summary>
    Regex = ScintillaConstants.SCFIND_REGEXP,

    /// <summary>
    /// Treat regular expression in a more POSIX compatible manner by interpreting bare '(' and ')' for tagged sections rather than "\(" and "\)".
    /// </summary>
    Posix = ScintillaConstants.SCFIND_POSIX,

    /// <summary>
    /// The search string should be interpreted as a regular expression and use the C++11 &lt;regex&gt; standard library engine.
    /// The <see cref="IScintillaProperties.Status" /> property can queried to determine if the regular expression is invalid.
    /// The ECMAScript flag is set on the regex object and documents will exhibit Unicode-compliant behaviour.
    /// Regular expressions will only match ranges within a single line, never matching over multiple lines.
    /// </summary>
    Cxx11Regex = ScintillaConstants.SCFIND_CXX11REGEX,
}