using ScintillaNet.Abstractions.Interfaces;
using ScintillaNet.Abstractions.Interfaces.EventArguments;

namespace ScintillaNet.Abstractions.EventArguments;

/// <summary>
/// Provides data for the <see cref="IScintillaEvents{TKeys,TAutoCSelectionEventArgs,TBeforeModificationEventArgs,TModificationEventArgs,TChangeAnnotationEventArgs,TCharAddedEventArgs,TDoubleClickEventArgs,TDwellEventArgs,TCallTipClickEventArgs,THotspotClickEventArgs,TIndicatorClickEventArgs,TIndicatorReleaseEventArgs,TInsertCheckEventArgs,TMarginClickEventArgs,TNeedShownEventArgs,TStyleNeededEventArgs,TUpdateUiEventArgs,TScNotificationEventArgs,TAutoCSelectionChangeEventArgs}.CharAdded" /> event.
/// </summary>
public abstract class CharAddedEventArgsBase : EventArgs, ICharAddedEventArgs
{
    /// <summary>
    /// Gets the text character added to a Scintilla control.
    /// </summary>
    /// <returns>The character added.</returns>
    public virtual int Char { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CharAddedEventArgsBase" /> class.
    /// </summary>
    /// <param name="ch">The character added.</param>
    protected CharAddedEventArgsBase(int ch)
    {
        Char = ch;
    }
}