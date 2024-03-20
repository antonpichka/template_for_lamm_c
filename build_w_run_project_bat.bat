@echo off

rem ONLY EDIT THIS ROW (Name of your catalog)
set "project=template_for_lamm_c_sharp"
rem ONLY EDIT THIS ROW (Name of your catalog)

rd /s /q build
rd /s /q SomeOtherIntermediateOutputPath
rd /s /q SomeOtherOutputPath
robocopy %project% build /S
cd build
dotnet build
dotnet run
PAUSE