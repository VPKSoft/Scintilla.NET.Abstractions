using System.Collections;
using ScintillaNet.Abstractions.Collections;
using ScintillaNet.Abstractions.Interfaces.Collections;
using static ScintillaNet.Abstractions.ScintillaConstants;

namespace ScintillaNet.Abstractions.Classes;

/// <summary>
/// An immutable collection of style definitions in a Scintilla control.
/// </summary>
public class StyleCollectionPrimitive : IScintillaStyleCollectionGeneral, IEnumerable
{
    /// <summary>
    /// Provides an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An object that contains all <see cref="StylePrimitive" />.</returns>
    public IEnumerator<StylePrimitive> GetEnumerator()
    {
        var count = Count;
        for (var i = 0; i < count; i++)
        {
            yield return this[i];
        }
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
    /// Gets the number of styles.
    /// </summary>
    /// <returns>The number of styles in the <see cref="StyleCollectionBase{TStyle,TColor}" />.</returns>
    public virtual int Count => STYLE_MAX + 1;

    /// <summary>
    /// Gets a <see cref="StylePrimitive"/> object at the specified index.
    /// </summary>
    /// <param name="index">The style definition index.</param>
    /// <returns>An object representing the style definition at the specified <paramref name="index" />.</returns>
    /// <remarks>Styles 32 through 39 have special significance.</remarks>
    public StylePrimitive this[int index]
    {
        get
        {
            index = HelpersGeneral.Clamp(index, 0, Count - 1);
            return new StylePrimitive(ScintillaApi, index);
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StyleCollectionBase{TStyle, TColor}" /> class.
    /// </summary>
    /// <param name="scintilla">The <see cref="IScintillaApi" /> control that created this collection.</param>
    public StyleCollectionPrimitive(IScintillaApi scintilla)
    {
        ScintillaApi = scintilla;
    }
}