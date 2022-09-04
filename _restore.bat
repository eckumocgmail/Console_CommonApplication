dotnet new web --force -f net5.0
del "AppRoot - Backup.csproj"
del Program.cs
del Startup.cs
restore-ef-packages.bat
restore-signalr-packages.bat
dotnet build