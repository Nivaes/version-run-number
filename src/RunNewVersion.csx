#load "RunCommand.csx"
#load "GenerateVersionPatch.csx"
#load "GetLastVersion.csx"
#load "GenerateTag.csx"
using System;

public (string versionPack, string versionRelease) RunNewVersion(string packageFlow)
{
    string versionMajor = "0.0";

    string branch = RunCommand("git", "rev-parse --abbrev-ref HEAD");
    var branch_part = branch.Split("/");

    if(branch_part.Count() > 1)
        versionMajor = branch_part[branch_part.Count() - 1];

    var numberPatchVersion = GetLastVersion(branch);

    string versionPatch = GenerateVersionPatch(packageFlow, branch_part[0]);

    string version = $"{versionMajor}{versionPatch}";

    GenerateTag($"{versionMajor}.{numberPatchVersion}");

    var versionPack = $"{versionMajor}{versionPatch}.{numberPatchVersion}";
    var versionRelease = $"{versionMajor}.{numberPatchVersion}";

    return (versionPack, versionRelease);
}