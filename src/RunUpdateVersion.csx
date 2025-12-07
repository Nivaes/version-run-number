#load "RunCommand.csx"
#load "GenerateVersionPatch.csx"
#load "GetLastVersion.csx"
#load "GenerateTag.csx"
using System;

public (string versionPack, string versionRelease) RunUpdateVersion(string version, string packageFlow)
{

    var versionPart = version.Split("/") ;
    var versionPartPart = versionPart[^1].Split(".");

    string versionMajor = string.Join(".", versionPartPart[..^1]);
    string numberPatchVersion = versionPartPart[^1];

    string versionPatch = GenerateVersionPatch(packageFlow, versionPart[0]);

    version = $"{versionMajor}{versionPatch}";

    var versionPack = $"{versionMajor}{versionPatch}.{numberPatchVersion}";
    var versionRelease = $"{versionMajor}.{numberPatchVersion}";

    return (versionPack, versionRelease);
}
