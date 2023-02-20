# Scintilla.NET.Abstractions
Abstraction API for Scintilla.NET to allow porting to Gtk and macOS.

[![.NET NuGet Release](https://github.com/VPKSoft/Scintilla.NET.Abstractions/actions/workflows/nuget_release.yml/badge.svg)](https://github.com/VPKSoft/Scintilla.NET.Abstractions/actions/workflows/nuget_release.yml) [![.NET](https://github.com/VPKSoft/Scintilla.NET.Abstractions/actions/workflows/dotnet.yml/badge.svg)](https://github.com/VPKSoft/Scintilla.NET.Abstractions/actions/workflows/dotnet.yml) ![Nuget](https://img.shields.io/nuget/v/Scintilla.NET.Abstractions?style=plastic)

This project is used for allowing the [Scintilla.NET](https://github.com/VPKSoft/Scintilla.NET) API to be used in Linux, Windows or macOS. The package it self does only provide an interface to access the API, the implementation is not included.
There are few breaking changes to the Scintilla.NET API however, these are:
* `UpateUI` event is renamed to `UpdateUi`
* The Windows-only specific properties such as `Dock`, `Font`, etc have been dropped.

This API is currently used in the following libraries:
* [Scintilla.NET.Gtk](https://github.com/VPKSoft/Scintilla.NET.Gtk) - A GTK/Linux port of Scintilla.NET
* [Scintilla.NET.Windows](https://github.com/VPKSoft/Scintilla.NET.Windows) - WinForms and Wpf wrappers of the Scintilla control.
* [Scintilla.NET.Eto](https://github.com/VPKSoft/Scintilla.NET.Eto) - A port of Scintilla.NET to Eto.Forms as a cross-platform control.

The project should be considered as beta in this development stage, please do report bugs, issues or improve the API via a [pull request](https://github.com/VPKSoft/Scintilla.NET.Abstractions/pulls).

### Thanks to
* [JetBrains](https://www.jetbrains.com/?from=Scintilla.NET.Abstractions) for their open source license(s).

![JetBrains Logo (Main) logo](https://resources.jetbrains.com/storage/products/company/brand/logos/jb_beam.svg)
