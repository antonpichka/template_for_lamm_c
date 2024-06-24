- https://github.com/antonpichka/library_architecture_mvvm_modify/tree/main/package#architectural-objects
- https://github.com/antonpichka/library_architecture_mvvm_modify/labels

---

- After setup. Everything after this message can be deleted. Even the message itself

## Project setup

- [windows_template_for_lamm_c_sharp](https://github.com/antonpichka/template_for_lamm_c_sharp#windows_template_for_lamm_c_sharp)

### windows_template_for_lamm_c_sharp

- If you need to change the catalog name from "windows_template_for_lamm_c_sharp" to "windows_${name_of_your_catalog}" and files and namespace
- Change your project's dependency path in "windows_template_for_lamm_c_sharp\windows_template_for_lamm_c_sharp\Src\NamedTestMain\AlgorithmsUtilityTestMain\AlgorithmsUtilityTestMain.csproj":
```
<ItemGroup>
    <Reference Include="C:\Developer\Projects\template_for_lamm_c_sharp\windows_template_for_lamm_c_sharp\output\Debug\net8.0-windows\windows_template_for_lamm_c_sharp.dll" />
</ItemGroup>
```
- - "Include="${your_path}""

#### Windows

- 'build_project_bat.bat':
- - set "project=${name_of_your_catalog}"
- 'build_w_run_project_bat.bat':
- - set "project=${name_of_your_catalog}"
- Build "windows_template_for_lamm_c_sharp"
- - Commands cmd:
- - - start /min build_project_bat.bat
- - - taskkill /f /im dotnet.exe
- - - taskkill /f /im cmd.exe
- - Commands PowerShell:
- - - Start-Process -FilePath "build_project_bat.bat"
- - - taskkill /f /im dotnet.exe
- - - taskkill /f /im cmd.exe
- Build and run "windows_template_for_lamm_c_sharp"
- - Commands cmd:
- - - start /min build_w_run_project_bat.bat
- - - taskkill /f /im dotnet.exe
- - - taskkill /f /im cmd.exe
- - Commands PowerShell:
- - - Start-Process -FilePath "build_w_run_project_bat.bat"
- - - taskkill /f /im dotnet.exe
- - - taskkill /f /im cmd.exe

## Note

- "dotnet" which is a compiler and more. It cannot completely build a project when the files are not in the same directory, so I had to use method the one used above. Maybe I'm stupid and don't understand how to build an entire project using "dotnet" alone, without resorting to .bat and other cmd commands.
- Use the "ExceptionHelperUtility" class, otherwise when you develop a program using WPF, no crashes appear in the console when executing the program, and you have to resort to such crooked methods, basically we use this class in all Views. You can use the Microsoft Visual Studio development environment and not resort to such nonsense.