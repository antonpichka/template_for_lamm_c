- https://github.com/antonpichka/library_architecture_mvvm_modify/tree/main/package#architectural-objects
- https://github.com/antonpichka/library_architecture_mvvm_modify_c_sharp/blob/main/example/Program.cs
- https://github.com/antonpichka/library_architecture_mvvm_modify/labels

---

- After setup. Everything after this message can be deleted. Even the message itself

## Project setup

- If you need to change the catalog name from "template_for_lamm_c_sharp" to "${name_of_your_catalog}"

### Windows

- build_w_run_project_bat.bat:
- - set "project=${name_of_your_catalog}":
- Commands cmd:
- - start /min build_w_run_project_bat.bat
- - taskkill /f /im dotnet.exe
- - taskkill /f /im cmd.exe
- Commands PowerShell:
- - Start-Process -FilePath "build_w_run_project_bat.bat" -WindowStyle Hidden
- - taskkill /f /im dotnet.exe
- - taskkill /f /im cmd.exe

### Note

- "dotnet" which is a compiler and more. It cannot completely build a project when the files are not in the same directory, so I had to use method the one used above. Maybe I'm stupid and don't understand how to build an entire project using "dotnet" alone, without resorting to .bat and other cmd commands.