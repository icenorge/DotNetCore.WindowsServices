## Build status

| Build server                | Platform     | Status                                                                                                                    |
|-----------------------------|--------------|---------------------------------------------------------------------------------------------------------------------------|
| AppVeyor                    | Windows      | [![Build status](https://ci.appveyor.com/api/projects/status/)](https://ci.appveyor.com/project/)|
| Travis                      | Linux        | [![Build Status](https://travis-ci.org/)](https://travis-ci.org/)|


 [![NuGet](https://img.shields.io/nuget/v/DotNetCore.WindowsServices.svg)](https://www.nuget.org/packages/DotNetCore.WindowsServices/)
[![NuGet](https://img.shields.io/nuget/dt/DotNetCore.WindowsServicessvg)](https://www.nuget.org/packages/DotNetCore.WindowsServices/)
## dotnet-retire
A `dotnet` CLI extension to check your project for known vulnerabilities.

## Install
```
$ dotnet add package DotNetCore.WindowsServices
```

## Usage
```
var host = new HostBuilder();
await host.RunAsServiceAsync();
```
