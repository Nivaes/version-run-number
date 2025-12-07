#load "RunNewVersion.csx"
#load "RunUpdateVersion.csx"
using System;

string packageFlow = "";
var version = "";

foreach(var arg in Args)
{
    var parts = arg.Split("=");
    if(parts[0] == "pf")
        packageFlow = parts[1];
    else if(parts[0] == "v")
        version = parts[1];
}

string numberVersion;
string versionPack;
string versionRelease;

if(string.IsNullOrWhiteSpace(version) )
{
    (numberVersion, versionPack, versionRelease) = RunNewVersion(packageFlow);
}
else
{
    (numberVersion, versionPack, versionRelease) = RunUpdateVersion(version, packageFlow);
}


Console.WriteLine(numberVersion);
Console.WriteLine(versionPack);
Console.WriteLine(versionRelease);