@echo off
set "source=build\"
for /f "delims=" %%i in ('dir %source% /ad /b') do (
    set "list_folders=%%i"
    rmdir /s /q %source%"%%i"
)