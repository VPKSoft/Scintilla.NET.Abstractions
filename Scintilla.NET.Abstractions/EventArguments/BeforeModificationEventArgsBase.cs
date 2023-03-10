using ScintillaNet.Abstractions.Enumerations;
using ScintillaNet.Abstractions.Interfaces;
using ScintillaNet.Abstractions.Interfaces.Collections;
using ScintillaNet.Abstractions.Interfaces.EventArguments;
using static ScintillaNet.Abstractions.ScintillaConstants;

namespace ScintillaNet.Abstractions.EventArguments;

/// <summary>
/// Provides data for the <see cref="IScintillaEvents{TKeys,TAutoCSelectionEventArgs,TBeforeModificationEventArgs,TModificationEventArgs,TChangeAnnotationEventArgs,TCharAddedEventArgs,TDoubleClickEventArgs,TDwellEventArgs,TCallTipClickEventArgs,THotspotClickEventArgs,TIndicatorClickEventArgs,TIndicatorReleaseEventArgs,TInsertCheckEventArgs,TMarginClickEventArgs,TNeedShownEventArgs,TStyleNeededEventArgs,TUpdateUiEventArgs,TScNotificationEventArgs,TAutoCSelectionChangeEventArgs}.BeforeInsert" /> and <see cref="IScintillaEvents{TKeys,TAutoCSelectionEventArgs,TBeforeModificationEventArgs,TModificationEventArgs,TChangeAnnotationEventArgs,TCharAddedEventArgs,TDoubleClickEventArgs,TDwellEventArgs,TCallTipClickEventArgs,THotspotClickEventArgs,TIndicatorClickEventArgs,TIndicatorReleaseEventArgs,TInsertCheckEventArgs,TMarginClickEventArgs,TNeedShownEventArgs,TStyleNeededEventArgs,TUpdateUiEventArgs,TScNotificationEventArgs,TAutoCSelectionChangeEventArgs}.BeforeDelete" /> events.
/// </summary>
public abstract class BeforeModificationEventArgsBase : ScintillaEventArgs, IBeforeModificationEventArgs
{
    /// <inheritdoc />
    public int BytePosition { get; set; }

    /// <summary>
    /// Gets or sets the cached position.
    /// </summary>
    /// <value>The cached position.</value>
    public virtual int? CachedPosition { get; set; }

    /// <summary>
    /// Gets or sets the cached text.
    /// </summary>
    /// <value>The cached text.</value>
    public virtual string? CachedText { get; set; }

    /// <inheritdoc />
    public int ByteLength { get; }

    /// <inheritdoc />
    public IntPtr TextPtr { get; }

    /// <summary>
    /// Gets the zero-based document position where the modification will occur.
    /// </summary>
    /// <returns>The zero-based character position within the document where text will be inserted or deleted.</returns>
    public virtual int Position
    {
        get
        {
            CachedPosition ??= LineCollectionGeneral.ByteToCharPosition(BytePosition);

            return (int)CachedPosition;
        }
    }

    /// <summary>
    /// Gets the source of the modification.
    /// </summary>
    /// <returns>One of the <see cref="ModificationSource" /> enum values.</returns>
    public virtual ModificationSource Source { get; private set; }

    /// <inheritdoc />
    public IScintillaLineCollectionGeneral LineCollectionGeneral { get; }
    
    /// <summary>
    /// Gets the text being inserted or deleted.
    /// </summary>
    /// <returns>
    /// The text about to be inserted or deleted.
    /// </returns>
    public virtual unsafe string? Text
    {
        get
        {
            if (CachedText == null)
            {
                // For some reason the Scintilla overlords don't provide text in
                // SC_MOD_BEFOREDELETE... but we can get it from the document.
                if (TextPtr == IntPtr.Zero)
                {
                    var ptr = ScintillaApi.DirectMessage(SCI_GETRANGEPOINTER, new IntPtr(BytePosition), new IntPtr(ByteLength));
                    CachedText = new string((sbyte*)ptr, 0, ByteLength, ScintillaApi.Encoding);
                }
                else
                {
                    CachedText = HelpersGeneral.GetString(TextPtr, ByteLength, ScintillaApi.Encoding);
                }
            }

            return CachedText;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BeforeModificationEventArgsBase" /> class.
    /// </summary>
    /// <param name="scintilla">The Scintilla control that generated this event.</param>
    /// <param name="lineCollectionGeneral">A reference to Scintilla's line collection.</param>
    /// <param name="source">The source of the modification.</param>
    /// <param name="bytePosition">The zero-based byte position within the document where text is being modified.</param>
    /// <param name="byteLength">The length in bytes of the text being modified.</param>
    /// <param name="text">A pointer to the text being inserted.</param>
    protected BeforeModificationEventArgsBase(
        IScintillaApi scintilla, 
        IScintillaLineCollectionGeneral lineCollectionGeneral,
        ModificationSource source,
        int bytePosition, int byteLength, IntPtr text) : base(scintilla)
    {
        BytePosition = bytePosition;
        ByteLength = byteLength;
        TextPtr = text;
        LineCollectionGeneral = lineCollectionGeneral;

        Source = source;
    }
}