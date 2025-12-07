#load "RunCommand.csx"
#load "GenerateVersionPatch.csx"
#load "GetLastVersion.csx"
#load "GenerateTag.csx"
using System;
using System.Text.RegularExpressions;

public (string versionPack, string versionRelease) RunUpdateVersion(string version, string packageFlow)
{
    string versionMajor = "0.0";
    string versionRevision = "0";
    string prefixBranch = "";

    string branch = RunCommand("git", "rev-parse --abbrev-ref HEAD");
    var branch_part = branch.Split("/");

    var version_split = version.Split(".");

    var regex = new Regex(@"^\d+(\.\d+)*$");
    if(branch_part.Count() > 0 && regex.IsMatch(branch_part[^1]))
    {
        prefixBranch = string.Join("", branch_part[..^1]);
    }
    else
    {
        prefixBranch = branch;
    }

    if(version_split.Count() > 0)
    {
        versionMajor = string.Join(".", version_split[..^1]);
        versionRevision = version_split[^1];
    }

    string versionPatch = GenerateVersionPatch(packageFlow, branch_part[0]);

    var versionPack = $"{versionMajor}{versionPatch}.{versionRevision}";
    var versionRelease = $"{versionMajor}.{versionRevision}";

    return (versionPack, versionRelease);
}
