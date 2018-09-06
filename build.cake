var target = Argument("target", "Pack");
var project = "DotNetCore.WindowsServices";
var version = GetBuildVersion("0.2");
var outputDir = $"./builds/{project}";

Task("Pack")
    .Does(() => {
        var publishSettings = new DotNetCorePackSettings{
            OutputDirectory = outputDir,
            Configuration = "Release"
        };

        publishSettings.MSBuildSettings = new DotNetCoreMSBuildSettings()
                .WithProperty("Version", new[] { version });

        DotNetCorePack($"./source/{project}/{project}.csproj", publishSettings);
});

Task("Publish")
    .IsDependentOn("Pack")
    .Does(() => {
        var settings = new DotNetCoreNuGetPushSettings
        {
            Source = "https://api.nuget.org/v3/index.json",
            ApiKey = EnvironmentVariable("NUGET_API_KEY")
        };

        DotNetCoreNuGetPush($"{outputDir}/{project}.{version}.nupkg", settings);
});

private string GetBuildVersion(string productVersion)
{
    var now = DateTime.Now.ToString("yyyyMMddHHmmss");
    var buildCounter = Argument("buildcounter", "0");
    var shipit = Argument("shipit", "0") != "0";

    if(shipit)
    {
        return $"{productVersion}.{buildCounter}";
    } 
    else
    {
        return $"{productVersion}.{buildCounter}-beta{now}";
    }
}

RunTarget(target);