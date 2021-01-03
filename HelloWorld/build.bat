dotnet build ..\lib1\lib1.csproj -c release
dotnet build ..\lib2\lib2.csproj -c release
dotnet publish -r win-x64 -c release
.\bin\release\netcoreapp3.1\win-x64\publish\HelloWorldNative.exe