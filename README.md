## Build status

| Build server                | Platform     | Status                                                                                                                    |
|-----------------------------|--------------|---------------------------------------------------------------------------------------------------------------------------|
| AppVeyor                    | Windows      | [![Build status](https://ci.appveyor.com/api/projects/status/1ax6w93byxor88l0/branch/master?svg=true)](https://ci.appveyor.com/project/icenorge/dotnetcore-windowsservices/branch/master)|
| Travis                      | Linux        | [![Build Status](https://travis-ci.org/icenorge/DotNetCore.WindowsServices.svg?branch=master)](https://travis-ci.org/icenorge/DotNetCore.WindowsServices)|
| Azure DevOps| Linux |[![Build Status](https://dev.azure.com/icenorge/DotNetCore.WindowsServices/_apis/build/status/icenorge.DotNetCore.WindowsServices)](https://dev.azure.com/icenorge/DotNetCore.WindowsServices/_build/latest?definitionId=1)|


[![NuGet](https://img.shields.io/nuget/v/DotNetCore.WindowsServices.svg)](https://www.nuget.org/packages/DotNetCore.WindowsServices/)
[![NuGet](https://img.shields.io/nuget/dt/DotNetCore.WindowsService.svg)](https://www.nuget.org/packages/DotNetCore.WindowsServices/)

## DotNetCore.WindowsServices
The bare minimum for running a .NET Core 2 console app as a Windows Service. Currently, there's a NuGet for running ASP.NET Core apps as a Windows Service, but [there's only a sample on how to do non web .NET Core apps as Windows Services](https://github.com/aspnet/Hosting/issues/1529). This NuGet extracts the code from that sample so it's more easily available.

## Install
```
> dotnet add package DotNetCore.WindowsServices
```

## Usage
```
static async Task Main(string[] args)
{
    var host = new HostBuilder();
    host.ConfigureServices(c => c.AddSingleton<IHostedService, BackgroundWorker>());
    await host.RunAsServiceAsync();
}
```

# NB.

This will of course only work on Windows. Running it on another platform throws `PlatformNotSupportedException`s.

