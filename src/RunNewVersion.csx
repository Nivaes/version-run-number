#load "RunCommand.csx"
#load "GenerateVersionPatch.csx"
#load "GetLastVersion.csx"
#load "GenerateTag.csx"
using System;
using System.Text.RegularExpressions;

public (string version, string versionPack, string versionRelease) RunNewVersion(string packageFlow)
{
    string versionMajor = "0.0";
    string prefixBranch = "";

    string branch = RunCommand("git", "rev-parse --abbrev-ref HEAD");
    var branch_part = branch.Split("/");

    var regex = new Regex(@"^\d+(\.\d+)*$");
    if(branch_part.Count() > 0 && regex.IsMatch(branch_part[^1]))
    {
        versionMajor = branch_part[^1];
        prefixBranch = string.Join("", branch_part[..^1]);
    }
    else
    {
        versionMajor = "0.0";
        prefixBranch = branch;
    }

    var numberPatchVersion = GetLastVersion($"{prefixBranch}/{versionMajor}") + 1;

    string versionPatch = GenerateVersionPatch(packageFlow, branch_part[0]);

    var version = $"{versionMajor}.{numberPatchVersion}";
    var versionPack = $"{versionMajor}{versionPatch}.{numberPatchVersion}";
    var versionRelease = $"{prefixBranch}/{versionMajor}.{numberPatchVersion}";

    return (versionPack, versionRelease);
}