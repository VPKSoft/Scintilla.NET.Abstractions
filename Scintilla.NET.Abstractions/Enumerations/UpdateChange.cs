using ScintillaNet.Abstractions.Interfaces;

namespace ScintillaNet.Abstractions.Enumerations;

/// <summary>
/// Specifies the change that triggered a <see cref="IScintillaEvents{TKeys, TAutoCSelectionEventArgs, TBeforeModificationEventArgs, TModificationEventArgs, TChangeAnnotationEventArgs, TCharAddedEventArgs, TDoubleClickEventArgs, TDwellEventArgs, TCallTipClickEventArgs, THotspotClickEventArgs, TIndicatorClickEventArgs, TIndicatorReleaseEventArgs, TInsertCheckEventArgs, TMarginClickEventArgs, TNeedShownEventArgs, TStyleNeededEventArgs, TUpdateUiEventArgs, TScNotificationEventArgs}.UpdateUi" /> event.
/// </summary>
/// <remarks>This enumeration has a FlagsAttribute attribute that allows a bitwise combination of its member values.</remarks>
[Flags]
public enum UpdateChange
{
    /// <summary>
    /// Contents, styling or markers have been changed.
    /// </summary>
    Content = ScintillaConstants.SC_UPDATE_CONTENT,

    /// <summary>
    /// Selection has been changed.
    /// </summary>
    Selection = ScintillaConstants.SC_UPDATE_SELECTION,

    /// <summary>
    /// Scrolled vertically.
    /// </summary>
    VScroll = ScintillaConstants.SC_UPDATE_V_SCROLL,

    /// <summary>
    /// Scrolled horizontally.
    /// </summary>
    HScroll = ScintillaConstants.SC_UPDATE_H_SCROLL,
}