@echo off

rem ONLY EDIT THIS ROW (Name of your catalog)
set "project=template_for_lamm_c_sharp"
rem ONLY EDIT THIS ROW (Name of your catalog)

rd /s /q build
rd /s /q intermediate_output
rd /s /q output
robocopy %project% build /S
cd build
rd /s /q Src\NamedTestMain
dotnet build
PAUSE