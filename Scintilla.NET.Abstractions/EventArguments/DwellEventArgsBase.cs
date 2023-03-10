using ScintillaNet.Abstractions.Interfaces;
using ScintillaNet.Abstractions.Interfaces.Collections;
using ScintillaNet.Abstractions.Interfaces.EventArguments;

namespace ScintillaNet.Abstractions.EventArguments;

/// <summary>
/// Provides data for the <see cref="IScintillaEvents{TKeys,TAutoCSelectionEventArgs,TBeforeModificationEventArgs,TModificationEventArgs,TChangeAnnotationEventArgs,TCharAddedEventArgs,TDoubleClickEventArgs,TDwellEventArgs,TCallTipClickEventArgs,THotspotClickEventArgs,TIndicatorClickEventArgs,TIndicatorReleaseEventArgs,TInsertCheckEventArgs,TMarginClickEventArgs,TNeedShownEventArgs,TStyleNeededEventArgs,TUpdateUiEventArgs,TScNotificationEventArgs,TAutoCSelectionChangeEventArgs}.DwellStart" /> and <see cref="IScintillaEvents{TKeys,TAutoCSelectionEventArgs,TBeforeModificationEventArgs,TModificationEventArgs,TChangeAnnotationEventArgs,TCharAddedEventArgs,TDoubleClickEventArgs,TDwellEventArgs,TCallTipClickEventArgs,THotspotClickEventArgs,TIndicatorClickEventArgs,TIndicatorReleaseEventArgs,TInsertCheckEventArgs,TMarginClickEventArgs,TNeedShownEventArgs,TStyleNeededEventArgs,TUpdateUiEventArgs,TScNotificationEventArgs,TAutoCSelectionChangeEventArgs}.DwellEnd" /> events.
/// </summary>
public abstract class DwellEventArgsBase : ScintillaEventArgs, IDwellEventArgs
{
    private int? position;

    /// <summary>
    /// Gets the zero-based document position where the mouse pointer was lingering.
    /// </summary>
    /// <returns>The nearest zero-based document position to where the mouse pointer was lingering.</returns>
    public virtual int Position
    {
        get
        {
            position ??= LineCollectionGeneral.ByteToCharPosition(BytePosition);

            return (int)position;
        }
    }

    /// <inheritdoc />
    public int BytePosition { get; set; }

    /// <summary>
    /// Gets the x-coordinate of the mouse pointer.
    /// </summary>
    /// <returns>The x-coordinate of the mouse pointer relative to the Scintilla control.</returns>
    public virtual int X { get; }

    /// <summary>
    /// Gets the y-coordinate of the mouse pointer.
    /// </summary>
    /// <returns>The y-coordinate of the mouse pointer relative to the Scintilla control.</returns>
    public virtual int Y { get; }

    /// <inheritdoc />
    public IScintillaLineCollectionGeneral LineCollectionGeneral { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DwellEventArgsBase" /> class.
    /// </summary>
    /// <param name="scintilla">The Scintilla control that generated this event.</param>
    /// <param name="lineCollectionGeneral">A reference to Scintilla's line collection.</param>
    /// <param name="bytePosition">The zero-based byte position within the document where the mouse pointer was lingering.</param>
    /// <param name="x">The x-coordinate of the mouse pointer relative to the Scintilla control.</param>
    /// <param name="y">The y-coordinate of the mouse pointer relative to the Scintilla control.</param>
    protected DwellEventArgsBase(
        IScintillaApi scintilla, 
        IScintillaLineCollectionGeneral lineCollectionGeneral,
        int bytePosition, int x,
        int y) : base(scintilla)
    {
        BytePosition = bytePosition;
        X = x;
        Y = y;
        LineCollectionGeneral = lineCollectionGeneral;

        // The position is not over text
        if (bytePosition < 0)
        {
            position = bytePosition;
        }
    }
}