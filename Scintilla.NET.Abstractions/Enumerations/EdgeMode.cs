using ScintillaNet.Abstractions.Interfaces;
using ScintillaNet.Abstractions.Interfaces.Methods;

namespace ScintillaNet.Abstractions.Enumerations;

/// <summary>
/// The long line edge display mode.
/// </summary>
public enum EdgeMode
{
    /// <summary>
    /// Long lines are not indicated. This is the default.
    /// </summary>
    None = ScintillaConstants.EDGE_NONE,

    /// <summary>
    /// Long lines are indicated with a vertical line.
    /// </summary>
    Line = ScintillaConstants.EDGE_LINE,

    /// <summary>
    /// Long lines are indicated with a background color.
    /// </summary>
    Background = ScintillaConstants.EDGE_BACKGROUND,

    /// <summary>
    /// Similar to <see cref="Line" /> except allows for multiple vertical lines to be visible using the <see cref="IScintillaMethodsColor{TColor}.MultiEdgeAddLine" /> method.
    /// </summary>
    /// <remarks><see cref="Line" /> and <see cref="IScintillaProperties.EdgeColumn" /> are completely independent of this mode.</remarks>
    MultiLine = ScintillaConstants.EDGE_MULTILINE,
}