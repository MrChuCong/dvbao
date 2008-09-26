@echo off

call config.bat

%SE_DIR%\bin\emulator.exe -Xdescriptor:Output\%JAR_NAME%_%PHONE_NAME%_%LANGUAGE%_%FILENAME_VER%.jad

if errorlevel 1 pause