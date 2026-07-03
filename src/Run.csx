#load "RunVersion.csx"

string packageFlow = "";
var version = "";
var prerelease = "";

foreach(var arg in Args)
{
    var parts = arg.Split("=");
    if(parts[0] == "prerelease")
        prerelease = parts[1];
    if(parts[0] == "version")
        version = parts[1];
}

string numberVersion;
string versionPack;
string versionRelease;

(numberVersion, versionPack, versionRelease) = RunVersion(version);

Console.WriteLine(numberVersion);
Console.WriteLine(versionPack);
Console.WriteLine(versionRelease);