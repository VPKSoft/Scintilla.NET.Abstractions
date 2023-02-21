using ScintillaNet.Abstractions.Interfaces;
using ScintillaNet.Abstractions.Interfaces.Methods;

namespace ScintillaNet.Abstractions.Enumerations;

/// <summary>
/// Behavior of the standard edit control context menu.
/// </summary>
/// <seealso cref="IScintillaMethods.UsePopup(PopupMode)" />
public enum PopupMode
{
    /// <summary>
    /// Never show the default editing menu.
    /// </summary>
    Never = ScintillaConstants.SC_POPUP_NEVER,

    /// <summary>
    /// Show default editing menu if clicking on the control.
    /// </summary>
    All = ScintillaConstants.SC_POPUP_ALL,

    /// <summary>
    /// Show default editing menu only if clicking on text area.
    /// </summary>
    /// <remarks>To receive the <see cref="IScintillaEvents{TKeys,TAutoCSelectionEventArgs,TBeforeModificationEventArgs,TModificationEventArgs,TChangeAnnotationEventArgs,TCharAddedEventArgs,TDoubleClickEventArgs,TDwellEventArgs,TCallTipClickEventArgs,THotspotClickEventArgs,TIndicatorClickEventArgs,TIndicatorReleaseEventArgs,TInsertCheckEventArgs,TMarginClickEventArgs,TNeedShownEventArgs,TStyleNeededEventArgs,TUpdateUiEventArgs,TScNotificationEventArgs,TAutoCSelectionChangeEventArgs}.MarginRightClick" /> event, this value must be used.</remarks>
    /// <seealso cref="IScintillaEvents{TKeys,TAutoCSelectionEventArgs,TBeforeModificationEventArgs,TModificationEventArgs,TChangeAnnotationEventArgs,TCharAddedEventArgs,TDoubleClickEventArgs,TDwellEventArgs,TCallTipClickEventArgs,THotspotClickEventArgs,TIndicatorClickEventArgs,TIndicatorReleaseEventArgs,TInsertCheckEventArgs,TMarginClickEventArgs,TNeedShownEventArgs,TStyleNeededEventArgs,TUpdateUiEventArgs,TScNotificationEventArgs,TAutoCSelectionChangeEventArgs}.MarginRightClick" />
    Text = ScintillaConstants.SC_POPUP_TEXT,
}