using ScintillaNet.Abstractions.Interfaces;

namespace ScintillaNet.Abstractions.Enumerations;

/// <summary>
/// Indenting behavior of wrapped sub-lines.
/// </summary>
public enum WrapIndentMode
{
    /// <summary>
    /// Wrapped sub-lines aligned to left of window plus the amount set by <see cref="IScintillaProperties.WrapStartIndent" />.
    /// This is the default.
    /// </summary>
    Fixed,

    /// <summary>
    /// Wrapped sub-lines are aligned to first sub-line indent.
    /// </summary>
    Same,

    /// <summary>
    /// Wrapped sub-lines are aligned to first sub-line indent plus one more level of indentation.
    /// </summary>
    Indent = ScintillaConstants.SC_WRAPINDENT_INDENT,
}