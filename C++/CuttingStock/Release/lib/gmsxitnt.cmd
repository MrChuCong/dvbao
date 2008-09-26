@echo off
: gmsxitnt.cmd: Command Line Interface for Windows NT
: GAMS Development Corporation, Washington, DC, USA  1996
:
:  %1  Scratch directory with a '\' at the end
:  %2  Working directory with a '\' at the end
:  %3  completion code, OS-specific
:  %4  completion code, GAMS internal
:
: The command line length in NT is "pretty long".
:
: only delete *.scr files in scratch directory
: the gamsnext and gamsparm files are for gams.exe to delete

: echo --- Erasing scratch files
if exist %1*.scr erase %1*.scr
: for /D %%g IN (%1grid*) DO rmdir /s /q "%%g"
