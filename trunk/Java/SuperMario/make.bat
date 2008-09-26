@echo off

call config.bat

if "%1"=="debug" (
	SET DEFINE=-D DEBUG
) else (
	SET DEFINE=
)

REM if "%2"=="midp10" (
	REM SET DEFINE=%DEFINE% -D MIDP10
	REM SET CLASSPATH=%J2ME_DIR%\lib\midpapi10.jar;%J2ME_DIR%\lib\cldcapi11.jar
REM ) else (
	REM SET DEFINE=%DEFINE% -D MIDP20
	REM SET CLASSPATH=%J2ME_DIR%\lib\midpapi20.jar;%J2ME_DIR%\lib\cldcapi11.jar
REM )

if not exist %RELEASE_DIR% (MD %RELEASE_DIR% )

REM if errorlevel 1 pause

cd %RELEASE_DIR%

if exist MANIFEST.MF (DEL /q /s MANIFEST.MF)

REM Rem pause
REM pause
:GENERATE_MANIFEST
echo Generating MANIFEST.MF...
echo Manifest-Version: 1.0> MANIFEST.MF
echo MIDlet-Name: %PRJ_MIDLET_NAME%>> MANIFEST.MF
echo MIDlet-Version: %VERSION%>> MANIFEST.MF
echo MIDlet-Vendor: Gameloft SA>> MANIFEST.MF
echo MIDlet-Icon: /icon.png>> MANIFEST.MF
echo MIDlet-1: %PRJ_MIDLET_NAME%, /icon.png, %MIDLET_NAME%>> MANIFEST.MF
rem Add two parameters:
echo MicroEdition-Configuration: CLDC-1.1 >> MANIFEST.MF
echo MicroEdition-Profile: MIDP-2.0 >> MANIFEST.MF

rem update the value of the “MIDlet-Jar-URL” field
echo MIDlet-Jar-URL: %JAR_NAME%_%FILENAME_VER%.jar>> %JAR_NAME%.jad
Rem *** ECHO.>> MANIFEST.MF

cd..

rem This batch file builds and preverifies the code for the demos.
rem it then packages them in a JAR file appropriately.

echo *** Creating directories ***

if exist TMPCLASSES (rd /s /q TMPCLASSES)
if exist CLASSES (rd /s /q CLASSES)

mkdir TMPCLASSES
mkdir CLASSES

REM if exist %TMP_SRC% (rd /s /q %TMP_SRC%)
REM mkdir %TMP_SRC%

REM cd src
REM for %%i in (*.java) do (
	REM %CPP%\cpp -C -P %DEFINE% %%i %TMP_SRC%\%%i
REM )
REM cd..

echo *** Compiling source files ***
%JAVA_BIN%\javac.exe -bootclasspath %CLASSPATH% -d TMPCLASSES src\*.java

if errorlevel 1 pause

echo *** Preverifying class files ***
%J2ME_DIR%\bin\preverify.exe -classpath %CLASSPATH% -d CLASSES TMPCLASSES

if errorlevel 1 pause

rem make tem_res, copy 2 files form res to tmp_res
mkdir TMP_RES
copy res TMP_RES

rem delete folder TMP_SRC
rd /s /q %TMP_SRC%

echo *** Jaring preverified class + resource files ***
%JAVA_BIN%\jar.exe -cvfm %RELEASE_DIR%\%JAR_NAME%.jar %RELEASE_DIR%\MANIFEST.MF -C CLASSES . -C TMP_RES . 

if "%1"=="debug" (
	goto END_PROGUARD
)
rem ---- use progoard
if exist %OBFUSCATE% (rd /s /q %OBFUSCATE%)
mkdir %OBFUSCATE%

echo -libraryjars %CLASSPATH%										> %OBFUSCATE%\proguard.pro
echo -injars %RELEASE_DIR%\%JAR_NAME%.jar							>> %OBFUSCATE%\proguard.pro
echo -outjar %OBFUSCATE%\%JAR_NAME%_OBFUSCATE.jar					>> %OBFUSCATE%\proguard.pro
echo -keep public class * extends javax.microedition.midlet.MIDlet 	>> %OBFUSCATE%\proguard.pro
echo -overloadaggressively											>> %OBFUSCATE%\proguard.pro
echo -verbose 														>> %OBFUSCATE%\proguard.pro
echo -dontusemixedcaseclassnames									>> %OBFUSCATE%\proguard.pro
echo -printseeds %OBFUSCATE%\%JAR_NAME%.seed.txt 								>> %OBFUSCATE%\proguard.pro
echo -printmapping %OBFUSCATE%\%JAR_NAME%.mapping.txt							>> %OBFUSCATE%\proguard.pro

rem ---- obfuscate
%JAVA_BIN%\java.exe -jar "%PROGUARD%\proguard.jar" @%OBFUSCATE%\proguard.pro 	> %OBFUSCATE%\proguard.log

rem ---- after use proguard, extract
mkdir ABC
cd ABC
%JAVA_BIN%\jar.exe  -xf  %OBFUSCATE%\%JAR_NAME%_OBFUSCATE.jar
cd..

rem ---- preverify again
%J2ME_DIR%\bin\preverify.exe -classpath %CLASSPATH% -d ABC ABC

%JAVA_BIN%\jar.exe -cvfm %RELEASE_DIR%\%JAR_NAME%.jar %RELEASE_DIR%\MANIFEST.MF -C ABC .

if exist %OBFUSCATE% (rd /s /q %OBFUSCATE%)

:END_PROGUARD
rem remove the file “MANIFEST.MF”  after make “.JAR” file 
Del %RELEASE_DIR%\MANIFEST.MF /q

if exist TMPCLASSES (rd /s /q TMPCLASSES)
if exist CLASSES (rd /s /q CLASSES)
if exist ABC (rd /s /q ABC)
if exist TMP_RES (rd /s /q TMP_RES)

cd %RELEASE_DIR%

:GENERATE_JAD
echo Generating %JAR_NAME%.jad...
echo MIDlet-Name: %PRJ_MIDLET_NAME%> %JAR_NAME%.jad
echo MIDlet-Version: %VERSION%>> %JAR_NAME%.jad
echo MIDlet-Vendor: Gameloft SA>> %JAR_NAME%.jad
echo MIDlet-Icon: /icon.png>> %JAR_NAME%.jad
echo MIDlet-1: %PRJ_MIDLET_NAME%, /icon.png, %MIDLET_NAME%>> %JAR_NAME%.jad
echo MIDlet-Description: %DESCRIPTION%>> %JAR_NAME%.jad
echo MIDlet-Jar-URL: %JAR_NAME%_%PHONE_NAME%_%LANGUAGE%_%FILENAME_VER%.jar>> %JAR_NAME%.jad

echo MIDlet-Data-Size: 1024>> %JAR_NAME%.jad

for %%I in (%JAR_NAME%.jar) do set JAR_SIZE=%%~zI
echo MIDlet-Jar-Size: %JAR_SIZE% >> %JAR_NAME%.jad
Rem *** ECHO.>> %JAR_NAME%.jad

rem show Current directory
echo Current Dir: %CD%

cd..

Rem create Output folder
if exist Output (rd /s /q Output)
md Output

Rem move 2 files “JAR_NAME.jad”, “JAR_NAME.jar”  from  "release”  folder  into  “output”  folder
MOVE %RELEASE_DIR%\%JAR_NAME%.jad %CD%\Output
MOVE %RELEASE_DIR%\%JAR_NAME%.jar %CD%\Output

Rem rename 2 files 
rem  “JAR_NAME.jad”  to become   “JAR_NAME_<PHONE_NAME>_<LANGUAGE>_<VERSION>.jad” 
rem  “JAR_NAME}jar”  to become   “JAR_NAME_<PHONE_NAME>_<LANGUAGE>_<VERSION>.jar”

MOVE Output\%JAR_NAME%.jad %CD%\Output\%JAR_NAME%_%PHONE_NAME%_%LANGUAGE%_%FILENAME_VER%.jad
MOVE Output\%JAR_NAME%.jar %CD%\Output\%JAR_NAME%_%PHONE_NAME%_%LANGUAGE%_%FILENAME_VER%.jar

REM pause