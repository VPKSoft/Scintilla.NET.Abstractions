using ScintillaNet.Abstractions.Classes;
using ScintillaNet.Abstractions.Collections;

namespace ScintillaNet.Abstractions.Enumerations;

/// <summary>
/// The behavior and appearance of a margin.
/// </summary>
public enum MarginType
{
    /// <summary>
    /// Margin can display symbols.
    /// </summary>
    Symbol = ScintillaConstants.SC_MARGIN_SYMBOL,

    /// <summary>
    /// Margin displays line numbers.
    /// </summary>
    Number = ScintillaConstants.SC_MARGIN_NUMBER,

    /// <summary>
    /// Margin can display symbols and has a background color equivalent to <see cref="StyleConstants.Default" /> background color.
    /// </summary>
    BackColor = ScintillaConstants.SC_MARGIN_BACK,

    /// <summary>
    /// Margin can display symbols and has a background color equivalent to <see cref="StyleConstants.Default"/> foreground color.
    /// </summary>
    ForeColor = ScintillaConstants.SC_MARGIN_FORE,

    /// <summary>
    /// Margin can display application defined text.
    /// </summary>
    Text = ScintillaConstants.SC_MARGIN_TEXT,

    /// <summary>
    /// Margin can display application defined text right-justified.
    /// </summary>
    RightText = ScintillaConstants.SC_MARGIN_RTEXT,

    /// <summary>
    /// Margin can display symbols and has a background color specified using the <see cref="MarginBase{TColor}.BackColor" /> property.
    /// </summary>
    Color = ScintillaConstants.SC_MARGIN_COLOUR,
}