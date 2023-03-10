using ScintillaNet.Abstractions.Interfaces;
using ScintillaNet.Abstractions.Interfaces.Collections;
using ScintillaNet.Abstractions.Interfaces.EventArguments;

namespace ScintillaNet.Abstractions.EventArguments;

/// <summary>
/// Provides data for the <see cref="IScintillaEvents{TKeys,TAutoCSelectionEventArgs,TBeforeModificationEventArgs,TModificationEventArgs,TChangeAnnotationEventArgs,TCharAddedEventArgs,TDoubleClickEventArgs,TDwellEventArgs,TCallTipClickEventArgs,THotspotClickEventArgs,TIndicatorClickEventArgs,TIndicatorReleaseEventArgs,TInsertCheckEventArgs,TMarginClickEventArgs,TNeedShownEventArgs,TStyleNeededEventArgs,TUpdateUiEventArgs,TScNotificationEventArgs,TAutoCSelectionChangeEventArgs}.MarginClick" /> event.
/// </summary>
public abstract class MarginClickEventArgsBase<TKeys> : ScintillaEventArgs, IMarginClickEventArgs<TKeys>
    where TKeys: Enum
{
    private int? position;
    
    /// <inheritdoc />
    public int BytePosition { get; set; }

    /// <summary>
    /// Gets the margin clicked.
    /// </summary>
    /// <returns>The zero-based index of the clicked margin.</returns>
    public virtual int Margin { get; }

    /// <summary>
    /// Gets the modifier keys (SHIFT, CTRL, ALT) held down when the margin was clicked.
    /// </summary>
    /// <returns>A bitwise combination of the Keys enumeration indicating the modifier keys.</returns>
    public virtual TKeys Modifiers { get; }

    /// <summary>
    /// Gets the zero-based document position where the line adjacent to the clicked margin starts.
    /// </summary>
    /// <returns>The zero-based character position within the document of the start of the line adjacent to the margin clicked.</returns>
    public virtual int Position
    {
        get
        {
            position ??=LineCollectionGeneral.ByteToCharPosition(BytePosition);

            return (int)position;
        }
    }

    /// <inheritdoc />
    public IScintillaLineCollectionGeneral LineCollectionGeneral { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MarginClickEventArgsBase{TKeys}" /> class.
    /// </summary>
    /// <param name="scintilla">The Scintilla control that generated this event.</param>
    /// <param name="lineCollectionGeneral">A reference to Scintilla's line collection.</param>
    /// <param name="modifiers">The modifier keys that where held down at the time of the margin click.</param>
    /// <param name="bytePosition">The zero-based byte position within the document where the line adjacent to the clicked margin starts.</param>
    /// <param name="margin">The zero-based index of the clicked margin.</param>
    protected MarginClickEventArgsBase(
        IScintillaApi scintilla, 
        IScintillaLineCollectionGeneral lineCollectionGeneral,
        TKeys modifiers, int bytePosition,
        int margin) : base(scintilla)
    {
        BytePosition = bytePosition;
        Modifiers = modifiers;
        Margin = margin;
        LineCollectionGeneral = lineCollectionGeneral;
    }
}