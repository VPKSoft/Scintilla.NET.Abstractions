using System.Collections;
using ScintillaNet.Abstractions.Interfaces.Collections;
using static ScintillaNet.Abstractions.ScintillaConstants;

namespace ScintillaNet.Abstractions.Collections;

/// <summary>
/// An immutable collection of markers in a Scintilla control.
/// </summary>
public abstract class MarkerCollectionBase<TMarker, TImage, TColor> : IScintillaMarkerCollection<TMarker, TImage, TColor>
    where TMarker : MarkerBase<TImage, TColor>
    where TImage: class
    where TColor: struct
{
    /// <summary>
    /// Provides an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An object for enumerating all <see cref="MarkerBase{TImage, TColor}" />.</returns>
    public IEnumerator<TMarker> GetEnumerator()
    {
        var count = Count;
        for (var i = 0; i < count; i++)
            yield return this[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Gets the scintilla API.
    /// </summary>
    /// <value>The scintilla API.</value>
    public IScintillaApi ScintillaApi { get; }

    /// <summary>
    /// Gets the number of markers in the <see cref="MarkerCollectionBase{TMarker, TImage, TColor}" />.
    /// </summary>
    /// <returns>This property always returns 32.</returns>
    public int Count => MARKER_MAX + 1;

    /// <summary>
    /// Gets a <typeparamref name="TMarker"/> object at the specified index.
    /// </summary>
    /// <param name="index">The marker index.</param>
    /// <returns>An object representing the marker at the specified <paramref name="index" />.</returns>
    /// <remarks>Markers 25 through 31 are used by Scintilla for folding.</remarks>
    public abstract TMarker this[int index] { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MarkerCollectionBase{TMarker, TImage, TColor}" /> class.
    /// </summary>
    /// <param name="scintilla">The Scintilla control that created this collection.</param>
    protected MarkerCollectionBase(IScintillaApi scintilla)
    {
        ScintillaApi = scintilla;
    }
}