using ScintillaNet.Abstractions.Interfaces;
using ScintillaNet.Abstractions.Interfaces.Collections;
using ScintillaNet.Abstractions.Interfaces.EventArguments;
using static ScintillaNet.Abstractions.ScintillaConstants;

namespace ScintillaNet.Abstractions.EventArguments;

/// <summary>
/// Provides data for the <see cref="IScintillaEvents{TKeys,TAutoCSelectionEventArgs,TBeforeModificationEventArgs,TModificationEventArgs,TChangeAnnotationEventArgs,TCharAddedEventArgs,TDoubleClickEventArgs,TDwellEventArgs,TCallTipClickEventArgs,THotspotClickEventArgs,TIndicatorClickEventArgs,TIndicatorReleaseEventArgs,TInsertCheckEventArgs,TMarginClickEventArgs,TNeedShownEventArgs,TStyleNeededEventArgs,TUpdateUiEventArgs,TScNotificationEventArgs,TAutoCSelectionChangeEventArgs}.InsertCheck" /> event.
/// </summary>
public abstract class InsertCheckEventArgsBase : ScintillaEventArgs, IInsertCheckEventArgs
{
    /// <inheritdoc />
    public int BytePosition { get; set; }

    /// <inheritdoc />
    public virtual int? CachedPosition { get; set; }
    
    /// <inheritdoc />
    public virtual string? CachedText { get; set; }

    /// <summary>
    /// Gets the zero-based document position where text will be inserted.
    /// </summary>
    /// <returns>The zero-based character position within the document where text will be inserted.</returns>
    public virtual int Position
    {
        get
        {
            CachedPosition ??= LineCollectionGeneral.ByteToCharPosition(BytePosition);

            return (int)CachedPosition;
        }
    }

    /// <summary>
    /// Gets or sets the text being inserted.
    /// </summary>
    /// <returns>The text being inserted into the document.</returns>
    public virtual unsafe string? Text
    {
        get => CachedText ??= HelpersGeneral.GetString(TextPtr, ByteLength, ScintillaApi.Encoding);
        set
        {
            CachedText = value ?? string.Empty;

            var bytes = HelpersGeneral.GetBytes(CachedText, ScintillaApi.Encoding, zeroTerminated: false);
            fixed (byte* bp = bytes)
            {
                ScintillaApi.DirectMessage(SCI_CHANGEINSERTION, new IntPtr(bytes.Length), new IntPtr(bp));
            }
        }
    }

    /// <inheritdoc />
    public IScintillaLineCollectionGeneral LineCollectionGeneral { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="InsertCheckEventArgsBase" /> class.
    /// </summary>
    /// <param name="scintilla">The Scintilla control that generated this event.</param>
    /// <param name="lineCollectionGeneral">A reference to Scintilla's line collection.</param>
    /// <param name="bytePosition">The zero-based byte position within the document where text is being inserted.</param>
    /// <param name="byteLength">The length in bytes of the inserted text.</param>
    /// <param name="text">A pointer to the text being inserted.</param>
    protected InsertCheckEventArgsBase(
        IScintillaApi scintilla, 
        IScintillaLineCollectionGeneral lineCollectionGeneral,
        int bytePosition, int byteLength,
        IntPtr text) : base(scintilla)
    {
        BytePosition = bytePosition;
        ByteLength = byteLength;
        LineCollectionGeneral = lineCollectionGeneral;
        TextPtr = text;
    }

    /// <inheritdoc />
    public int ByteLength { get; }

    /// <inheritdoc />
    public IntPtr TextPtr { get; }
}