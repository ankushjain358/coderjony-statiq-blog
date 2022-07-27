Title: Important .NET CLI commands
Published: 05/02/2022
Author: Ankush Jain
IsActive: true
Tags:
  - .NET
---
While working with .NET Core, it sometimes makes your life easy if know a few important .NET CLI commands. 

Here are some of the most commonly used .NET CLI commands.

# General
```bash
// To check current .NET info
dotnet --info

// To check installed SDKs
dotnet --list-sdks

// To check installed runtimes
dotnet --list-runtimes
```

# Restore
```bash
// To restore NuGet packages
dotnet restore
```

## Implicit restore
You don't have to run `dotnet restore` because it's run implicitly by all commands that require a restore to occur, such as `dotnet new`, `dotnet build`, `dotnet run`, `dotnet test`, `dotnet publish`, and `dotnet pack`. To disable implicit restore, use the `--no-restore` option.

# Create
```bash
// To create a new dotnet application
dotnet new <template> --output <output-directory>

//  To create a new console application
dotnet new console --output sample1

// To create a new web application
dotnet new webapp -o aspnetcoreapp
```

# Build
```bash
// To build a solution
dotnet build solution.sln -c "Debug"

// To build a project
dotnet build project.csproj -c "Debug"
```

# Publish
```bash
// To publish an application
dotnet publish -c "Release"

// To publish a project
dotnet publish "AccountingSoftware.API" -c "Release" -f "net6.0" --self-contained false
```

## How does `dotnet publish` work
`dotnet publish` compiles the application, reads through its dependencies specified in the project file, and publishes the resulting set of files to a directory.

# Run
```bash
// To run published app directly
dotnet MyApp.dll

// To run an application in debug mode
dotnet run [--project sample1] [--launch-profile "launch-profile-name"]
```

## How does `dotnet run` work
* It first builds the project using `dotnet build` and then runs the app from the output directory `bin/debug/netcoreapp3.1/MainApp.dll`
* It uses a **launch-profile** to run the project.
* So command `dotnet run` = `dotnet build` + execute launch-profile command

## How to debug apps running with `dotnet run` command
* To debug the app running in debug mode, use Attach to process in Visual Studio, and select the process with the name `AssemblyName.exe`.

That's all 🙂

                