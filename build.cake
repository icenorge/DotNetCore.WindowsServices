var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

Task("Default")
.Does(() => {
   Information("Hello Cake!");
});

RunTarget(target);