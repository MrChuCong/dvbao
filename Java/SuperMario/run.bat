echo off
@call config.bat

SET XDevice=DefaultColorPhone

%J2ME_DIR%\bin\emulator.exe -Xdevice:%XDevice% -Xdescriptor:Output\%JAR_NAME%_%PHONE_NAME%_%LANGUAGE%_%FILENAME_VER%.jad

if "%1"=="" pause