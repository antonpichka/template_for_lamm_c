## Project setup

- If you need to change the catalog name from "template_for_lamm_c_sharp" to "${name_of_your_catalog}"

### Windows

- build_run_bat.bat:
- - "project=${name_of_your_catalog}":
- Commands cmd:
- - start /b build_run_bat.bat
- Commands PowerShell:
- - Start-Process -FilePath "build_run_bat.bat" -WindowStyle Hidden

## Note

"dotnet" which is a compiler and more. It cannot completely build a project when the files are not in the same directory, so I had to use method the one used above.
Maybe I'm stupid and don't understand how to build an entire project using "dotnet" alone, without resorting to .bat and other cmd commands.