#load "RunNewVersion.csx"
#load "RunUpdateVersion.csx"
using System;

string packageFlow = "";
var version = "";

string version;
string versionPack;
string versionRelease;

foreach(var arg in Args)
{
    var parts = arg.Split("=");
    if(parts[0] == "pf")
        packageFlow = parts[1];
    else if(parts[0] == "v")
        version = parts[1];
}

if(string.IsNullOrWhiteSpace(version) )
{
    (version, versionPack, versionRelease) = RunNewVersion(packageFlow);
}
else
{
    (version, versionPack, versionRelease) = RunUpdateVersion(version, packageFlow);
}


Console.WriteLine(version);
Console.WriteLine(versionPack);
Console.WriteLine(versionRelease);