using ScintillaNet.Abstractions.Classes;

namespace ScintillaNet.Abstractions.Enumerations;

/// <summary>
/// Options for displaying indentation guides in a Scintilla control.
/// </summary>
/// <remarks>Indentation guides can be styled using the <see cref="StyleConstants.IndentGuide" /> style.</remarks>
public enum IndentView
{
    /// <summary>
    /// No indentation guides are shown. This is the default.
    /// </summary>
    None = ScintillaConstants.SC_IV_NONE,

    /// <summary>
    /// Indentation guides are shown inside real indentation whitespace.
    /// </summary>
    Real = ScintillaConstants.SC_IV_REAL,

    /// <summary>
    /// Indentation guides are shown beyond the actual indentation up to the level of the next non-empty line.
    /// If the previous non-empty line was a fold header then indentation guides are shown for one more level of indent than that line.
    /// This setting is good for Python.
    /// </summary>
    LookForward = ScintillaConstants.SC_IV_LOOKFORWARD,

    /// <summary>
    /// Indentation guides are shown beyond the actual indentation up to the level of the next non-empty line or previous non-empty line whichever is the greater.
    /// This setting is good for most languages.
    /// </summary>
    LookBoth = ScintillaConstants.SC_IV_LOOKBOTH,
}