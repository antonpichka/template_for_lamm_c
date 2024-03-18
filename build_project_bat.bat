@echo off

rem ONLY EDIT THIS ROW (Name of your catalog)
set "project=template_for_lamm_c_sharp"
rem ONLY EDIT THIS ROW (Name of your catalog)

rd /s /q build
rd /s /q SomeOtherIntermediateOutputPath
rd /s /q SomeOtherOutputPath
rd /s /q %systemdrive%\$Recycle.bin
Xcopy %project%\* build\ /S /E
set "source=build\."
set "destination=build\."
for /r "%source%" %%F in (*) do (
    copy "%%F" "%destination%"
)
rd /s /q build\Src
cd build
dotnet build
PAUSE