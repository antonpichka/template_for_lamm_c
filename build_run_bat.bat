@echo off

rem ONLY EDIT THIS ROW (Name of your catalog)
set "project=template_for_lamm_c_sharp"
rem ONLY EDIT THIS ROW (Name of your catalog)

rd /s /q build
Xcopy %project%\* build\ /S /E
start /b copy_all_files_from_all_folders_to_one_folder_bat.bat
start /b remove_unnecessary_files_and_folders_for_the_build_bat.bat
cd build
dotnet build
dotnet run