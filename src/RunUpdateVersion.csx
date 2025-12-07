#load "RunCommand.csx"
#load "GenerateVersionPatch.csx"
#load "GetLastVersion.csx"
#load "GenerateTag.csx"
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

var versionPart = version.Split("/") ;
var versionPartPart = versionPart[^1].Split(".");

string versionMajor = string.Join(".", versionPartPart[..^1]);
string numberPatchVersion = versionPartPart[^1];

string versionPatch = GenerateVersionPatch(packageFlow, versionPart[0]);

version = $"{versionMajor}{versionPatch}";

Console.WriteLine($"{versionMajor}{versionPatch}.{numberPatchVersion}");
Console.WriteLine($"{versionMajor}.{numberPatchVersion}");
