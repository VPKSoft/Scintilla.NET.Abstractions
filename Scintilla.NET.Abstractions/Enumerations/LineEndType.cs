﻿using ScintillaNet.Abstractions.Interfaces;

namespace ScintillaNet.Abstractions.Enumerations;

/// <summary>
/// Line endings types supported by lexers and allowed by a Scintilla control.
/// </summary>
/// <seealso cref="IScintillaProperties.LineEndTypesSupported" />
/// <seealso cref="IScintillaProperties.LineEndTypesAllowed" />
/// <seealso cref="IScintillaProperties.LineEndTypesActive" />
[Flags]
public enum LineEndType
{
    /// <summary>
    /// ASCII line endings. Carriage Return, Line Feed pair "\r\n" (0x0D0A); Carriage Return '\r' (0x0D); Line Feed '\n' (0x0A).
    /// </summary>
    Default = ScintillaConstants.SC_LINE_END_TYPE_DEFAULT,

    /// <summary>
    /// Unicode line endings. Next Line (0x0085); Line Separator (0x2028); Paragraph Separator (0x2029).
    /// </summary>
    Unicode = ScintillaConstants.SC_LINE_END_TYPE_UNICODE,
}