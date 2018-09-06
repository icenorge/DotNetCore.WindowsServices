## Build status

| Build server                | Platform     | Status                                                                                                                    |
|-----------------------------|--------------|---------------------------------------------------------------------------------------------------------------------------|
| AppVeyor                    | Windows      | [![Build status](https://ci.appveyor.com/api/projects/status/1ax6w93byxor88l0/branch/master?svg=true)](https://ci.appveyor.com/project/icenorge/dotnetcore-windowsservices/branch/master)|
| Travis                      | Linux        | [![Build Status](https://travis-ci.org/icenorge/DotNetCore.WindowsServices.svg?branch=master)](https://travis-ci.org/icenorge/DotNetCore.WindowsServices)|


[![NuGet](https://img.shields.io/nuget/v/DotNetCore.WindowsServices.svg)](https://www.nuget.org/packages/DotNetCore.WindowsServices/)
[![NuGet](https://img.shields.io/nuget/dt/DotNetCore.WindowsService.svg)](https://www.nuget.org/packages/DotNetCore.WindowsServices/)

## DotNetCore.WindowsServices
The bare minimum for running a .NET Core 2 console app as a Windows Service

## Install
```
$ dotnet add package DotNetCore.WindowsServices
```

## Usage
```
var host = new HostBuilder();
await host.RunAsServiceAsync();
```

Then publish it targeting a Windows Runtime

```
dotnet publish -r win10-x64
```