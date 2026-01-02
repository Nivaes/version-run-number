#load "RunVersion.csx"
#load "RunUpdateVersion.csx"
using System;

string packageFlow = "";
var version = "";

foreach(var arg in Args)
{
    var parts = arg.Split("=");
    if(parts[0] == "branch")
        version = parts[1];
}

string numberVersion;
string versionPack;
string versionRelease;

// if(string.IsNullOrWhiteSpace(version) )
// {
//     (numberVersion, versionPack, versionRelease) = RunVersion(packageFlow);
// }
// else
// {
//     (numberVersion, versionPack, versionRelease) = RunUpdateVersion(version, packageFlow);
// }
(numberVersion, versionPack, versionRelease) = RunVersion(version);

Console.WriteLine(numberVersion);
Console.WriteLine(versionPack);
Console.WriteLine(versionRelease);