var target = Argument("target", "Default");
var project = "DotNetCore.WindowsServices";
var version = "0.1.0";
var runtime = "win10-x64";

Task("Default")
.Does(() => {
    var publishSettings = new DotNetCorePublishSettings{
        OutputDirectory = $"builds/{project}",
        Configuration = "Release"
    };

    if(!string.IsNullOrEmpty(runtime))
        publishSettings.Runtime = runtime;

    publishSettings.MSBuildSettings = new DotNetCoreMSBuildSettings()
            .WithProperty("Version", new[] { version });

    DotNetCorePublish($"./source/{project}/{project}.csproj", publishSettings);});

RunTarget(target);